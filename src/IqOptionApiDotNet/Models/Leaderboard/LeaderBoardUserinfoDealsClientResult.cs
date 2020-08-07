using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class LeaderBoardUserinfoDealsClientMessageResult
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("country_id")] public long CountryId { get; set; }
        [JsonProperty("top_type")] public long TopType { get; set; }
        [JsonProperty("top_size")] public long TopSize { get; set; }
        [JsonProperty("position")] public long Position { get; set; }
        [JsonProperty("score")] public long Score { get; set; }
    }
}