﻿using System;
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
        Task<Profile> GetProfileAsync();
		
		Task<UserProfileClientResult> GetUserProfileClientAsync(long userId);
        Task<LeaderBoardDealsClientResult> RequestLeaderboardDealsClientAsync(long countryId, long userCountryId, long fromPosition, long toPosition, long nearTradersCountryCount, long nearTradersCount, long topCountryCount, long topCount, long topType);
        Task<LeaderBoardUserinfoDealsClientMessageResult> RequestLeaderboardUserinfoDealsClientAsync(long[] countryId, int userId);
        Task<UsersAvailabilityResult> GetUsersAvailabilityAsync(long[] userId);
		Task<FinancialInformationResult> GetFinancialInformationAsync(ActivePair pair);		
        Task<bool> ChangeBalanceAsync(long balanceId);
        Task<BinaryOptionsResult> BuyAsync(ActivePair pair, int size, OrderDirection direction, DateTimeOffset expiration);
        Task<CandleCollections> GetCandlesAsync(ActivePair pair, TimeFrame tf, int count, DateTimeOffset to);
        Task<IObservable<CurrentCandle>> SubscribeRealtimeQuoteAsync(ActivePair pair, TimeFrame tf);

        Task UnSubscribeRealtimeData(ActivePair pair, TimeFrame tf);

        #region Subscribe

        /// <summary>
        /// Subscribe traders mood changed
        /// </summary>
        void SubscribeTradersMoodChanged(InstrumentType instrumentType, ActivePair active);

        /// <summary>
        /// Unsubscribe traders mood changed
        /// </summary>
        void UnSubscribeTradersMoodChanged(InstrumentType instrumentType, ActivePair active);

        /// <summary>
        /// Subscribe live deal
        /// </summary>
        void SubscribeLiveDeal(string message, ActivePair pair, DigitalOptionsExpiryType duration);

        /// <summary>
        /// Unsubscribe live deal
        /// </summary>
        void UnSubscribeLiveDeal(string message, ActivePair pair, DigitalOptionsExpiryType duration);


        #endregion

        #region PlacePositionCommands

        /// <summary>
        /// Place the DigitalOptions order
        /// </summary>
        /// <param name="pair">The Active pair, make sure your place with correct active.</param>
        /// <param name="direction">The position direction.</param>
        /// <param name="duration">The duration period in (1Min, 5Min, 15Min) from now</param>
        /// <param name="amount">The Amount of position</param>
        /// <returns></returns>
        Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(ActivePair pair, OrderDirection direction,
            DigitalOptionsExpiryDuration duration, double amount);

        /// <summary>
        /// Place the DigitalOptions order from the instruments_id
        /// </summary>
        /// <param name="instrumentId">The Instrument identifier <example>doEURUSD201907191250PT5MPSPT</example></param>
        /// <param name="amount">The Amount of position</param>
        /// <returns></returns>
        Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string instrumentId, double amount);

        #endregion

    }
}