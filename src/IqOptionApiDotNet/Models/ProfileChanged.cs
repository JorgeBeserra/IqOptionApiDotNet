using System;
using System.Runtime.Serialization;
using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Http;
using System.Globalization;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IqOptionApiDotNet.Models
{
    public class ProfileChanged : IHttpResultMessage
    {
        [JsonProperty("account_satus")] public string AccountStatus { get; set; }
        [JsonProperty("address")] public string Address { get; set; }
        [JsonProperty("auth_two_factor")] public object AuthTwoFactor { get; set; }
        [JsonProperty("avatar")] public string Avatar { get; set; }
        [JsonProperty("balance")] public decimal Balance { get; set; }
        [JsonProperty("balance_id")] public long BalanceId { get; set; }
        [JsonProperty("balance_type")] public BalanceType BalanceType { get; set; }
        [JsonProperty("balances")] public Balance[] Balances { get; set; }
        [JsonProperty("birthdate")] public long Birthdate { get; set; }
        [JsonProperty("bonus_total_wager")] public long BonusTotalWager { get; set; }
        [JsonProperty("bonus_wager")] public long BonusWager { get; set; }
        [JsonProperty("cashback_level_info")] public CashbackLevelInfo CashbackLevelInfo { get; set; }
        [JsonProperty("city")] public string City { get; set; }
        [JsonProperty("client_category_id")] public long ClientCategoryId { get; set; }
        [JsonProperty("company_id")] public long CompanyId { get; set; }
        [JsonProperty("confirmation_required")] public long ConfirmationRequired { get; set; }
        [JsonProperty("confirmed_phones")] public object[] ConfirmedPhones { get; set; }
        [JsonProperty("country_id")] public long CountryId { get; set; }
        [JsonProperty("created")] public long Created { get; set; }
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
        [JsonProperty("forget_status")] public ForgetStatus ForgetStatus { get; set; }
        [JsonProperty("functions")] public object[] Functions { get; set; }
        [JsonProperty("gender")] public string Gender { get; set; }
        [JsonProperty("group_id")] public long GroupId { get; set; }
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("infeed")] public long Infeed { get; set; }
        [JsonProperty("is_activated")] public bool IsActivated { get; set; }
        [JsonProperty("is_islamic")] public bool IsIslamic { get; set; }
        [JsonProperty("is_vip_group")] public bool IsVipGroup { get; set; }
        [JsonProperty("kyc")] public Kyc Kyc { get; set; }
        [JsonProperty("kyc_confirmed")] public bool KycConfirmed { get; set; }
        [JsonProperty("last_name")] public string LastName { get; set; }
        [JsonProperty("last_visit")] public bool LastVisit { get; set; }
        [JsonProperty("locale")] public string Locale { get; set; }
        [JsonProperty("mask")] public string Mask { get; set; }
        [JsonProperty("messages")] public long Messages { get; set; }
        [JsonProperty("money")] public Money Money { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("need_phone_confirmation")] public bool NeedPhoneConfirmation { get; set; }
        [JsonProperty("new_email")] public string NewEmail { get; set; }
        [JsonProperty("nickname")] public string Nickname { get; set; }
        [JsonProperty("personal_data_policy")] public PersonalDataPolicy PersonalDataPolicy { get; set; }
        [JsonProperty("phone")] public string Phone { get; set; }
        [JsonProperty("popup")] public object[] Popup { get; set; }
        [JsonProperty("postal_index")] public string PostalIndex { get; set; }
        [JsonProperty("public")] public long Public { get; set; }
        [JsonProperty("rate_in_one_click")] public bool RateInOneClick { get; set; }
        [JsonProperty("site_id")] public long SiteId { get; set; }
        [JsonProperty("skey")] public string Skey { get; set; }
        [JsonProperty("socials")] public Socials Socials { get; set; }
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

    public partial class ForgetStatus
    {
        [JsonProperty("status")] public string Status { get; set; }
        [JsonProperty("created")] public object Created { get; set; }
        [JsonProperty("expires")] public object Expires { get; set; }
    }

    public partial class Kyc
    {
        [JsonProperty("status")] public long Status { get; set; }
        [JsonProperty("isPhoneFilled")] public bool IsPhoneFilled { get; set; }
        [JsonProperty("isPhoneNeeded")] public bool IsPhoneNeeded { get; set; }
        [JsonProperty("isProfileFilled")] public bool IsProfileFilled { get; set; }
        [JsonProperty("isProfileNeeded")] public bool IsProfileNeeded { get; set; }
        [JsonProperty("isRegulatedUser")] public bool IsRegulatedUser { get; set; }
        [JsonProperty("daysLeftToVerify")] public long DaysLeftToVerify { get; set; }
        [JsonProperty("isPhoneConfirmed")] public bool IsPhoneConfirmed { get; set; }
        [JsonProperty("isDocumentsNeeded")] public bool IsDocumentsNeeded { get; set; }
        [JsonProperty("isDocumentsApproved")] public bool IsDocumentsApproved { get; set; }
        [JsonProperty("isDocumentsDeclined")] public bool IsDocumentsDeclined { get; set; }
        [JsonProperty("isDocumentsUploaded")] public bool IsDocumentsUploaded { get; set; }
        [JsonProperty("isDocumentPoaUploaded")] public bool IsDocumentPoaUploaded { get; set; }
        [JsonProperty("isDocumentPoiUploaded")] public bool IsDocumentPoiUploaded { get; set; }
        [JsonProperty("isDocumentsUploadSkipped")] public bool IsDocumentsUploadSkipped { get; set; }
        [JsonProperty("isPhoneConfirmationSkipped")] public bool IsPhoneConfirmationSkipped { get; set; }
    }

    public partial class CashbackLevelInfo
    {
        [JsonProperty("enabled")] public bool Enabled { get; set; }
    }

    public partial class PersonalDataPolicy
    {
        [JsonProperty("is_call_accepted")] public IsAccepted IsCallAccepted { get; set; }
        [JsonProperty("is_push_accepted")] public IsAccepted IsPushAccepted { get; set; }
        [JsonProperty("is_email_accepted")] public IsAccepted IsEmailAccepted { get; set; }
        [JsonProperty("is_agreement_accepted")] public IsAccepted IsAgreementAccepted { get; set; }
        [JsonProperty("is_thirdparty_accepted")] public IsAccepted IsThirdpartyAccepted { get; set; }
    }

    public partial class IsAccepted
    {
        [JsonProperty("status")] public bool Status { get; set; }
    }
}