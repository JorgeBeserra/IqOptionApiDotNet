using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Request.Portfolio
{
    // {"name":"subscribeMessage","request_id":"s_418","msg":{"name":"top-assets-updated","version":"1.2","params":{"routingFilters":{"instrument_type":"digital-option"}}}}
    internal class SubscribeTopAssetsUpdatedRequestBody
    {
        [JsonProperty("name")] public string Name { get; set; } = RequestMessageBodyType.TopAssetsUpdate;

        [JsonProperty("params")] public InstrumentRoutingFilterParameters Parameters { get; set; }

        [JsonProperty("version")] public string Version { get; set; } = "1.2";

        internal class InstrumentRoutingFilterParameters
        {
            [JsonProperty("routingFilters")] public RequestFilter Filter { get; set; }

            internal class RequestFilter
            {
                [JsonProperty("instrument_type")] public string InstrumentType { get; set; }
            }
        }
    }

    internal class SubscribeTopAssetsUpdatedRequest : WsMessageBase<SubscribeTopAssetsUpdatedRequestBody>
    {
        public override string Name => MessageType.SubscribeMessage;
        
        public SubscribeTopAssetsUpdatedRequest(InstrumentType instrumentType)
        {
            var instrumentTypeName = "";
            if (instrumentType == InstrumentType.Forex)
                instrumentTypeName = "forex";
            else if (instrumentType == InstrumentType.CFD)
                instrumentTypeName = "cfd";
            else if (instrumentType == InstrumentType.Crypto)
                instrumentTypeName = "crypto";
            else if (instrumentType == InstrumentType.DigitalOption)
                instrumentTypeName = "digital-option";
            else if (instrumentType == InstrumentType.BinaryOption)
                instrumentTypeName = "binary-option";
            else if (instrumentType == InstrumentType.TurboOption)
                instrumentTypeName = "turbo-option";
            else if (instrumentType == InstrumentType.FxOption)
                instrumentTypeName = "fx-option";
            else
                return;
            
            //msg
            base.Message = new SubscribeTopAssetsUpdatedRequestBody
            {
                // name
                Name = RequestMessageBodyType.TopAssetsUpdate,
                //version
                Version = "1.2",
                //params
                Parameters = new SubscribeTopAssetsUpdatedRequestBody.InstrumentRoutingFilterParameters
                {
                    //routingFilters
                    Filter = new SubscribeTopAssetsUpdatedRequestBody.InstrumentRoutingFilterParameters.RequestFilter
                    {
                        //instrument_type
                        InstrumentType = instrumentTypeName
                    }
                }
            };
        }
    }
}
    