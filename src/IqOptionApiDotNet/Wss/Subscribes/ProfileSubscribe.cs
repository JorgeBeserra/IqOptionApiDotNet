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
        private readonly Subject<Profile> _profileSubject = new Subject<Profile>();
        public Profile Profile { get; private set; }
        public IObservable<Profile> ProfileObservable => _profileSubject.AsObservable();

        [SubscribeForTopicName(MessageType.Profile, typeof(Profile))]
        public void Subscribe(Profile type)
        {
            Profile = type;
            _profileSubject.OnNext(type);
            
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
        private void OnProfileDisposal()
        {
            _profileSubject.OnCompleted();
        }
    }
}