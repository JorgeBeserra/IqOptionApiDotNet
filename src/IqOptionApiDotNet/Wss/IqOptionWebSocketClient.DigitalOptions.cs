using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Wss.Request.DigitalOptions;

namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        
        #region Place Digital Options
        
        /// <summary>
        /// Place the DigitalOptions order
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="pair">The Active pair, make sure your place with correct active.</param>
        /// <param name="direction">The position direction.</param>
        /// <param name="duration">The duration period in (1Min, 5Min, 15Min) from now</param>
        /// <param name="amount">The Amount of position</param>
        /// <returns></returns>
        public Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string requestId, ActivePair pair, OrderDirection direction, DigitalOptionsExpiryDuration duration, double amount)
        {

            return SendMessageAsync(requestId, new PlaceDigitalOptionsMessageRequest(new DigitalOptionsIdentifier(
                    pair, direction, duration, ServerTime), (int) Profile.BalanceId, amount),
                PlaceDigitalOptionResultObservable);

        }

        /// <summary>
        /// Place the DigitalOptions order from the instruments_id
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="instrumentId">The Instrument identifier <example>doEURUSD201907191250PT5MPSPT</example></param>
        /// <param name="amount">The Amount of position</param>
        /// <returns></returns>
        public Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string requestId, string instrumentId, double amount)
        {
            return SendMessageAsync(
                requestId,
                new PlaceDigitalOptionsMessageRequest(instrumentId, (int) Profile.BalanceId, amount),
                PlaceDigitalOptionResultObservable);
        }

        #endregion

        #region Get Digital Options

        /// <summary>
        /// Get positions for the specific balance
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <returns></returns>
        public Task GetPositionsAsync(string requestId, long blanceId)
        {
           return SendMessageAsync(requestId, new GetPositionsMessageRequest(Profile.BalanceId));
        }

        /// <summary>
        /// Get positions of current p
        /// </summary>
        /// <returns></returns>
        public Task GetPositionsAsync(string requestId)
        {
            if (Profile?.BalanceId != null)
                return GetPositionsAsync(requestId, (int) Profile.BalanceId);
            
            return Task.CompletedTask;
        }

        #endregion

        #region Close Digital Options

        

        #endregion
    }
}