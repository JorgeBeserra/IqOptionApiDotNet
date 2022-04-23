using System.Collections.Generic;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        #region [GetUserSettingsAsync]
        public Task<UserSettings> GetUserSettingsAsync(string requestId)
        {
            return SendMessageAsync(requestId, new GetUserSettingsRequestMessage(), UserSettingsObservable);
        }
        #endregion
    }
}