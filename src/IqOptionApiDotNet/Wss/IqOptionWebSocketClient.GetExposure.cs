using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        #region [GetExposure]

        public Task<ExposureResult> GetExposureAsync(string requestId, InstrumentType instrumentType, ActivePair activeId, CurrencyCode currency, DateTimeOffset time)
        {
            return SendMessageAsync(requestId, new GetExposureRequestMessage(instrumentType, activeId, currency, time), ExposureResultObservable);
        }

        #endregion
    }
}