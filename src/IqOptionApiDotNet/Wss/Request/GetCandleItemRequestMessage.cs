using System;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Ws.Request
{
    public class GetCandleItemRequestMessage : WsMessageBase<GetCandlesRequestModel>
    {
        public GetCandleItemRequestMessage(ActivePair pair, TimeFrame tf, int count, DateTimeOffset to)
        {
            base.Message = new GetCandlesRequestModel
            {
                RequestBody = new GetCandlesRequestModel.GetCandlesRequestBody
                {
                    ActivePair = pair,
                    TimeFrame = tf,
                    Count = count,
                    To = to.ToUniversalTime() // servertime should set here
                }
            };
        }

        public override string Name => MessageType.SendMessage;
    }
}