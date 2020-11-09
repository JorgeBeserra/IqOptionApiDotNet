namespace IqOptionApiDotNet.Ws.Request
{
    public struct RequestMessageBodyType
    {
        public const string GetCandles = "get-candles";

        public const string GetPosition = "get-position";

        public const string GetFeatures = "get-features";

        public const string GetPositionHistory = "get-position-history";

        public const string OpenOptions = "binary-options.open-option";

        public const string GetUserSetting = "get-user-settings";

        public const string CoreChangeLanguage = "core.change-lang";

        public const string GetUserProfileClient = "get-user-profile-client";

        public const string GetUsersAvailability = "get-users-availability";

        public const string GetCurrency = "get-currency";

        public const string GetCurrenciesList = "get-currencies-list";

        public const string GetSubscriptions = "get-subscriptions";  

        public const string GetFinancialInformation = "get-financial-information";

        public const string GetDeferredOrders = "get-deferred-orders";

        public const string GetAvailableLeverages = "get-available-leverages";

        public const string GetInstruments = "get-instruments";

        public const string GetTopAssets = "get-top-assets";

        public const string GetActiveExposure = "get-active-exposure";
      
        public const string GetInitializationData = "get-initialization-data";

        public const string TopAssetsUpdate = "top-assets-update";

        public const string RequestLeaderboardDealsClient = "request-leaderboard-deals-client";

        public const string RequestLeaderboardUserinfoDealsClient = "request-leaderboard-userinfo-deals-client";

        public const string GetBalances = "get-balances";

        public const string ResetTrainingBalance = "reset-training-balance";

        public const string GetAlerts = "get-alerts";

        public const string CreateAlert = "create-alert";

        public const string UpdateAlert = "update-alert";

        public const string DeleteAlert = "delete-alert";

        public const string SubscribeAlertChanged = "alert-changed";

        public const string SubscribeAlertTriggered = "alert-triggered";

        public const string PortfolioGetHistoryPositions = "portfolio.get-history-positions";

        public const string RequestChatMessage = "request-chat-message";

        public const string SendChatMessage = "send-chat-message";

        public const string ReadChatMessage = "read-chat-message";

        public const string LikeChatMessage = "like-chat-message";

        public const string GetNewsFeedAlltime = "get-news-feed-alltime";
        
    }
}