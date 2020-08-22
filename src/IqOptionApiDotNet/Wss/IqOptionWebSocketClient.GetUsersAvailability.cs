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
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="userId">User Id to request</param>
        /// <returns></returns>
        public Task<UsersAvailabilityResult> GetUsersAvailabilityRequest(string requestId, long[] userId)
        {
            return SendMessageAsync(requestId, new UsersAvailabilityRequestMessage(userId), UsersAvailabilityResultObservable);
        }

        #endregion
    }
}