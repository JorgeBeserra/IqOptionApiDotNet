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
        private readonly Subject<Currency> _currencySubject = new Subject<Currency>();

        public IObservable<Currency> CurrencyObservable => _currencySubject.AsObservable();

        [SubscribeForTopicName(MessageType.Currency, typeof(Currency))]
        public void Subscribe(Currency value)
        {
            _currencySubject.OnNext(value);
        }

        [Predisposable]
        internal void OnCurrencyDisposal()
        {
            _currencySubject.OnCompleted();
        }
    }
}