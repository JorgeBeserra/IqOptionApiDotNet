using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class LoginModel
    {
        [JsonProperty("identifier")] public string Email { get; set; }

        [JsonProperty("password")] public string Password { get; set; }
    }
}