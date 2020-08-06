using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Ws.Request;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Wss.Request.DigitalOptions
{
    public class ClosePositionRequestBody
    {
        [JsonProperty("position_id")]
        public long PositionId { get; set; }
    }
    
    internal sealed class CloseDigitalOptionsMessageRequest : WsSendMessageBase<ClosePositionRequestBody>
    {
        public CloseDigitalOptionsMessageRequest(long positionId)
        {
            Message = new RequestBody<ClosePositionRequestBody>
            {
                Version = "1.0",
                RequestBodyType = "digital-options.close-position",
                Body = new ClosePositionRequestBody
                {
                    PositionId = positionId
                }
            };
        }
    }

}