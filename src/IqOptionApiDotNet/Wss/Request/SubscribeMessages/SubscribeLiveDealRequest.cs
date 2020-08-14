using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Utilities;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Wss.Request.SubscribeMessages
{
    internal class SubscribeLiveDealRequest : WsMessageBase<dynamic>
    {
        public override string Name => "subscribeMessage";

        public SubscribeLiveDealRequest(string requestId, string message, ActivePair pair, DigitalOptionsExpiryType duration)
        {
            base.Message = new
            {
                name = message,
                @params =
                    new {
                        routingFilters =
                            new
                            {
                                instrument_active_id = (int) pair,
                                expiration_type = duration.ToString()
                            }
                    }
            };
        }
    }
}