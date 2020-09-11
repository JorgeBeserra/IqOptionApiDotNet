using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        
        #region [GetTopAssets]

        /// <summary>
        /// Get Informations By User ID
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="instrumentType">Instrument Type</param>
        /// <returns></returns>
        public Task<TopAssets> GetTopAssetsAsync(string requestId, InstrumentType instrumentType)
        {
            return SendMessageAsync(requestId, new GetTopAssetsRequestMessage(instrumentType), TopAssetsObservable);
        }

        #endregion
    }
}