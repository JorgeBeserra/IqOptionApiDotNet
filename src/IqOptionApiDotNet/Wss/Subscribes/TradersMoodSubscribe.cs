using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Wss.Request.SubscribeMessages;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<TraderMood> _traderMoodSubject = new Subject<TraderMood>();
        public IObservable<TraderMood> TradersMoodObservable() => _traderMoodSubject.AsObservable();

        [SubscribeForTopicName(MessageType.TraderMoodChanged, typeof(TraderMood))]
        public void Subscribe(TraderMood value)
        {
            _traderMoodSubject.OnNext(value);
        }
        
        /// <summary>
        /// Subscribe to Traders mood changed
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pair"></param>
        public void SubscribeTradersMoodChanged(string requestId, InstrumentType type, ActivePair pair)
        {
            SendMessageAsync(requestId, new SubscribeTradersMoodChangedRequest(type, pair), "s_").ConfigureAwait(false);
        }

        /// <summary>
        /// UnSubscribe to Traders mood changed
        /// </summary>
        /// <param name="string">Request Id</param>
        /// <param name="type">The Instrument type.</param>
        /// <param name="pair">The Active pair</param>
        public void UnSubscribeTradersMoodChanged(string requestId, InstrumentType type, ActivePair pair)
        {
            SendMessageAsync(requestId, new UnsubscribeTradersMoodChanged(type, pair), "s_").ConfigureAwait(false);
        }
    }
}