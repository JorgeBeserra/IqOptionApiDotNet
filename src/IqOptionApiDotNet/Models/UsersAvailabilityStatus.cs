using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class UsersAvailabilityStatus
    {
        [JsonProperty("idle_duration")]
        public long IdleDuration { get; set; }

        [JsonProperty("status")]
        public string StatusStatus { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("selected_asset_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? SelectedAssetId { get; set; }

        [JsonProperty("selected_asset_type", NullValueHandling = NullValueHandling.Ignore)]
        public long? SelectedAssetType { get; set; }

        [JsonProperty("selected_instrument_type", NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedInstrumentType { get; set; }

        [JsonProperty("platform_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PlatformId { get; set; }
    }
}