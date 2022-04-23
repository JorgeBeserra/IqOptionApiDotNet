using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Base
{
    public interface IWsAuthenticatedMessage<T> : IWsIqOptionMessageCreator
    {
        [JsonProperty("name")] string Name { get; set; }
        [JsonProperty("msg")] bool Message { get; set; }
        [JsonProperty("client_session_id")] string ClientSessionId { get; set; }
        [JsonProperty("request_id")] string RequestId { get; set; }
    }
}