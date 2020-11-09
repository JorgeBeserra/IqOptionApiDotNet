using System;
using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    internal class GetExposureModel
    {
        [JsonProperty("instrument_type")]
        [JsonConverter(typeof(InstrumentTypeJsonConverter))]
        public InstrumentType InstrumentType { get; set; }

        [JsonProperty("active_id")] public long ActiveId { get; set; }

        [JsonProperty("time")]
        [JsonConverter(typeof(UnixSecondsDateTimeJsonConverter))]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("currency")] public CurrencyCode Currency { get; set; }
    }

    internal sealed class GetExposureRequestMessage : WsSendMessageBase<GetExposureModel>
    {
        public GetExposureRequestMessage(InstrumentType instrumentType, ActivePair activeId, CurrencyCode currency, DateTimeOffset time)
        {
            if (time.Second % 60 != 0)
            {
                time = time.AddSeconds(60 - time.Second);
            }

            Message = new RequestBody<GetExposureModel>
            {
                RequestBodyType = RequestMessageBodyType.GetActiveExposure,
                Body = new GetExposureModel
                {
                    InstrumentType = instrumentType,
                    ActiveId = (int)activeId,
                    Time = time,
                    Currency = currency,
                }
            };
        }
    }
}