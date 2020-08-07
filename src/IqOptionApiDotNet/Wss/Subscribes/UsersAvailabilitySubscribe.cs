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
        private readonly Subject<UsersAvailabilityResult> _usersAvailabilityResultSubject = new Subject<UsersAvailabilityResult>();

        public IObservable<UsersAvailabilityResult> UsersAvailabilityResultObservable => _usersAvailabilityResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.UsersAvailability, typeof(UsersAvailabilityResult))]
        public void Subscribe(UsersAvailabilityResult value)
        {
            _usersAvailabilityResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnUsersAvailabilityDisposal()
        {
            _usersAvailabilityResultSubject.OnCompleted();
        }
        
    }
}