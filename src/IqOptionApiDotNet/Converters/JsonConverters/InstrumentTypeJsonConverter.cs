﻿using System;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Converters.JsonConverters
{
    public sealed class InstrumentTypeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer)
        {
            var value = (string) reader.Value;

            switch (value)
            {
                case "forex":
                    return InstrumentType.Forex;
                case "cfd":
                    return InstrumentType.CFD;
                case "crypto":
                    return InstrumentType.Crypto;
                case "turbo-option":
                    return InstrumentType.TurboOption;
                case "binary-option":
                    return InstrumentType.BinaryOption;
                default:
                    return InstrumentType.Unknown;
            }
        }

        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            switch (value)
            {
                case InstrumentType.Forex:
                    writer.WriteValue("forex");
                    break;
                case InstrumentType.CFD:
                    writer.WriteValue("cfd");
                    break;
                case InstrumentType.Crypto:
                    writer.WriteValue("crypto");
                    break;
                case InstrumentType.TurboOption:
                    writer.WriteValue("turbo-option");
                    break;
                case InstrumentType.BinaryOption:
                    writer.WriteValue("binary-option");
                    break;
                default:
                    writer.WriteValue("");
                    break;
            }
        }
    }
}