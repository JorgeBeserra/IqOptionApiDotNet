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
    internal class GetUserProfileClientModel
    {
        [JsonProperty("user_id")] public long UserId { get; set; }
    }
    
    internal sealed class GetUserProfileClientRequestMessage : WsSendMessageBase<GetUserProfileClientModel>
    {
        public GetUserProfileClientRequestMessage(long userid)
        {
            Message = new RequestBody<GetUserProfileClientModel>
            {
                RequestBodyType = RequestMessageBodyType.GetUserProfileClient,
                Body = new GetUserProfileClientModel
                {
                    UserId = userid
                }
            };
        }
    }
}