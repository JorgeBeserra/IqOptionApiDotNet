using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace IqOptionApiDotNet.Models
{
    public partial class TopAssetsUpdated
    {
        [JsonProperty("instrument_type")]
        public string InstrumentType { get; set; }

        [JsonProperty("data")]
        public DatumUpdated[] Data { get; set; }
    }

    public partial class DatumUpdated
    {
        [JsonProperty("active_id")]
        public long ActiveId { get; set; }

        [JsonProperty("spread")]
        public CurPriceUpdated Spread { get; set; }

        [JsonProperty("diff_1h")]
        public CurPriceUpdated Diff1H { get; set; }

        [JsonProperty("diff_trading_day")]
        public CurPriceUpdated DiffTradingDay { get; set; }

        [JsonProperty("prev_price")]
        public CurPriceUpdated PrevPrice { get; set; }

        [JsonProperty("cur_price")]
        public CurPriceUpdated CurPrice { get; set; }

        [JsonProperty("volatility")]
        public CurPriceUpdated Volatility { get; set; }

        [JsonProperty("volume")]
        public CurPriceUpdated Volume { get; set; }

        [JsonProperty("popularity")]
        public CurPriceUpdated Popularity { get; set; }

        [JsonProperty("expiration")]
        public CurPriceUpdated Expiration { get; set; }

        [JsonProperty("spot_profit")]
        public CurPriceUpdated SpotProfit { get; set; }
    }

    public partial class CurPriceUpdated
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("is_valid")]
        public bool IsValid { get; set; }
    }
}