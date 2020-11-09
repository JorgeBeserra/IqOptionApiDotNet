using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<IEnumerable<Balance>> _balancesSubject = new Subject<IEnumerable<Balance>>();

        public IObservable<IEnumerable<Balance>> BalancesObservable => _balancesSubject.AsObservable();

        [SubscribeForTopicName(MessageType.Balances, typeof(IEnumerable<Balance>))]
        public void Subscribe(IEnumerable<Balance> value)
        {
            _balancesSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnBalancesDisposal()
        {
            _balancesSubject.OnCompleted();
        }

    }
}