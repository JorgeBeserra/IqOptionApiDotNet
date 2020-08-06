using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws.Base
{
    internal class WsSendMessageBase<T> : WsMessageBase<RequestBody<T>> where T : class
    {
        public override string Name { get; set; } = MessageType.SendMessage;
    }
}