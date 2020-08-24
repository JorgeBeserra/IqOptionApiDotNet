using IqOptionApiDotNet.Ws.Base;
using IqOptionApiDotNet.Wss.Request;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class ResetTrainingBalanceModel
    {
        [JsonProperty("name")] public string Name => "reset-training-balance";

        [JsonProperty("version")] public string Version => "2.0";
    }
    internal class ResetTrainingBalanceMessageBase : WsMessageBase<ResetTrainingBalanceModel>
    {
        public ResetTrainingBalanceMessageBase()
        {
            base.Message = new ResetTrainingBalanceModel();
        }

        public override string Name => MessageType.SendMessage;
    }
}