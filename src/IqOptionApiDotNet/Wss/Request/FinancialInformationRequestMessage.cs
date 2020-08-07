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
    internal class FinancialInformationModel
    {
        [JsonProperty("query")] public string Query { get; set; }
        [JsonProperty("operationName")] public string OperationName { get; set; }
        [JsonProperty("variables")] public FinancialInformationVariables Variables { get; set; }
    }

    internal class FinancialInformationVariables
    {
        [JsonProperty("activeId")] public ActivePair ActiveId { get; set; }
    }


    internal sealed class FinancialInformationRequestMessage : WsSendMessageBase<FinancialInformationModel>
    {
        public FinancialInformationRequestMessage(
            ActivePair pair)
        {
            Message = new RequestBody<FinancialInformationModel>
            {
                RequestBodyType = RequestMessageBodyType.GetFinancialInformation,
                Body = new FinancialInformationModel
                {
                    Query = "query GetAssetProfileInfo($activeId:ActiveID!, $locale: LocaleName){\n active(id: $activeId) {\n id\n name(source: TradeRoom, locale: $locale)\n ticker\n media {\n siteBackground\n }\n charts {\n dtd {\n change\n }\n m1 {\n change\n }\n y1 {\n change\n }\n ytd {\n change\n }\n }\n index_fininfo: fininfo {\n ... on Index {\n description(locale: $locale)\n }\n }\n fininfo {\n ... on Pair {\n type\n description(locale: $locale)\n currency {\n name(locale: $locale)\n }\n base {\n name(locale: $locale)\n ... on Stock {\n company {\n country {\n nameShort\n }\n gics {\n sector\n industry\n }\n site\n domain\n }\n keyStat {\n marketCap\n peRatioHigh\n }\n }\n ... on CryptoCurrency {\n site\n domain\n coinsInCirculation\n maxCoinsQuantity\n volume24h\n marketCap\n }\n }\n }\n }\n }\n }",
                    OperationName = "GetAssetProfileInfo",
                    Variables = new FinancialInformationVariables {
                        ActiveId = pair
                        },
                }   
            };
        }
    }
}