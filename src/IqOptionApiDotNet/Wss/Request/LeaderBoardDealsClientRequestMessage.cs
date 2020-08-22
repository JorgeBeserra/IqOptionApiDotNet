using System;
using System.Linq;
using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    internal class LeaderBoardDealsClientModel
    {
        [JsonProperty("country_id")] public CountryType CountryId { get; set; }
        [JsonProperty("user_country_id")] public CountryType UserCountryId { get; set; }
        [JsonProperty("from_position")] public long FromPosition { get; set; }
        [JsonProperty("to_position")] public long ToPosition { get; set; }
        [JsonProperty("near_traders_country_count")] public long NearTradersCountryCount { get; set; }
        [JsonProperty("near_traders_count")] public long NearTradersCount { get; set; }
        [JsonProperty("top_country_count")] public long TopCountryCount { get; set; }
        [JsonProperty("top_count")] public long TopCount { get; set; }
        [JsonProperty("top_type")] public long TopType { get; set; }
    }

    
    internal sealed class LeaderBoardDealsClientRequestMessage : WsSendMessageBase<LeaderBoardDealsClientModel>
    {
        public LeaderBoardDealsClientRequestMessage(
            CountryType countryId,
            CountryType userCountryId,
            long fromPosition,
            long toPosition,
            long nearTradersCountryCount,
            long nearTradersCount,
            long topCountryCount,
            long topCount,
            long topType)
        {
            Message = new RequestBody<LeaderBoardDealsClientModel>
            {
                RequestBodyType = RequestMessageBodyType.RequestLeaderboardDealsClient,
                Body = new LeaderBoardDealsClientModel
                {
                    CountryId = countryId,
                    UserCountryId = userCountryId,
                    FromPosition = fromPosition,
                    ToPosition = toPosition,
                    NearTradersCountryCount = nearTradersCountryCount,
                    NearTradersCount = nearTradersCount,
                    TopCountryCount = topCountryCount,
                    TopCount = topCount,
                    TopType = topType
                }   
            };
        }
    }
}