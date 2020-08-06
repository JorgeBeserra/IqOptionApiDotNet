using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws
{
    public class GetCandleItemsResultMessage : WsMessageBase<CandleCollections>
    {
    }

    public class CurrentCandleInfoResultMessage : WsMessageBase<CurrentCandle>
    {
    }
}