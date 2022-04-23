using System.Collections.Generic;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        #region [SetUserSettings]
        public Task<UserSettings> SetUserSettingsAsync(string requestId)
        {
            return SendMessageAsync(requestId, new SetUserSettingsRequestMessage(), UserSettingsObservable);
        }
        #endregion
    }
}