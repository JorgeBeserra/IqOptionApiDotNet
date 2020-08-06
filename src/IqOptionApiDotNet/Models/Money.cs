using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class Money
    {
        [JsonProperty("deposit")] public Deposit Deposit { get; set; }

        [JsonProperty("withdraw")] public Deposit Withdraw { get; set; }
    }
}