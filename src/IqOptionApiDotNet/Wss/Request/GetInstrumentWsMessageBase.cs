using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;
using System;

namespace IqOptionApiDotNet.Ws.Request
{
    public class GetInstrumentMessageRequest
    {
        [JsonProperty("type")]
        public InstrumentType Type { get; set; }
    }
    
    internal sealed class GetInstrumentWsRequest : WsSendMessageBase<GetInstrumentMessageRequest>
    {
        internal GetInstrumentWsRequest(InstrumentType instrumentType)
        {

            Message = new RequestBody<GetInstrumentMessageRequest>
            {
                RequestBodyType = "get-instruments",
                Version = "4.0",
                Body = new GetInstrumentMessageRequest
                {
                    Type = instrumentType
                }
            };
        }
    }
}