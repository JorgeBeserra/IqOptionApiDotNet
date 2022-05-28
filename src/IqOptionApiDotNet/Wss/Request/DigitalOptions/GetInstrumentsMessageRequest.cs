using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Wss.Request.DigitalOptions
{
    internal class GetInstrumentsRequestBody
    {
        [JsonProperty("instrument_type")]
        public string InstrumentsType { get; set; }

        [JsonProperty("asset_id")]
        public ActivePair activePair { get; set; }

    }
    
    sealed class GetInstrumentsMessageRequest : WsSendMessageBase<GetInstrumentsRequestBody>
    {
        internal GetInstrumentsMessageRequest(ActivePair activePair)
        {
            Message = new RequestBody<GetInstrumentsRequestBody>
            {
                RequestBodyType = MessageType.DigitalOptionInstrumentsGetInstruments,
                Body = new GetInstrumentsRequestBody
                {
                    InstrumentsType = "digital-option",
                    activePair =  activePair
                }
            };
        }
        
        internal GetInstrumentsMessageRequest(InstrumentType instrumentType, ActivePair activePair)
        {
            var name = "get-positions";
            if (instrumentType == InstrumentType.Forex)
                name = "trading-fx-option.get-positions";
            if (instrumentType == InstrumentType.CFD)
                name = "digital-options.get-positions";
            
            Message = new RequestBody<GetInstrumentsRequestBody>
            {
                RequestBodyType = "digital-options.get-positions",
                Body = new GetInstrumentsRequestBody
                {
                    InstrumentsType = name,
                    activePair = activePair
                }
            };
        }
    }
    
}