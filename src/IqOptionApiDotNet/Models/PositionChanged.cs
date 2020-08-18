using System;
using System.Collections;
using IqOptionApiDotNet.Converters.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IqOptionApiDotNet.Models
{
    public class PositionChanged : IEqualityComparer
    {
        [JsonProperty("version")] public long Version { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("user_balance_id")] public long UserBalanceId { get; set; }
        [JsonProperty("platform_id")] public long PlataformId { get; set; }
        [JsonProperty("external_id")] public long ExternalId { get; set; }
        [JsonProperty("active_id")] public ActivePair ActivePair { get; set; }
        [JsonProperty("instrument_id")] public string InstrumentId { get; set; }
        [JsonProperty("source")] public string Source { get; set; }
        [JsonProperty("instrument_type")] 
        [JsonConverter(typeof(StringEnumConverter))]
        public InstrumentType InstrumentType { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("open_quote")] public double OpenQuote { get; set; }
        [JsonProperty("invest")] public double InvestAmount { get; set; }
        [JsonProperty("invest_enrolled")] public double InvestEnrolled { get; set; }
        [JsonProperty("pnl")] public double Pnl { get; set; }
        [JsonProperty("pnl_realized")] public double PnlRealized { get; set; }
        [JsonProperty("pnl_net")] public double PnlNet { get; set; }
        [JsonProperty("raw_event")] public PortfolioChangedEventInfo PortfolioChangedEventInfo { get; set; }


        public new bool Equals(object x, object y)
        {
            return x == y;
        }

        public int GetHashCode(object obj)
        {
            return obj.GetHashCode();
        }
    }

    public class PortfolioChangedEventInfo
    {
        [JsonProperty("order_ids")]
        public long[] OrderIds { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("user_balance_id")]
        public long UserBalanceId { get; set; }
        
        [JsonProperty("user_id")]
        public long UserId { get; set; }
        
        [JsonProperty("version")]
        public long Version { get; set; }
    }
}