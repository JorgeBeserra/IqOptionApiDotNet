using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class LeaderBoardDealsClientResult
    {
        [JsonProperty("isSuccessful")] public bool IsSuccessful { get; set; }

        [JsonProperty("result")] public LeaderBoardDealsClientMessageResult Result { get; set; }
    }
}