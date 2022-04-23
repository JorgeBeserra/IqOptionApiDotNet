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
        private readonly Subject<AuthenticatedResult> _authenticatedResultSubject = new Subject<AuthenticatedResult>();

        public IObservable<AuthenticatedResult> AuthenticatedObservable => _authenticatedResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.Authenticated, typeof(AuthenticatedResult))]
        public void Subscribe(AuthenticatedResult value)
        {
            _authenticatedResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnAuthenticatedDisposal()
        {
            _userProfileClientResultSubject.OnCompleted();
        }
        
    }
}