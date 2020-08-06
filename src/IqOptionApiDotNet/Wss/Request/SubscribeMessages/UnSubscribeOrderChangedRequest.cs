using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request.Portfolio;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class UnSubscribeOrderChangedRequest : SubscribePortfolioOrderChangedRequest
    {
        public UnSubscribeOrderChangedRequest(long userId, InstrumentType instrumentType):base(userId, instrumentType)
        {
            
        }
        
        public override string Name => MessageType.UnsubscribeMessage;
    }
}