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
        private readonly Subject<FinancialInformationResult> _financialInformationResultSubject = new Subject<FinancialInformationResult>();

        public IObservable<FinancialInformationResult> FinancialInformationResultObservable => _financialInformationResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.FinancialInformation, typeof(FinancialInformationResult))]
        public void Subscribe(FinancialInformationResult value)
        {
            _financialInformationResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnFinancialInformationResultDisposal()
        {
            _financialInformationResultSubject.OnCompleted();
        }
        
    }
}