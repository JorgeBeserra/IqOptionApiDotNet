using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Utilities;
using Newtonsoft.Json;
using System;

namespace IqOptionApiDotNet.Models
{
    public partial class Alerts
    {
        [JsonProperty("records")] public Alert[] Records { get; set; }
        [JsonProperty("total")] public long Total { get; set; }
    }

    public partial class Alert
    {
        [JsonProperty("id")] public long Id { get; set; }

        [JsonProperty("user_id")] public long UserId { get; set; }

        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }

        [JsonProperty("instrument_type")] public InstrumentType InstrumentType { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("value")] public double Value { get; set; }

        [JsonProperty("activations")] public long Activations { get; set; }

        [JsonProperty("timeout")] public long Timeout { get; set; }

        [JsonProperty("deadline")] public long Deadline { get; set; }

        [JsonProperty("created_at")] public long CreatedAt { get; set; }
    }

    public partial class AlertResult
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }
        [JsonProperty("instrument_type")] public InstrumentType InstrumentType { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("value")] public long Value { get; set; }
        [JsonProperty("activations")] public long Activations { get; set; }
        [JsonProperty("timeout")] public long Timeout { get; set; }
        [JsonProperty("deadline")] public long Deadline { get; set; }
        [JsonProperty("created_at")] public long CreatedAt { get; set; }
    }

    public partial class AlertChanged
    {
        [JsonProperty("reason")] public string Reason { get; set; }
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }
        [JsonProperty("instrument_type")] public InstrumentType InstrumentType { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("value")] public long Value { get; set; }
        [JsonProperty("activations")] public long Activations { get; set; }
        [JsonProperty("timeout")] public long Timeout { get; set; }
        [JsonProperty("deadline")] public long Deadline { get; set; }
        [JsonProperty("created_at")] public long CreatedAt { get; set; }
    }

    public partial class AlertTriggered
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("timestamp")] public long Timestamp { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }
        [JsonProperty("instrument_type")] public InstrumentType InstrumentType { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("value")] public double Value { get; set; }
    }
}