using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request.Portfolio;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<ProfileChanged> _profileChangedSubject = new Subject<ProfileChanged>();

        public ProfileChanged ProfileChanged { get; private set; }
        public IObservable<ProfileChanged> ProfileChangedObservable => _profileChangedSubject.AsObservable();

        [SubscribeForTopicName(MessageType.ProfileChanged, typeof(ProfileChanged))]
        public void Subscribe(ProfileChanged type)
        {
            ProfileChanged = type;
            _profileChangedSubject.OnNext(type);
            
            //invoke subscribe portfolio changed
            foreach (var instru in new[]
            {
                //InstrumentType.Forex,
                //InstrumentType.CFD,
                //InstrumentType.Crypto,
                InstrumentType.DigitalOption,
                //InstrumentType.TurboOption,
                //InstrumentType.BinaryOption,
                //InstrumentType.FxOption
            })
            {
                var requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                SubscribePositionChanged(requestId, instru).ConfigureAwait(false);
            }
        }

        [Predisposable]
        private void OnProfileChangedDisposal()
        {
            _profileChangedSubject.OnCompleted();
        }
    }
}