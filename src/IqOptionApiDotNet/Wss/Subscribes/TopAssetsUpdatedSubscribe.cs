using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request;
using IqOptionApiDotNet.Ws.Request.Portfolio;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<TopAssetsUpdated> _topAssetsUpdatedSubject = new Subject<TopAssetsUpdated>();

        public IObservable<TopAssetsUpdated> TopAssetsUpdatedObservable => _topAssetsUpdatedSubject.AsObservable();

        [SubscribeForTopicName(MessageType.TopAssetsUpdated, typeof(TopAssetsUpdated))]
        public void Subscribe(TopAssetsUpdated value)
        {
            _topAssetsUpdatedSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnTopAssetsUpdatedDisposal()
        {
            _topAssetsUpdatedSubject.OnCompleted();
        }



        /// <summary>
        /// Subscribe to to Live Deal
        /// </summary>
        /// <param name="message"></param>
        /// <param name="pair"></param>
        /// <param name="duration"></param>
        public void SubscribeTopAssetsUpdated(string requestId, InstrumentType instrumentType)
        {
            SendMessageAsync(requestId, new SubscribeTopAssetsUpdatedRequest(instrumentType), "s_").ConfigureAwait(false);
        }

        /// <summary>
        /// UnSubscribe to Live Deal
        /// </summary>
        /// <param name="message">The Instrument type.</param>
        /// <param name="pair">The Instrument type.</param>
        /// <param name="duration">The Active pair</param>
        public void UnSubscribeTopAssetsUpdated(string requestId, InstrumentType instrumentType)
        {
            SendMessageAsync(requestId, new UnSubscribeTopAssetsUpdatedRequest(instrumentType), "s_").ConfigureAwait(false);
        }

    }
}