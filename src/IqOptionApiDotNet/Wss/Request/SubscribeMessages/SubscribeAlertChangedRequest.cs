using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Wss.Request.SubscribeMessages
{
    internal class SubscribeAlertChangedRequest : WsMessageBase<dynamic>
    {
        public override string Name => "subscribeMessage";

        public SubscribeAlertChangedRequest()
        {
            base.Message = new
            {
                name = RequestMessageBodyType.SubscribeAlertChanged
            };
        }
    }
}