using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Wss.Request.SubscribeMessages;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<BalanceChanged> _balanceChangedSubject = new Subject<BalanceChanged>();
        public Balance CurrentBalance { get; private set; }
        public IObservable<BalanceChanged> BalanceChangedObservable => _balanceChangedSubject.AsObservable();

        [SubscribeForTopicName(MessageType.BalanceChanged, typeof(BalanceChanged))]
        public void Subscribe(BalanceChanged type)
        {
            CurrentBalance = type.CurrentBalance;
            _balanceChangedSubject.OnNext(type);
        }

        [Predisposable]
        internal void OnBalanceChangedDisposal()
        {
            _balanceChangedSubject.OnCompleted();
        }

        /// <summary>
        /// Subscribe to Balance Changed
        /// </summary>
        /// <param name="message"></param>        
        public void SubscribeBalanceChanged(string requestId)
        {
            SendMessageAsync(requestId, new SubscribeBalanceChangedRequest(MessageType.BalanceChanged), "s_").ConfigureAwait(false);
        }

        /// <summary>
        /// UnSubscribe to Balance Changed
        /// </summary>
        /// <param name="message">The Request id.</param>      
        public void UnSubscribeBalanceChanged(string requestId)
        {
            SendMessageAsync(requestId, new UnsubscribeBalanceChangedRequest(MessageType.BalanceChanged), "s_").ConfigureAwait(false);
        }
    }

    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<BinaryOptionsResult> _buyResultSubject = new Subject<BinaryOptionsResult>();

        public IObservable<BinaryOptionsResult> BinaryOptionPlacedResultObservable =>
            _buyResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.PlacedBinaryOptions, typeof(BinaryOptionsResult))]
        public void Subscribe(BinaryOptionsResult value)
        {
            _buyResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnPlacedBinaryOptionsDisposal()
        {
            _buyResultSubject.OnCompleted();
        }

    }

}