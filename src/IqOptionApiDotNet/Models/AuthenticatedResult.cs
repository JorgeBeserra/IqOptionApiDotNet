using System;
using IqOptionApiDotNet.Converters.JsonConverters;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class AuthenticatedResult
    {
        [JsonProperty("client_session_id")] public string ClientSessionId { get; set; }
        [JsonProperty("request_id")] public string RequestId { get; set; }
    }
}