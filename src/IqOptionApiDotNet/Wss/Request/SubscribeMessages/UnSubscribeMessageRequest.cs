using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class UnSubscribeMessageRequest : SubscribeMessageRequest
    {
        public UnSubscribeMessageRequest(ActivePair pair, TimeFrame timeFrame) : base(pair, timeFrame)
        {
        }

        public override string Name => MessageType.UnsubscribeMessage;
    }
}