using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Ws.Request;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {

        #region [GetAlertsRequest]

        /// <summary>
        /// Get Alerts
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="activeId">ActivePair Id to request</param>
        /// <param name="type">Type String</param>
        /// <returns></returns>
        public Task<Alerts> GetAlertsRequest(string requestId, ActivePair activeId, string type)
        {
            return SendMessageAsync(requestId, new GetAlertsRequestMessage(activeId, type), AlertsResultObservable);
        }

        #endregion

        #region [CreateAlertRequest]

        /// <summary>
        /// EN: Create alert
        /// pt_BR: Cria um alerta
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="activeId">ActivePair Id to request</param>
        /// <param name="instrumentType">InstrumentType</param>
        /// <param name="type">Type String</param>
        /// <param name="value">Value Decimal</param>
        /// <param name="activations">Activations 1 for All Times 0 for One Time</param>
        /// <returns></returns>
        public Task<Alert> CreateAlertRequest(string requestId, ActivePair activeId, InstrumentType instrumentType, string type, double value, int activations)
        {
            return SendMessageAsync(requestId, new CreateAlertRequestMessage(activeId, instrumentType, type, value, activations), AlertResultObservable);
        }

        #endregion

        #region [UpdateAlertRequest]

        /// <summary>
        /// EN: Update alert
        /// pt_BR: Altera um alerta
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="activeId">ActivePair Id to request</param>
        /// <param name="type">Type String</param>
        /// <returns></returns>
        public Task<Alert> UpdateAlertRequest(string requestId, long id, ActivePair activeId, InstrumentType instrumentType, string type, double value, int activations)
        {
            return SendMessageAsync(requestId, new UpdateAlertRequestMessage(id, activeId, instrumentType, type, value, activations), AlertResultObservable);
        }

        #endregion

        #region [CreateAlertRequest]

        /// <summary>
        /// EN: Delete alert
        /// pt_BR: Deleta um alerta
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="activeId">ActivePair Id to request</param>
        /// <param name="type">Type String</param>
        /// <returns></returns>
        public Task<Alert> DeleteAlertRequest(string requestId, long id)
        {
            return SendMessageAsync(requestId, new DeleteAlertRequestMessage(id), AlertResultObservable);
        }

        #endregion
    }
}