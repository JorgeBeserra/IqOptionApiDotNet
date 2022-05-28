using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Utilities;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Wss.Request.SubscribeMessages
{
    internal class UnsubscribeBalanceChangedRequest : WsMessageBase<dynamic>
    {
        public override string Name => "unsubscribeMessage";

        public UnsubscribeBalanceChangedRequest(string message)
        {
            
            base.Message = new
            {
                name = message,
                @params =
                    new
                    {
                        routingFilters = new{}
                    }
            };
        }
    }
}