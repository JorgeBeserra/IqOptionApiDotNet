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
    internal class UsersAvailabilityModel
    {
        [JsonProperty("user_ids")] public long[] UsersIds { get; set; }
    }

    
    internal sealed class UsersAvailabilityRequestMessage : WsSendMessageBase<UsersAvailabilityModel>
    {
        public UsersAvailabilityRequestMessage(
            long[] usersIds)
        {
            Message = new RequestBody<UsersAvailabilityModel>
            {
                RequestBodyType = RequestMessageBodyType.GetUsersAvailability,
                Body = new UsersAvailabilityModel
                {
                    UsersIds = usersIds,
                }   
            };
        }
    }
}