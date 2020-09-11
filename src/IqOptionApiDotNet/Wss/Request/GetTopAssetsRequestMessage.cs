using System;
using System.Linq;
using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    internal class GetTopAssetsModel
    {
        [JsonProperty("instrument_type")] public InstrumentType InstrumentType { get; set; }
    }
    
    internal sealed class GetTopAssetsRequestMessage : WsSendMessageBase<GetTopAssetsModel>
    {
        public GetTopAssetsRequestMessage(InstrumentType instrumentType)
        {
            Message = new RequestBody<GetTopAssetsModel>
            {
                RequestBodyType = RequestMessageBodyType.GetTopAssets,
                Version = "1.2",
                Body = new GetTopAssetsModel
                {
                    InstrumentType = instrumentType
                }
            };
        }
    }
}