using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request.Portfolio;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class UnSubscribeAlertTriggeredRequest : SubscribePortfolioPositionChangedRequest
    {
        public UnSubscribeAlertTriggeredRequest(long userId, long balanceId, InstrumentType instrumentType):base(userId, balanceId, instrumentType)
        {
            
        }
        
        public override string Name => MessageType.UnsubscribeMessage;
    }
}