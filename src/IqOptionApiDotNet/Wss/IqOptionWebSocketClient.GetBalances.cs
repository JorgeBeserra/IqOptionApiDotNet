using System.Collections.Generic;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        #region [GetBalances]

        public Task<IEnumerable<Balance>> GetBalancesAsync(string requestId, IEnumerable<BalanceType> types)
        {
            return SendMessageAsync(requestId, new GetBalancesRequestMessage(types), BalancesObservable);
        }

        #endregion
    }
}
