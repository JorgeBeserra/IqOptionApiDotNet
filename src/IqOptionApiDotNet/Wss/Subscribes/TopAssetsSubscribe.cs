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
        private readonly Subject<TopAssets> _topAssetsSubject = new Subject<TopAssets>();

        public IObservable<TopAssets> TopAssetsObservable => _topAssetsSubject.AsObservable();

        [SubscribeForTopicName(MessageType.TopAssets, typeof(TopAssets))]
        public void Subscribe(TopAssets value)
        {
            _topAssetsSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnTopAssetsDisposal()
        {
            _topAssetsSubject.OnCompleted();
        }
        
    }
}