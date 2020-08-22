using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {

        #region [LeaderBoardUserinfoDealsClientRequest]

        /// <summary>
        /// Get Informations By User ID
        /// </summary>
        /// <param name="userid">User Id to request</param>
        /// <returns></returns>
        public Task<LeaderBoardUserinfoDealsClientMessageResult> LeaderBoardUserinfoDealsClientRequest(string requestId, CountryType[] countryId, int userId)
        {
            return SendMessageAsync(requestId, new LeaderBoardUserinfoDealsClientRequestMessage(countryId, userId), LeaderBoardUserinfoDealsClientResultObservable);
        }

        #endregion
    }
}