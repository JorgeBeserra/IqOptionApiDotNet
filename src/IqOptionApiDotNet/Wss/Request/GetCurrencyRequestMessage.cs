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
    internal class GetCurrencyClientModel
    {
        [JsonProperty("name")] public string Name { get; set; }
    }
    
    internal sealed class GetCurrencyRequestMessage : WsSendMessageBase<GetCurrencyClientModel>
    {
        public GetCurrencyRequestMessage(string currencyName)
        {
            Message = new RequestBody<GetCurrencyClientModel>
            {
                RequestBodyType = RequestMessageBodyType.GetCurrency,
                Version = "5.0",
                Body = new GetCurrencyClientModel
                {
                    Name = currencyName
                }
            };
        }
    }
}