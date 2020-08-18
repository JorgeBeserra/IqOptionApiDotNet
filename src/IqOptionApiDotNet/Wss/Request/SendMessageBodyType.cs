namespace IqOptionApiDotNet.Ws.Request
{
    public struct RequestMessageBodyType
    {
        public const string GetCandles = "get-candles";

        public const string GetPosition = "get-position";

        public const string GetPositionHistory = "get-position-history";

        public const string OpenOptions = "binary-options.open-option";
		
        public const string GetUserProfileClient = "get-user-profile-client";

        public const string GetUsersAvailability = "get-users-availability";

        public const string GetFinancialInformation = "get-financial-information";

        public const string GetDeferredOrders = "get-deferred-orders";

        public const string GetAvailableLeverages = "get-available-leverages";

        public const string GetInstruments = "get-instruments";

        public const string RequestLeaderboardDealsClient = "request-leaderboard-deals-client";

        public const string RequestLeaderboardUserinfoDealsClient = "request-leaderboard-userinfo-deals-client";

    }
}