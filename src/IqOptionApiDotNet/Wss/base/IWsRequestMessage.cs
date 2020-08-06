using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Base
{
    public interface IWsMessage<T> : IWsIqOptionMessageCreator
    {
        [JsonProperty("name")] string Name { get; set; }

        [JsonProperty("msg")] T Message { get; set; }
    }
}