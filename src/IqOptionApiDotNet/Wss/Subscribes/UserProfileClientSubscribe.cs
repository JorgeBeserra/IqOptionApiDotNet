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
        private readonly Subject<UserProfileClientResult> _userProfileClientResultSubject = new Subject<UserProfileClientResult>();

        public IObservable<UserProfileClientResult> UserProfileClientResultObservable => _userProfileClientResultSubject.AsObservable();

        [SubscribeForTopicName(MessageType.UserProfileClient, typeof(UserProfileClientResult))]
        public void Subscribe(UserProfileClientResult value)
        {
            _userProfileClientResultSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnUserProfileClientDisposal()
        {
            _userProfileClientResultSubject.OnCompleted();
        }
        
    }
}