using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Utilities;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Wss.Request.SubscribeMessages
{
    internal class UnsubscribeTradersMoodChanged : WsMessageBase<dynamic>
    {
        public override string Name => "unsubscribeMessage";

        public UnsubscribeTradersMoodChanged(InstrumentType instrumentType, ActivePair active)
        {
            base.Message = new
            {
                name = "traders-mood-changed",
                @params =
                    new
                    {
                        routingFilters =
                            new
                            {
                                instrument = InstrumentTypeUtilities.GetInstrumentTypeFullName(instrumentType),
                                asset_id = (int) active
                            }
                    }
            };
        }
    }
}