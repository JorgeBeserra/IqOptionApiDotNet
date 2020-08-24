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
    internal class LeaderBoardUserinfoDealsClientModel
    {
        [JsonProperty("country_ids")] public CountryType[] CountryIds { get; set; }
        [JsonProperty("requested_user_id")] public int UserId { get; set; }
    }

    
    internal sealed class LeaderBoardUserinfoDealsClientRequestMessage : WsSendMessageBase<LeaderBoardUserinfoDealsClientModel>
    {
        public LeaderBoardUserinfoDealsClientRequestMessage(
            CountryType[] countryIds,
            int userId)
        {
            Message = new RequestBody<LeaderBoardUserinfoDealsClientModel>
            {
                RequestBodyType = RequestMessageBodyType.RequestLeaderboardUserinfoDealsClient,
                Body = new LeaderBoardUserinfoDealsClientModel
                {
                    CountryIds = countryIds,
                    UserId = userId
                }   
            };
        }
    }
}