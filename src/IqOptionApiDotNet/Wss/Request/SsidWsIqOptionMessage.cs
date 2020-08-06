using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Ws.Request
{
    internal class SsidWsMessageBase : WsMessageBase<string>
    {
        public SsidWsMessageBase(string ssid)
        {
            base.Message = ssid;
        }

        public override string Name => MessageType.Ssid;
    }
}