using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace IqOptionApiDotNet.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyCode: int {
        [EnumMember(Value="EUR")] EUR = 1,
        [EnumMember(Value="GBP")] GBP = 2,
        [EnumMember(Value="RUB")] RUB = 4,
        [EnumMember(Value="USD")] USD = 5,
        [EnumMember(Value="BRL")] BRL = 6,
    }

    public partial class Currencies
    {
        [JsonProperty("currencies")]
        public Currency[] CurrenciesList { get; set; }
    }

    public partial class Currency
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("is_visible")]
        public bool IsVisible { get; set; }

        [JsonProperty("mask")]
        public string Mask { get; set; }

        [JsonProperty("is_tradable")]
        public bool IsTradable { get; set; }

        [JsonProperty("code")]
        public CodeUnion Code { get; set; }

        [JsonProperty("unit")]
        public long Unit { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("rate_usd")]
        public double RateUsd { get; set; }

        [JsonProperty("min_deal_amount")]
        public double MinDealAmount { get; set; }

        [JsonProperty("max_deal_amount")]
        public long MaxDealAmount { get; set; }

        [JsonProperty("minor_units")]
        public long MinorUnits { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("is_crypto")]
        public bool IsCrypto { get; set; }

        [JsonProperty("is_inout")]
        public bool IsInout { get; set; }

        [JsonProperty("interest_rate")]
        public long InterestRate { get; set; }
    }

    public enum CodeEnum { Empty, The0, The000 };

    public partial struct CodeUnion
    {
        public CodeEnum? Enum;
        public long? Integer;

        public static implicit operator CodeUnion(CodeEnum Enum) => new CodeUnion { Enum = Enum };
        public static implicit operator CodeUnion(long Integer) => new CodeUnion { Integer = Integer };
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CodeUnionConverter.Singleton,
                CodeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class CodeUnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CodeUnion) || t == typeof(CodeUnion?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    switch (stringValue)
                    {
                        case "   ":
                            return new CodeUnion { Enum = CodeEnum.Empty };
                        case "0  ":
                            return new CodeUnion { Enum = CodeEnum.The0 };
                        case "000":
                            return new CodeUnion { Enum = CodeEnum.The000 };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new CodeUnion { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type CodeUnion");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (CodeUnion)untypedValue;
            if (value.Enum != null)
            {
                switch (value.Enum)
                {
                    case CodeEnum.Empty:
                        serializer.Serialize(writer, "   ");
                        return;
                    case CodeEnum.The0:
                        serializer.Serialize(writer, "0  ");
                        return;
                    case CodeEnum.The000:
                        serializer.Serialize(writer, "000");
                        return;
                }
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type CodeUnion");
        }

        public static readonly CodeUnionConverter Singleton = new CodeUnionConverter();
    }

    internal class CodeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CodeEnum) || t == typeof(CodeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "   ":
                    return CodeEnum.Empty;
                case "0  ":
                    return CodeEnum.The0;
                case "000":
                    return CodeEnum.The000;
            }
            throw new Exception("Cannot unmarshal type CodeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CodeEnum)untypedValue;
            switch (value)
            {
                case CodeEnum.Empty:
                    serializer.Serialize(writer, "   ");
                    return;
                case CodeEnum.The0:
                    serializer.Serialize(writer, "0  ");
                    return;
                case CodeEnum.The000:
                    serializer.Serialize(writer, "000");
                    return;
            }
            throw new Exception("Cannot marshal type CodeEnum");
        }

        public static readonly CodeEnumConverter Singleton = new CodeEnumConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}