using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Request;
using IqOptionApiDotNet.Ws.Request.Portfolio;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        //private readonly Subject<OrderChanged> _orderChangedSubject = new Subject<OrderChanged>();
        private readonly Subject<PositionChanged> _positionChangedSubject = new Subject<PositionChanged>();
        
        //public IObservable<OrderChanged> OrderChangedObservable() => _orderChangedSubject.AsObservable();
        public IObservable<PositionChanged> PositionChangedObservable() => _positionChangedSubject.DistinctUntilChanged().AsObservable();
         
        
        /*
        [SubscribeForTopicName(MessageType.SubscribeOrderChanged, typeof(OrderChanged))]
        void Subscribe(OrderChanged orderChanged)
        {
            _orderChangedSubject.OnNext(orderChanged);
        }
        */

        [SubscribeForTopicName("position-changed", typeof(PositionChanged))]
        public void Subscribe(PositionChanged positionChanged)
        {
            _positionChangedSubject.OnNext(positionChanged);
        }

        /*
        public async Task SubscribeOrderChanged(InstrumentType instrumentType)
        {
            if (Profile == null)
            {
                await SendMessageAsync(new SsidWsMessageBase(SecureToken)).ConfigureAwait(false);
                await Task.Delay(500);
            }
            
            await SendMessageAsync(new SubscribePortfolioOrderChangedRequest(Profile.UserId, instrumentType))
                .ConfigureAwait(false);
        }
        */

        /// <summary>
        /// To subscribe the order changed support for "Forex", "Digital-Option"
        /// </summary>
        /// <returns></returns>
        public async Task SubscribePositionChanged(string requestId, InstrumentType instrumentType)
        {
            if (Profile == null)
            {
                await SendMessageAsync(requestId, new SsidWsMessageBase(SecureToken)).ConfigureAwait(false);
                await Task.Delay(500);
            }

            await UnSubscribePositionChanged(requestId, instrumentType);

            await SendMessageAsync(requestId, new SubscribePortfolioPositionChangedRequest(Profile.UserId,
                    Profile.BalanceId, instrumentType))
                .ConfigureAwait(false);
        }

        public async Task UnSubscribePositionChanged(string requestId, InstrumentType instrumentType)
        {
            await SendMessageAsync(requestId, new UnSubscribePositionChangedRequest(Profile.UserId,
                    Profile.BalanceId, instrumentType))
                .ConfigureAwait(false);
        }
    }
}