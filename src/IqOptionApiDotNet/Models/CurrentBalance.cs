using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class Balance
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("type")] public BalanceType Type { get; set; }
        [JsonProperty("amount")] public decimal Amount { get; set; }
        [JsonProperty("enrolled_amount")] public double EnrolledAmount { get; set; }
        [JsonProperty("enrolled_sum_amount")] public double EnrolledSumAmount { get; set; }
        [JsonProperty("hold_amount")] public double HoldAmount { get; set; }
        [JsonProperty("orders_amount")] public double OrdersAmount { get; set; }
        [JsonProperty("currency")] public string Currency { get; set; }
        //[JsonProperty("tournament_id")] public long TournamentId { get; set; }
        //[JsonProperty("tournament_name")] public string TournamentName { get; set; }
        [JsonProperty("is_fiat")] public bool IsFiat { get; set; }
        [JsonProperty("is_marginal")] public bool IsMarginal { get; set; }
        [JsonProperty("has_deposits")] public bool HasDeposits { get; set; }
        [JsonProperty("auth_amount")] public double AuthAmount { get; set; }
        [JsonProperty("equivalent")] public double Equivalent { get; set; }

        // Variables removed from iq

        //[JsonProperty("index")] public long Index { get; set; }
        //[JsonProperty("new_amount")] public decimal NewAmount { get; set; }
        //[JsonProperty("bonus_amount")] public long BonusAmount { get; set; }
        //[JsonProperty("bonus_total_amount")] public long BonusTotalAmount { get; set; }
        //[JsonProperty("balances")] public Balance[] Balances { get; set; }
        //[JsonProperty("description")] public object Description { get; set; }
    }
}