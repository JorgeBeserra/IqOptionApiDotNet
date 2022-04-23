using System;
using System.Runtime.Serialization;
using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Http;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public enum BalanceType
    {
        [EnumMember(Value = "0")] SemDefinicao = 0,
        [EnumMember(Value = "1")] Real = 1,
        [EnumMember(Value = "4")] Practice = 4,
        [EnumMember(Value = "5")] RealOption = 5,
        Unknow
    }

    public class Profile : IHttpResultMessage
    {
        [JsonProperty("result")]
        public ProfileResult profileResult { get; set; }
        public class ProfileResult
        {
            [JsonProperty("account_satus")] public string AccountStatus { get; set; }
            [JsonProperty("address")] public string Address { get; set; }
            [JsonProperty("auth_two_factor")] public object AuthTwoFactor { get; set; }
            [JsonProperty("avatar")] public string Avatar { get; set; }
            [JsonProperty("balance")] public decimal Balance { get; set; }
            [JsonProperty("balance_id")] public long BalanceId { get; set; }
            [JsonProperty("balance_type")] public BalanceType BalanceType { get; set; }
            [JsonProperty("balances")] public Balance[] Balances { get; set; }
            [JsonProperty("birthdate")] public bool Birthdate { get; set; }
            [JsonProperty("bonus_total_wager")] public long BonusTotalWager { get; set; }
            [JsonProperty("bonus_wager")] public long BonusWager { get; set; }
            [JsonProperty("cashback_level_info")] public CashbackLevelInfo CashbackLevelInfo { get; set; }
            [JsonProperty("city")] public string City { get; set; }
            [JsonProperty("client_category_id")] public long ClientCategoryId { get; set; }
            [JsonProperty("company_id")] public long CompanyId { get; set; }
            [JsonProperty("confirmation_required")] public long ConfirmationRequired { get; set; }
            [JsonProperty("confirmed_phones")] public object[] ConfirmedPhones { get; set; }
            [JsonProperty("country_id")] public long CountryId { get; set; }
            [JsonProperty("created")]
            [JsonConverter(typeof(UnixDateTimeJsonConverter))]
            public DateTimeOffset? Created { get; set; }
            [JsonProperty("currency")] public string Currency { get; set; }
            [JsonProperty("currency_char")] public string CurrencyChar { get; set; }
            [JsonProperty("currency_id")] public long CurrencyId { get; set; }
            [JsonProperty("demo")] public long Demo { get; set; }
            [JsonProperty("deposit_count")] public long DepositCount { get; set; }
            [JsonProperty("deposit_in_one_click")] public bool DepositInOneClick { get; set; }
            [JsonProperty("email")] public string Email { get; set; }
            [JsonProperty("finance_state")] public string FinanceState { get; set; }
            [JsonProperty("first_name")] public string FirstName { get; set; }
            [JsonProperty("flag")] public string Flag { get; set; }
            //[JsonProperty("forget_status")] public ForgetStatus { get; set; }
            //[JsonProperty("functions")] public Functions Functions { get; set; }
            [JsonProperty("gender")] public string Gender { get; set; }
            [JsonProperty("group_id")] public long GroupId { get; set; }
            [JsonProperty("id")] public long Id { get; set; }
            [JsonProperty("infeed")] public long Infeed { get; set; }
            [JsonProperty("is_activated")] public bool IsActivated { get; set; }
            [JsonProperty("is_islamic")] public bool IsIslamic { get; set; }
            [JsonProperty("is_vip_group")] public bool IsVipGroup { get; set; }
            [JsonProperty("last_name")] public string LastName { get; set; }
            [JsonProperty("last_visit")] public bool LastVisit { get; set; }
            [JsonProperty("locale")] public string Locale { get; set; }
            [JsonProperty("mask")] public string Mask { get; set; }
            [JsonProperty("messages")] public long Messages { get; set; }
            [JsonProperty("money")] public Money Money { get; set; }
            [JsonProperty("name")] public string Name { get; set; }
            [JsonProperty("nationality")] public string Nationality { get; set; }
            [JsonProperty("need_phone_confirmation")] public bool? NeedPhoneConfirmation { get; set; }
            [JsonProperty("new_email")] public string NewEmail { get; set; }
            [JsonProperty("nickname")] public object Nickname { get; set; }
            //[JsonProperty("personal_data_policy")] public string PersonalDataPolicy { get; set; }
            [JsonProperty("phone")] public string Phone { get; set; }
            //[JsonProperty("popup")] public Popup Popup { get; set; }
            [JsonProperty("postal_index")] public string PostalIndex { get; set; }
            [JsonProperty("public")] public long Public { get; set; }
            [JsonProperty("rate_in_one_click")] public bool RateInOneClick { get; set; }
            [JsonProperty("site_id")] public long SiteId { get; set; }
            [JsonProperty("skey")] public string Skey { get; set; }
            //[JsonProperty("socials")] public Socials Socials { get; set; }
            [JsonProperty("ssid")] public bool Ssid { get; set; }
            [JsonProperty("tc")] public bool Tc { get; set; }
            [JsonProperty("timediff")] public long Timediff { get; set; }
            [JsonProperty("tin")] public string Tin { get; set; }
            [JsonProperty("tournaments_ids")] public object[] TournamentsIds { get; set; }
            [JsonProperty("trade_restricted")] public bool TradeRestricted { get; set; }
            [JsonProperty("trial")] public bool Trial { get; set; }
            [JsonProperty("tz")] public string Tz { get; set; }
            [JsonProperty("tz_offset")] public long TzOffset { get; set; }
            [JsonProperty("user_circle")] public string UserCircle { get; set; }
            [JsonProperty("user_group")] public string UserGroup { get; set; }
            [JsonProperty("user_id")] public long UserId { get; set; }
            [JsonProperty("welcome_splash")] public long WelcomeSplash { get; set; }
        }
    }
}