using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Ws.Request;
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
        private readonly Subject<OptionClosed> _closedOptionSubject = new Subject<OptionClosed>();

        private readonly Subject<OptionOpened> _openOptionSubject = new Subject<OptionOpened>();

        public IObservable<OptionOpened> OpenOptionObservable()
        {
            return _openOptionSubject.AsObservable();
        }

        /// <summary>
        /// Enable or disable option results for the current WebSocket session.
        /// Enabled automatically during initialization. Re-enable after reconnecting the socket.
        /// </summary>
        public Task SetOptionResultsAsync(string requestId, bool sendResults = true)
        {
            return SendMessageAsync(requestId, new SetOptionsRequestMessage(sendResults));
        }

        public IObservable<OptionClosed> ClosedOptionObservable()
        {
            return _closedOptionSubject.AsObservable();
        }


        [SubscribeForTopicName(MessageType.OptionOpened, typeof(OptionOpened))]
        public void Subscribe(OptionOpened type)
        {
            _openOptionSubject.OnNext(type);
        }

        [SubscribeForTopicName(MessageType.OptionClosed, typeof(OptionClosed))]
        public void Subscribe(OptionClosed type)
        {
            _closedOptionSubject.OnNext(type);
        }

        [Predisposable]
        private void OnCompletedOptionDisposable()
        {
            _closedOptionSubject.OnCompleted();
            _openOptionSubject.OnCompleted();
        }
    }
}