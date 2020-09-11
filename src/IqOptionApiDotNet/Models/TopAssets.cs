using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace IqOptionApiDotNet.Models
{
    public partial class TopAssets
    {
        [JsonProperty("instrument_type")]
        public string InstrumentType { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("active_id")]
        public long ActiveId { get; set; }

        [JsonProperty("spread")]
        public CurPrice Spread { get; set; }

        [JsonProperty("diff_1h")]
        public CurPrice Diff1H { get; set; }

        [JsonProperty("diff_trading_day")]
        public CurPrice DiffTradingDay { get; set; }

        [JsonProperty("prev_price")]
        public CurPrice PrevPrice { get; set; }

        [JsonProperty("cur_price")]
        public CurPrice CurPrice { get; set; }

        [JsonProperty("volatility")]
        public CurPrice Volatility { get; set; }

        [JsonProperty("volume")]
        public CurPrice Volume { get; set; }

        [JsonProperty("popularity")]
        public CurPrice Popularity { get; set; }

        [JsonProperty("expiration")]
        public CurPrice Expiration { get; set; }

        [JsonProperty("spot_profit")]
        public CurPrice SpotProfit { get; set; }
    }

    public partial class CurPrice
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
    }
}