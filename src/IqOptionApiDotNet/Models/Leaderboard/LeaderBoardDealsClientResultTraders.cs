using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class LeaderBoardDealsClientResultTraders
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("user_name")] public string UserName { get; set; }
        [JsonProperty("score")] public double Score { get; set; }
        [JsonProperty("count")] public long Count { get; set; }
        [JsonProperty("flag")] public string Flag { get; set; }
    }
}