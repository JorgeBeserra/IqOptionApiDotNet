using IqOptionApiDotNet.Converters.JsonConverters;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class InstrumentResult
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("msg")]
        public InstrumentInfo Message { get; set; }
        
        public class InstrumentInfo
        {            
            [JsonProperty("instruments")]
            public InstrumentItem[] Instruments { get; set; }
        }

        public class InstrumentItem
        {
            [JsonProperty("index")]
            public int Index { get; set; }
          
            [JsonProperty("asset_id")]
            public ActivePair AssetId { get; set; }
            
        }
    }
}