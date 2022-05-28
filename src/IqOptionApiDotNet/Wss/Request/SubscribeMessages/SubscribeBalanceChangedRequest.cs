using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Utilities;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Wss.Request.SubscribeMessages
{
    internal class SubscribeBalanceChangedRequest : WsMessageBase<dynamic>
    {
        public override string Name => "subscribeMessage";

        public SubscribeBalanceChangedRequest(string message)
        {
            base.Message = new
            {
                name = message,
                @params =
                    new {
                        routingFilters =
                            new{}
                    }
            };
        }
    }
}