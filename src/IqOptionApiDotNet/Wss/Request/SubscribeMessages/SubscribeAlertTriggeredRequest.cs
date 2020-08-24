using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Utilities;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Wss.Request.SubscribeMessages
{
    internal class SubscribeAlertTriggeredRequest : WsMessageBase<dynamic>
    {
        public override string Name => "subscribeMessage";

        public SubscribeAlertTriggeredRequest()
        {
            base.Message = new
            {
                name = RequestMessageBodyType.SubscribeAlertTriggered
            };
        }
    }
}