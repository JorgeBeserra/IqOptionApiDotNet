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
        private readonly Subject<LeaderBoardUserinfoDealsClientMessageResult> _leaderBoardUserinfoDealsClientSubject = new Subject<LeaderBoardUserinfoDealsClientMessageResult>();

        public IObservable<LeaderBoardUserinfoDealsClientMessageResult> LeaderBoardUserinfoDealsClientResultObservable => _leaderBoardUserinfoDealsClientSubject.AsObservable();

        [SubscribeForTopicName(MessageType.LeaderboardUserinfoDealsClient, typeof(LeaderBoardUserinfoDealsClientMessageResult))]
        public void Subscribe(LeaderBoardUserinfoDealsClientMessageResult value)
        {
            _leaderBoardUserinfoDealsClientSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnLeaderBoardUserinfoDealsClientDisposal()
        {
            _leaderBoardUserinfoDealsClientSubject.OnCompleted();
        }
        
    }
}