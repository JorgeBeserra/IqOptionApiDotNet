using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request.Portfolio;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class UnSubscribeTopAssetsUpdatedRequest : SubscribeTopAssetsUpdatedRequest
    {
        public UnSubscribeTopAssetsUpdatedRequest(InstrumentType instrumentType):base(instrumentType)
        {
            
        }
        
        public override string Name => MessageType.UnsubscribeMessage;
    }
}