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
        #region [PlaceDigitalOptions]

        private readonly Subject<DigitalOptionsPlacedResult> _placeDigitalOptionResult = new Subject<DigitalOptionsPlacedResult>();
        public IObservable<DigitalOptionsPlacedResult> PlaceDigitalOptionResultObservable => _placeDigitalOptionResult.AsObservable();
        

        [SubscribeForTopicName(MessageType.PlacedDigitalOptions, typeof(DigitalOptionsPlacedResult))]
        public void Subscribe(DigitalOptionsPlacedResult type)
        {
            _placeDigitalOptionResult.OnNext(type);
        }


        #endregion
    }
}