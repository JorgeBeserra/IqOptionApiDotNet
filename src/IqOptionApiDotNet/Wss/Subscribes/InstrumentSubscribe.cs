using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Ws
{

    public partial class IqOptionWebSocketClient
    {
        #region [Instrument]

        private readonly Subject<InstrumentResult> _instrumentResult = new Subject<InstrumentResult>();
        public IObservable<InstrumentResult> InstrumentResultObservable => _instrumentResult.AsObservable();
        
        [SubscribeForTopicName(MessageType.Instruments, typeof(InstrumentResult))]
        public void Subscribe(InstrumentResult type)
        {
            _instrumentResult.OnNext(type);
        }

        #endregion
    }
}