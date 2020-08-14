using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        
        #region [GetUserProfileClient]

        /// <summary>
        /// Get Informations By User ID
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="userid">User Id to request</param>
        /// <returns></returns>
        public Task<UserProfileClientResult> GetUserProfileClientAsync(string requestId, long userid)
        {
            return SendMessageAsync(requestId, new GetUserProfileClientRequestMessage(userid), UserProfileClientResultObservable);
        }

        #endregion
    }
}