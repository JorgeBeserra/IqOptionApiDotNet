﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IqOptionApiDotNet.Http;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Ws;

namespace IqOptionApiDotNet
{
    public interface IIqOptionApiDotNetClient : IDisposable
    {
        IqOptionWebSocketClient WsClient { get; }
        IqOptionHttpClient HttpClient { get; }
        IObservable<Profile> ProfileObservable { get; }
        Profile Profile { get; }
        bool IsConnected { get; }
        IObservable<bool> ConnectedObservable { get; }

        Task<bool> ConnectAsync();
        Task<Profile> GetProfileAsync(string requestId);
        Task<Alerts> GetAlerts(string requestId, ActivePair activeId, string type);
        Task<Alert> CreateAlert(string requestId, ActivePair activeId, InstrumentType instrumentType, double value, int activations, string type = "price");
        Task<Alert> UpdateAlert(string requestId, long id, ActivePair activeId, InstrumentType instrumentType, double value, int activations, string type = "price");
        Task<Alert> DeleteAlert(string requestId, long id);
        Task<ExposureResult> GetExposureAsync(string requestId, InstrumentType instrumentType, ActivePair activeId, CurrencyCode currency, DateTimeOffset time);
        Task<UserProfileClientResult> GetUserProfileClientAsync(string requestId, long userId);
        Task<LeaderBoardDealsClientResult> RequestLeaderboardDealsClientAsync(string requestId, CountryType countryId, long fromPosition, long toPosition, CountryType userCountryId, long nearTradersCountryCount, long nearTradersCount, long topCountryCount, long topCount, long topType);
        Task<LeaderBoardUserinfoDealsClientMessageResult> RequestLeaderboardUserinfoDealsClientAsync(string requestId, CountryType[] countryId, int userId);
        Task<UsersAvailabilityResult> GetUsersAvailabilityAsync(string requestId, long[] userId);
		Task<FinancialInformationResult> GetFinancialInformationAsync(string requestId, ActivePair pair);
        Task<IEnumerable<Balance>> GetBalancesAsync(string requestId, IEnumerable<BalanceType> types);
        Task<bool> ChangeBalanceAsync(string requestId, long balanceId);
        Task<BinaryOptionsResult> BuyAsync(string requestId, ActivePair pair, Decimal size, OrderDirection direction, DateTimeOffset expiration);
        Task<CandleCollections> GetCandlesAsync(string requestId, ActivePair pair, TimeFrame tf, int count, DateTimeOffset to);
        Task<InitializationData> GetInitializationData(string requestId);
        Task<double> GetProfitAsync(string requestId, OptionType option, ActivePair pair);
        Task<IObservable<CurrentCandle>> SubscribeRealtimeQuoteAsync(string requestId, ActivePair pair, TimeFrame tf);

        Task UnSubscribeRealtimeData(string requestId, ActivePair pair, TimeFrame tf);

        #region Subscribe

        /// <summary>
        /// Subscribe traders mood changed
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="instrumentId">The Instrument identifier <example>doEURUSD201907191250PT5MPSPT</example></param>
        /// <param name="pair">The Active pair, make sure your place with correct active.</param>
        void SubscribeTradersMoodChanged(string requestId, InstrumentType instrumentType, ActivePair active);

        /// <summary>
        /// Unsubscribe traders mood changed
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="instrumentId">The Instrument identifier <example>doEURUSD201907191250PT5MPSPT</example></param>
        /// <param name="pair">The Active pair, make sure your place with correct active.</param>
        void UnSubscribeTradersMoodChanged(string requestId, InstrumentType instrumentType, ActivePair active);

        /// <summary>
        /// Subscribe live deal
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        void SubscribeLiveDeal(string requestId, string message, ActivePair pair, DigitalOptionsExpiryType duration);

        /// <summary>
        /// Unsubscribe live deal
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        void UnSubscribeLiveDeal(string requestId, string message, ActivePair pair, DigitalOptionsExpiryType duration);


        #endregion

        #region PlacePositionCommands

        /// <summary>
        /// Place the DigitalOptions order
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="pair">The Active pair, make sure your place with correct active.</param>
        /// <param name="direction">The position direction.</param>
        /// <param name="duration">The duration period in (1Min, 5Min, 15Min) from now</param>
        /// <param name="amount">The Amount of position</param>
        /// <returns></returns>
        Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string requestId, ActivePair pair, OrderDirection direction,
            DigitalOptionsExpiryDuration duration, double amount);

        /// <summary>
        /// Place the DigitalOptions order from the instruments_id
        /// </summary>
        /// <param name="requestId">Request identifier<example>5f2c370145a047c7b87f2680556b3b93</example></param>
        /// <param name="instrumentId">The Instrument identifier <example>doEURUSD201907191250PT5MPSPT</example></param>
        /// <param name="amount">The Amount of position</param>
        /// <returns></returns>
        Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string requestId, string instrumentId, double amount);

        #endregion

    }
}