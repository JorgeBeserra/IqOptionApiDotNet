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
        private readonly Subject<Alerts> _alertsResultSubject = new Subject<Alerts>();
        private readonly Subject<Alert> _alertResultSubject = new Subject<Alert>();
        private readonly Subject<AlertChanged> _alertChangedResultSubject = new Subject<AlertChanged>();
        private readonly Subject<AlertTriggered> _alertTriggeredResultSubject = new Subject<AlertTriggered>();

        public IObservable<Alerts> AlertsResultObservable => _alertsResultSubject.AsObservable();
        public IObservable<Alert> AlertResultObservable => _alertResultSubject.AsObservable();
        public IObservable<AlertChanged> AlertChangedResultObservable => _alertChangedResultSubject.AsObservable();
        public IObservable<AlertTriggered> AlertTriggeredResultObservable => _alertTriggeredResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.Alerts, typeof(Alerts))]
        public void Subscribe(Alerts value)
        {
            _alertsResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnAlertsDisposal()
        {
            _alertsResultSubject.OnCompleted();
        }

        [SubscribeForTopicName(MessageType.Alert, typeof(Alert))]
        public void Subscribe(Alert value)
        {
            _alertResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnAlertDisposal()
        {
            _alertResultSubject.OnCompleted();
        }

        [SubscribeForTopicName(MessageType.AlertChanged, typeof(AlertChanged))]
        public void Subscribe(AlertChanged value)
        {
            _alertChangedResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnAlertChangedDisposal()
        {
            _alertChangedResultSubject.OnCompleted();
        }

        [SubscribeForTopicName(MessageType.AlertTriggered, typeof(AlertTriggered))]
        public void Subscribe(AlertTriggered value)
        {
            _alertTriggeredResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnAlertTriggeredDisposal()
        {
            _alertTriggeredResultSubject.OnCompleted();
        }

        /// <summary>
        /// Subscribe to Alerts Changed
        /// </summary>
        /// <param name="requestId"></param>
        public void SubscribeAlertChangedChanged(string requestId)
        {
            SendMessageAsync(requestId, new SubscribeAlertChangedRequest(), "s_").ConfigureAwait(false);
        }

        /// <summary>
        /// Subscribe to Alerts Triggered
        /// </summary>
        /// <param name="requestId"></param>
        public void SubscribeAlertTriggeredChanged(string requestId)
        {
            SendMessageAsync(requestId, new SubscribeAlertTriggeredRequest(), "s_").ConfigureAwait(false);
        }

    }
}