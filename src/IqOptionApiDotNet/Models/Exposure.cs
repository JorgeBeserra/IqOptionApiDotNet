using IqOptionApiDotNet.Converters.JsonConverters;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class ExposureResult
    {

        [JsonProperty("instrument_type")]
        [JsonConverter(typeof(InstrumentTypeJsonConverter))]
        public InstrumentType InstrumentType { get; set; }

        [JsonProperty("active_id")] public ActivePair ActivePair { get; set; }

        [JsonProperty("call")] public decimal Call { get; set; }

        [JsonProperty("put")] public decimal Put { get; set; }

    }
}