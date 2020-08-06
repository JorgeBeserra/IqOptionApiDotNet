using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Ws.result
{
    internal class BuyCompleteResultMessage : WsMessageBase<WsMessageWithSuccessfulResult<BinaryOptionsResult>>
    {
    }
}