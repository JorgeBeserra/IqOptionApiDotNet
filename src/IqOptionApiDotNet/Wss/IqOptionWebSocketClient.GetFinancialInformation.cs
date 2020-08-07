using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {

        #region [GetFinancialInformationRequest]

        /// <summary>
        /// Get Informations By User ID
        /// </summary>
        /// <param name="activieId">Activies Id to request</param>
        /// <returns></returns>
        public Task<FinancialInformationResult> GetFinancialInformationRequest(ActivePair pair)
        {
            return SendMessageAsync(new FinancialInformationRequestMessage(pair), FinancialInformationResultObservable);
        }

        #endregion
    }
}