using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Request
{
    public class RequestBody<T> where T : class
    {
        [JsonProperty("name")] public string RequestBodyType { get; set; }

        [JsonProperty("body")] public T Body { get; set; }

        [JsonProperty("version")] public string Version { get; set; } = "1.0";
    }
}