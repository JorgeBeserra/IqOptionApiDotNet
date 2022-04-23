using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class AuthenticateMessageModel
    {
        [JsonProperty("ssid")] public string SsidToken { get; set; }
        [JsonProperty("protocol")] public int Protocol { get; set; }
        [JsonProperty("session_id")] public string SessionId { get; set; }
        [JsonProperty("client_session_id")] public string ClientSessionId { get; set; }
    }

    internal class AuthenticateWsMessageBase : WsMessageBase<AuthenticateMessageModel>
    {
        public AuthenticateWsMessageBase(string ssid)
        {
            base.Message = new AuthenticateMessageModel
            {
                SsidToken = ssid,
                Protocol = 3,
                SessionId = "",
                ClientSessionId = ""
            };
        }

        public override string Name => MessageType.Authenticate;
    }
}