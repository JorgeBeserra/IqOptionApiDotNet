using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {

        #region [GetInitializationData]

        public Task<InitializationData> GetInitializationDataAsync(string requestId)
        {
            return SendMessageAsync(requestId, new GetInitializationDataRequestMessage(), InitializationDataObservable);
        }

        #endregion
    }
}