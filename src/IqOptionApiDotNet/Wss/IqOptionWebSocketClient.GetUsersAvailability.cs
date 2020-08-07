using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {

        #region [GetUsersAvailabilityRequest]

        /// <summary>
        /// Get Informations By User ID
        /// </summary>
        /// <param name="userid">User Id to request</param>
        /// <returns></returns>
        public Task<UsersAvailabilityResult> GetUsersAvailabilityRequest(long[] userId)
        {
            return SendMessageAsync(new UsersAvailabilityRequestMessage(userId), UsersAvailabilityResultObservable);
        }

        #endregion
    }
}