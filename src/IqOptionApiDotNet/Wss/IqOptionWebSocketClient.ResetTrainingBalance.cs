using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        
        #region [ResetTrainingBalance]

        /// <summary>
        /// Reset Training Balance
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <returns></returns>
        public async Task ResetTrainingBalanceAsync(string requestId)
        {
            await SendMessageAsync(requestId, new ResetTrainingBalanceMessageBase()).ConfigureAwait(false);
        }

        #endregion
    }
}