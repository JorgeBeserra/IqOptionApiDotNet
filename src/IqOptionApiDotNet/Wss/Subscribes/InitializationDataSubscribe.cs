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
        private readonly Subject<InitializationData> _initializationDataSubject = new Subject<InitializationData>();

        public IObservable<InitializationData> InitializationDataObservable => _initializationDataSubject.AsObservable();

        [SubscribeForTopicName(MessageType.InitializationData, typeof(InitializationData))]
        public void Subscribe(InitializationData value)
        {
            _initializationDataSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnInitializationDataDisposal()
        {
            _initializationDataSubject.OnCompleted();
        }
    }
}