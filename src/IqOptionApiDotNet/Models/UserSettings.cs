using System;
using IqOptionApiDotNet.Converters.JsonConverters;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public class UserSettings
    {
        [JsonProperty("configs")] public UserSettingsConfigs[] Configs { get; set; }

    }

    public class UserSettingsConfigs
    {
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("version")] public int Version { get; set; }
        [JsonProperty("config")] public UserSettingsParams Config { get; set; }

    }

    public class UserSettingsParams
    {
        [JsonProperty("balanceId")] public long balanceId { get; set; }
        [JsonProperty("theme")] public string Theme { get; set; }
        [JsonProperty("isSoundDisabled")] public bool IsSoundDisabled { get; set; }
        [JsonProperty("openedLeftPanelSections")] public string OpenedLeftPanelSections { get; set; }
        [JsonProperty("isPosDashedLineVisible")] public bool isPosDashedLineVisible { get; set; } 
        [JsonProperty("notAutoSelectClosestStrike")] public bool notAutoSelectClosestStrike { get; set; } 
        [JsonProperty("isNewOptionInCurrentTab")] public bool isNewOptionInCurrentTab { get; set; } 
        [JsonProperty("isShowClosedDealPopup")] public bool isShowClosedDealPopup { get; set; }
        [JsonProperty("isShowPendingOption")] public bool isShowPendingOption { get; set; }
        [JsonProperty("isHideBalance")] public bool isHideBalance { get; set; }
        [JsonProperty("isShowBidAskOnPlot")] public bool isShowBidAskOnPlot { get; set; }
        [JsonProperty("isShowBgMap")] public bool isShowBgMap { get; set; }
        [JsonProperty("isShowDottedOptionLine")] public bool isShowDottedOptionLine { get; set; }
        [JsonProperty("isHideChangePositionNotification")] public bool isHideChangePositionNotification { get; set; }
        [JsonProperty("isShowOptionAmountOnPlot")] public bool isShowOptionAmountOnPlot { get; set; }
        [JsonProperty("notHideAllStrike")] public bool notHideAllStrike { get; set; }
    }
}