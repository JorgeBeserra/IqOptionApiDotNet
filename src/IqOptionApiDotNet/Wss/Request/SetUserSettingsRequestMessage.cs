using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    
    internal class SetUserSettingsModel
    {
        [JsonProperty("configs")] public SetUserSettingsConfigsModel Configs { get; set; }
    }

    internal class SetUserSettingsConfigsModel
    {
        [JsonProperty("balanceid")] public long Balannceid { get; set; }
    }

    internal sealed class SetUserSettingsRequestMessage : WsSendMessageBase<SetUserSettingsModel>
    {
        public SetUserSettingsRequestMessage()
        {
            Message = new RequestBody<SetUserSettingsModel>
            {
                RequestBodyType = RequestMessageBodyType.SetUserSettings,
                Version = "1.0",
                Body = new SetUserSettingsModel
                {      
                }
            };
        }
    }
}