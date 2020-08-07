using System.Collections.Generic;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class LeaderBoardDealsClientMessageResult
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("country_id")] public long CountryId { get; set; }
        [JsonProperty("top_type")] public long TopType { get; set; }
        [JsonProperty("top_size")] public long TopSize { get; set; }
        [JsonProperty("position")] public long Position { get; set; }
        [JsonProperty("user_accounted_expiration_time")] public long UserAccountedExpirationTime { get; set; }
        [JsonProperty("top")] public Dictionary<string, LeaderBoardDealsClientResultTraders> Top { get; set; }
        [JsonProperty("Positional")] public Dictionary<string, LeaderBoardDealsClientResultTraders> Positional { get; set; }
        [JsonProperty("near_traders")] public Dictionary<string, LeaderBoardDealsClientResultTraders> Neartraders { get; set; }
        [JsonProperty("top_countries")] public Dictionary<string, LeaderBoardDealsClientResultTopCountries> TopCountries { get; set; }
        [JsonProperty("score")] public long Score { get; set; }
    }
}