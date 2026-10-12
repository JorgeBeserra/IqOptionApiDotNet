using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Request
{
    internal sealed class SetOptionsRequestMessage : WsMessageBase<SetOptionsBody>
    {
        public override string Name => "setOptions";

        public SetOptionsRequestMessage(bool sendResults)
        {
            Message = new SetOptionsBody { SendResults = sendResults };
        }
    }

    internal sealed class SetOptionsBody
    {
        [JsonProperty("sendResults")]
        public bool SendResults { get; set; }
    }
}
