using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;

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