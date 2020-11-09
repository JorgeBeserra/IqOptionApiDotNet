using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class InitializationData
    {

        public class InstrumentData
        {

            public class ActiveData
            {

                public class OptionData
                {

                    public class ProfitData
                    {

                        [JsonProperty("commission")] public double Commission { get; set; }

                    }

                    [JsonProperty("profit")] public ProfitData Profit { get; set; }

                }

                [JsonProperty("id")] public int Id { get; set; }

                [JsonProperty("option")] public OptionData Option { get; set; }

            }

            [JsonProperty("actives"), JsonConverter(typeof(ActivesConverter))]
            public Dictionary<ActivePair, ActiveData> Actives { get; set; }

            internal class ActivesConverter : JsonConverter<Dictionary<ActivePair, ActiveData>>
            {

                public override Dictionary<ActivePair, ActiveData> ReadJson(JsonReader reader, Type objectType, Dictionary<ActivePair, ActiveData> existingValue, bool hasExistingValue, JsonSerializer serializer)
                {
                    var dict = serializer.Deserialize<Dictionary<String, ActiveData>>(reader);
                    var values = (int[])typeof(ActivePair).GetEnumValues();
                    return dict.Values.Where(d => values.Contains(d.Id)).ToDictionary(i => (ActivePair)i.Id);
                }

                public override void WriteJson(JsonWriter writer, Dictionary<ActivePair, ActiveData> value, JsonSerializer serializer)
                {
                    throw new NotImplementedException();
                }

            }

        }

        [JsonProperty("binary")] public InstrumentData BinaryOption { get; set; }

        [JsonProperty("turbo")] public InstrumentData TurboOption { get; set; }

    }
}