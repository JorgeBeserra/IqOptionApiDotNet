namespace IqOptionApiDotNet.Ws.Base
{
    public struct MessageType
    {
        public const string Front = "front";
        public const string InitializationData = "initialization-data";
        public const string Profile = "profile";
        public const string ProfileChanged = "profile-changed";
        public const string Heartbeat = "heartbeat";
        public const string SendMessage = "sendMessage";
        public const string TimeSync = "timeSync";
        public const string TopAssets = "top-assets";
        public const string TopAssetsUpdated = "top-assets-updated";
        public const string OptionOpened = "option-opened";
        public const string OptionClosed = "option-closed";
        public const string OptionArchived = "option-archived";
        public const string SocketOptionOpened = "socket-option-opened";
        public const string SubscribeOrderChanged = "order-changed";
        public const string SubscribePortfolioChanged = "position-changed";
        public const string TraderMoodChanged = "traders-mood-changed";
        public const string SubscribeMessage = "subscribeMessage";
        public const string UnsubscribeMessage = "unsubscribeMessage";
        public const string UserTournamentPositionChanged = "user-tournament-position-changed";
        public const string Getinstruments = "get-instruments";
        public const string Ssid = "ssid";
        public const string Balances = "balances";
        public const string BalanceChanged = "balance-changed";
        public const string Candles = "candles";
        public const string Quotes = "candle-generated";
        public const string Exposure = "active-exposure";
        public const string PlacedDigitalOptions = "digital-option-placed";
        public const string PlacedBinaryOptions = "option";
        public const string LiveDealDigitalOption = "live-deal-digital-option";
        public const string LiveDealBinaryOption = "live-deal-binary-option-placed";
        public const string UserProfileClient = "user-profile-client";
        public const string UsersAvailability = "users-availability";
        public const string LeaderboardDealsClient = "leaderboard-deals-client";
        public const string LeaderboardUserinfoDealsClient = "leaderboard-userinfo-deals-client";
        public const string FinancialInformation = "financial-information";
        public const string TrainingBalanceReset = "training-balance-reset";
        public const string Alerts = "alerts";
        public const string Alert = "alert";
        public const string AlertChanged = "alert-changed";
        public const string AlertTriggered = "alert-triggered";        
    }
}