using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Wss.Request.SubscribeMessages;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<LiveDeal> _livedealSubject = new Subject<LiveDeal>();
        public IObservable<LiveDeal> LiveDealObservable() => _livedealSubject.AsObservable();

        [SubscribeForTopicName(MessageType.LiveDealDigitalOption, typeof(LiveDeal))]
        public void Subscribe(LiveDeal value)
        {
            _livedealSubject.OnNext(value);
        }

        /// <summary>
        /// Subscribe to to Live Deal
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pair"></param>
        /// <param name="duration"></param>
        public void SubscribeLiveDeal(string requestId, string message, ActivePair pair, DigitalOptionsExpiryType duration)
        {
            SendMessageAsync(requestId, new SubscribeLiveDealRequest(requestId, message, pair, duration), "s_").ConfigureAwait(false);
        }

        /// <summary>
        /// UnSubscribe to Live Deal
        /// </summary>
        /// <param name="message">The Instrument type.</param>
        /// <param name="pair">The Instrument type.</param>
        /// <param name="duration">The Active pair</param>
        public void UnSubscribeLiveDeal(string requestId, string message, ActivePair pair, DigitalOptionsExpiryType duration)
        {
            SendMessageAsync(requestId, new UnsubscribeLiveDealRequest(message, pair, duration), "s_").ConfigureAwait(false);
        }
    }
}