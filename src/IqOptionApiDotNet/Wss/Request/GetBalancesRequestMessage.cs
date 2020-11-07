using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    internal class GetBalancesModel
    {
        [JsonProperty("types_ids")]
        [JsonConverter(typeof(TypesConverter))]
        public IEnumerable<BalanceType> TypesIds { get; set; }

        [JsonProperty("tournaments_statuses_ids")]
        public IEnumerable<int> TournamentsStatusesIds = new int[] { 2, 3 };

        internal class TypesConverter : JsonConverter<IEnumerable<BalanceType>>
        {
            public override IEnumerable<BalanceType> ReadJson(JsonReader reader, Type objectType, IEnumerable<BalanceType> existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override void WriteJson(JsonWriter writer, IEnumerable<BalanceType> value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value.Select(i => (int)i));
            }
        }
    }

    internal sealed class GetBalancesRequestMessage : WsSendMessageBase<GetBalancesModel>
    {
        public GetBalancesRequestMessage(IEnumerable<BalanceType> types)
        {
            Message = new RequestBody<GetBalancesModel>
            {
                RequestBodyType = RequestMessageBodyType.GetBalances,
                Body = new GetBalancesModel
                {
                    TypesIds = types
                }
            };
        }
    }
}