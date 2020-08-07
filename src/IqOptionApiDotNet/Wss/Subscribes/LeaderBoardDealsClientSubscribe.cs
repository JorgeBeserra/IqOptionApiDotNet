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
        private readonly Subject<LeaderBoardDealsClientResult> _leaderBoardDealsClientSubject = new Subject<LeaderBoardDealsClientResult>();

        public IObservable<LeaderBoardDealsClientResult> LeaderBoardDealsClientResultObservable => _leaderBoardDealsClientSubject.AsObservable();

        [SubscribeForTopicName(MessageType.LeaderboardDealsClient, typeof(LeaderBoardDealsClientResult))]
        public void Subscribe(LeaderBoardDealsClientResult value)
        {
            _leaderBoardDealsClientSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnLeaderBoardDealsClientDisposal()
        {
            _leaderBoardDealsClientSubject.OnCompleted();
        }
        
    }
}