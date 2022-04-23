using System.Collections.Generic;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        #region [GetCurrency]
        public Task<Currency> GetCurrencyAsync(string requestId, string currencyName)
        {
            return SendMessageAsync(requestId, new GetCurrencyRequestMessage(currencyName), CurrencyObservable);
        }
        #endregion
    }
}