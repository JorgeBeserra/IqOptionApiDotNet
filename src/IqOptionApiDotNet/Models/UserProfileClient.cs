using System;
using IqOptionApiDotNet.Converters.JsonConverters;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class UserProfileClientResult
    {
        [JsonProperty("balances")] public object[] Balances { get; set; }
        [JsonProperty("client_category_id")] public long ClientCategoryId { get; set; }
        [JsonProperty("country_id")] public long CountryId { get; set; }
        [JsonProperty("flag")] public string Flag { get; set; }
        [JsonProperty("img_url")] public string ImgUrl { get; set; }
        [JsonProperty("is_demo_account")] public bool IsDemoAccount { get; set; }
        [JsonProperty("is_vip")] public bool IsVip { get; set; }
        [JsonProperty("vip_badge")] public bool VipBadge { get; set; }
        [JsonProperty("isSuccessful")] public bool IsSuccessful { get; set; }

        [JsonProperty("registration_time")]
        [JsonConverter(typeof(UnixSecondsDateTimeJsonConverter))] public DateTimeOffset RegistrationTime { get; set; }
        [JsonProperty("selected_asset_id")] public long SelectedAssetId { get; set; }
        [JsonProperty("selected_balance_type")] public long SelectedBalanceType { get; set; }
        [JsonProperty("selected_option_type")] public long SelectedOptionType { get; set; }
        [JsonProperty("user_id")] public long UserId { get; set; }
        [JsonProperty("user_name")] public string UserName { get; set; }
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("gender")] public string Gender { get; set; }

    }
}