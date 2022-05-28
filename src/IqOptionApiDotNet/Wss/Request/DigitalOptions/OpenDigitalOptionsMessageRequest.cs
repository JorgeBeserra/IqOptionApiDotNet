using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Wss.Request.DigitalOptions
{
    internal class OpenDigitalOptionsBody
    {

        [JsonProperty("user_balance_id")]
        public int UserBalanceId { get; set; }

        [JsonProperty("instrument_id")]
        public string InstrumentId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("instrument_index")]
        public int InstrumentIndex { get; set; }

        [JsonProperty("asset_id")]
        public ActivePair AssetId { get; set; }
        
        /*
        [JsonProperty("instrument_underlying")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivePair Instrument { get; set; }
        */

    }
    
    internal sealed class PlaceDigitalOptionsMessageRequest : WsSendMessageBase<OpenDigitalOptionsBody>
    {
        ActivePair _activePair;
        internal PlaceDigitalOptionsMessageRequest(DigitalOptionsIdentifier positionIdentifier, int userbalanceId,
            double amount)
            : this(positionIdentifier.CreateInstrumentId(), userbalanceId, amount)
        {
            this._activePair = positionIdentifier.Pair;
        }

        internal PlaceDigitalOptionsMessageRequest(string positionIdentifier, int userbalanceId, double amount)
        {
            Message = new RequestBody<OpenDigitalOptionsBody>
            {
                Version = "2.0",
                RequestBodyType = "digital-options.place-digital-option",
                Body = new OpenDigitalOptionsBody
                {
                    UserBalanceId = userbalanceId,
                    InstrumentId = positionIdentifier,
                    Amount = amount.ToString(),
                    InstrumentIndex = 797064,
                    AssetId = _activePair,
                }
            };
        }
    }
}