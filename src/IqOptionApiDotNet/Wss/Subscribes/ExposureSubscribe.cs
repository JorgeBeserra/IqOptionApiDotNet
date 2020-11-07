using System;
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
        private readonly Subject<ExposureResult> _exposureResultSubject = new Subject<ExposureResult>();

        public IObservable<ExposureResult> ExposureResultObservable => _exposureResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.Exposure, typeof(ExposureResult))]
        public void Subscribe(ExposureResult value)
        {
            _exposureResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnExposureResultDisposal()
        {
            _exposureResultSubject.OnCompleted();
        }

    }
}