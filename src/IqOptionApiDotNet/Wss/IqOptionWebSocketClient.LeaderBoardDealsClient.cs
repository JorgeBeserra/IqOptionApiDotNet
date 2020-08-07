using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {

        #region [LeaderBoardDealsClientRequest]

        /// <summary>
        /// Get Informations By User ID
        /// </summary>
        /// <param name="userid">User Id to request</param>
        /// <returns></returns>
        public Task<LeaderBoardDealsClientResult> LeaderBoardDealsClientRequest(long countryId,long userCountryId,long fromPosition,long toPosition,long nearTradersCountryCount,long nearTradersCount,long topCountryCount, long topCount, long topType)
        {
            return SendMessageAsync(new LeaderBoardDealsClientRequestMessage(countryId,userCountryId,fromPosition,toPosition,nearTradersCountryCount,nearTradersCount, topCountryCount, topCount, topType), LeaderBoardDealsClientResultObservable);
        }

        #endregion
    }
}