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
    internal class GetAlertsRequestMessageModel
    {
        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }

    internal sealed class GetAlertsRequestMessage : WsSendMessageBase<GetAlertsRequestMessageModel>
    {
        public GetAlertsRequestMessage(
            ActivePair activeId,
            string type)
        {
            Message = new RequestBody<GetAlertsRequestMessageModel>
            {
                RequestBodyType = RequestMessageBodyType.GetAlerts,
                Body = new GetAlertsRequestMessageModel
                {
                    AssetId = activeId,
                    Type = type
                }
            };
        }
    }


    internal class CreateAlertRequestMessageModel
    {
        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }
        [JsonProperty("instrument_type")] public InstrumentType IntrumentTypeId { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("value")] public double Value { get; set; }
        [JsonProperty("activations")] public int Activations { get; set; }
    }


    internal sealed class CreateAlertRequestMessage : WsSendMessageBase<CreateAlertRequestMessageModel>
    {
        public CreateAlertRequestMessage(
            ActivePair activeId,
            InstrumentType instrumentType,
            string type,
            double value,
            int activations)
        {
            Message = new RequestBody<CreateAlertRequestMessageModel>
            {
                RequestBodyType = RequestMessageBodyType.CreateAlert,
                Body = new CreateAlertRequestMessageModel
                {
                    AssetId = activeId,
                    IntrumentTypeId = instrumentType,
                    Type = type,
                    Value = value,
                    Activations = activations
                }   
            };
        }
    }

    internal class AlertRequestMessageModel
    {
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("asset_id")] public ActivePair AssetId { get; set; }
        [JsonProperty("instrument_type")] public InstrumentType IntrumentTypeId { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("value")] public double Value { get; set; }
        [JsonProperty("activations")] public int Activations { get; set; }
    }


    internal sealed class UpdateAlertRequestMessage : WsSendMessageBase<AlertRequestMessageModel>
    {
        public UpdateAlertRequestMessage(
            long id,
            ActivePair activeId,
            InstrumentType instrumentType,
            string type,
            double value,
            int activations)
        {
            Message = new RequestBody<AlertRequestMessageModel>
            {
                RequestBodyType = RequestMessageBodyType.UpdateAlert,
                Body = new AlertRequestMessageModel
                {
                    Id = id,
                    AssetId = activeId,
                    IntrumentTypeId = instrumentType,
                    Type = type,
                    Value = value,
                    Activations = activations
                }
            };
        }
    }

    internal class AlertDeleteRequestMessageModel
    {
        [JsonProperty("id")] public long Id { get; set; }
    }

    internal sealed class DeleteAlertRequestMessage : WsSendMessageBase<AlertDeleteRequestMessageModel>
    {
        public DeleteAlertRequestMessage(
            long id)
        {
            Message = new RequestBody<AlertDeleteRequestMessageModel>
            {
                RequestBodyType = RequestMessageBodyType.DeleteAlert,
                Body = new AlertDeleteRequestMessageModel
                {
                    Id = id
                }
            };
        }
    }
}