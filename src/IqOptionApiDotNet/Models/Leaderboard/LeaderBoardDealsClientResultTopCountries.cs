using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class LeaderBoardDealsClientResultTopCountries
    {
        [JsonProperty("country_id")] public long CountryId { get; set; }
        [JsonProperty("name_short")] public string NameShort { get; set; }
        [JsonProperty("profit")] public double Profit { get; set; }
    }
}