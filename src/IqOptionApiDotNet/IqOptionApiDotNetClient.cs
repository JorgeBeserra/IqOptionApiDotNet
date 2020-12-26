using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using IqOptionApiDotNet.Http;
using IqOptionApiDotNet.Logging;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Ws;

namespace IqOptionApiDotNet
{
    public class IqOptionApiDotNetClient : IIqOptionApiDotNetClient
    {
        private readonly ILogger _logger;

        #region [Ctor]

        public IqOptionApiDotNetClient(string username, string password)
        {
            Username = username;
            Password = password;
            _logger = IqOptionApiLog.Logger;

            //set up client
            HttpClient = new IqOptionHttpClient(username, password);
        }

        #endregion

        public Task<bool> ConnectAsync()
        {
            connectedSubject.OnNext(false);
            IsConnected = false;

            var tcs = new TaskCompletionSource<bool>();
            try
            {
                HttpClient
                    .LoginAsync()
                    .ContinueWith(t =>
                    {
                        if (t.Result != null && t.Result.IsSuccessful)
                        {

                            _logger.LogInformation($"{Username} logged in success!");
                            
                            if (WsClient != null) WsClient.Dispose();
                            WsClient = new IqOptionWebSocketClient(t.Result.Data.Ssid);

                            SubscribeWebSocket();

                            IsConnected = true;
                            connectedSubject.OnNext(true);
                            tcs.TrySetResult(true);
                            return;
                        }
                        _logger.LogInformation(
                            $"{Username} logged in failed due to {t.Result?.Errors?.GetErrorMessage()}");
                        tcs.TrySetResult(false);
                    }).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }

            return tcs.Task;
        }

        public async Task<Profile> GetProfileAsync(string requestId)
        {
            var result = await HttpClient.GetProfileAsync(requestId);
            return result.Result;
        }

        public async void ResetTrainingBalanceAsync(string requestId)
        {
            await WsClient?.ResetTrainingBalanceAsync(requestId);
        }

        public Task<UserProfileClientResult> GetUserProfileClientAsync(string requestId, long userid)
        {
            return WsClient?.GetUserProfileClientAsync(requestId, userid);
        }

        public Task<TopAssets> GetTopAssetsAsync(string requestId, InstrumentType instrumentType)
        {
            return WsClient?.GetTopAssetsAsync(requestId, instrumentType);
        }

        public Task<LeaderBoardDealsClientResult> RequestLeaderboardDealsClientAsync(string requestId, CountryType countryId,  long fromPosition, long toPosition, CountryType userCountryId = CountryType.BR, long nearTradersCountryCount = 0, long nearTradersCount = 0, long topCountryCount = 0, long topCount = 0, long topType = 2)
        {
            return WsClient?.LeaderBoardDealsClientRequest(requestId, countryId, userCountryId, fromPosition, toPosition, nearTradersCountryCount, nearTradersCount, topCountryCount, topCount, topType);
        }

        public Task<LeaderBoardUserinfoDealsClientMessageResult> RequestLeaderboardUserinfoDealsClientAsync(string requestId, CountryType[] countryId, int userId)
        {
            return WsClient?.LeaderBoardUserinfoDealsClientRequest(requestId, countryId, userId);
        }

        public Task<UsersAvailabilityResult> GetUsersAvailabilityAsync(string requestId, long[] userId)
        {
            return WsClient?.GetUsersAvailabilityRequest(requestId, userId);
        }

        public Task<ExposureResult> GetExposureAsync(string requestId, InstrumentType instrumentType, ActivePair activeId, CurrencyCode currency, DateTimeOffset time)
        {
            return WsClient?.GetExposureAsync(requestId, instrumentType, activeId, currency, time);
        }

        public Task<Alerts> GetAlerts(string requestId, ActivePair activeId = ActivePair.ALL, string type = "")
        {
            return WsClient?.GetAlertsRequest(requestId, activeId, type);
        }

        /// <summary>
        /// The main <c>CreateAlert()</c> class.
        /// </summary>
        /// <param name="requestId">template</param>
        /// <param name="activeId">template</param>
        /// <param name="instrumentType">template</param>
        /// <param name="type">template</param>
        /// <param name="value">template</param>
        /// <param name="activations">template</param>
        public Task<Alert> CreateAlert(string requestId, ActivePair activeId,InstrumentType instrumentType, double value, int activations, string type = "price")
        {
            return WsClient?.CreateAlertRequest(requestId, activeId, instrumentType, type, value, activations);
        }

        public Task<Alert> UpdateAlert(string requestId, long id, ActivePair activeId, InstrumentType instrumentType, double value, int activations, string type = "price")
        {
            return WsClient?.UpdateAlertRequest(requestId, id, activeId, instrumentType, type, value, activations);
        }

        public Task<Alert> DeleteAlert(string requestId, long id)
        {
            return WsClient?.DeleteAlertRequest(requestId, id);
        }

        public Task<FinancialInformationResult> GetFinancialInformationAsync(string requestId, ActivePair pair)
        {
            return WsClient?.GetFinancialInformationRequest(requestId, pair);
        }

        public Task<IEnumerable<Balance>> GetBalancesAsync(string requestId, IEnumerable<BalanceType> types)
        {
            return WsClient?.GetBalancesAsync(requestId, types);
        }

        public async Task<bool> ChangeBalanceAsync(string requestId, long balanceId)
        {
            var result = await HttpClient.ChangeBalanceAsync(balanceId);

            if (result?.Message == null && !result.IsSuccessful)
            {
                _logger.LogError($"Change balance ({balanceId}) error : {result.Message}");
                return false;
            }

            _logger.LogInformation($"Change balance to {balanceId} successfully!");
            return true;
        }

        public Task<BinaryOptionsResult> BuyAsync(string requestId, ActivePair pair, decimal size, OrderDirection direction,
            DateTimeOffset expiration)
        {
            return WsClient?.BuyAsync(requestId, pair, size, direction, expiration);
        }


        public Task<CandleCollections> GetCandlesAsync(string requestId, ActivePair pair, TimeFrame timeFrame, int count,
            DateTimeOffset to)
        {
            return WsClient?.GetCandlesAsync(requestId, pair, timeFrame, count, to);
        }

        public Task<InitializationData> GetInitializationData(string requestId)
        {
            return WsClient?.GetInitializationDataAsync(requestId);
        }

        public async Task<double> GetProfitAsync(string requestId, OptionType option, ActivePair pair)
        {
            var initializationData = await GetInitializationData(requestId);
            var instrumentData = (option == OptionType.Binary)
                ? initializationData.BinaryOption
                : initializationData.TurboOption;

            if (instrumentData.Actives.ContainsKey(pair))
            {
                return (100 - instrumentData.Actives[pair].Option.Profit.Commission) / 100;
            }            
            return -1;
        }

        public Task<IObservable<CurrentCandle>> SubscribeRealtimeQuoteAsync(string requestId, ActivePair pair, TimeFrame tf)
        {
            WsClient?.SubscribeQuoteAsync(requestId, pair, tf).ConfigureAwait(false);

            var stream = WsClient?
                .RealTimeCandleInfoObservable
                .Where(x => x.ActivePair == pair && x.TimeFrame == tf);

            return Task.FromResult(stream);
        }


        /// <inheritdoc/>
        public void SubscribeTradersMoodChanged(string requestId, InstrumentType instrumentType, ActivePair active)
            => WsClient?.SubscribeTradersMoodChanged(requestId, instrumentType, active);

        /// <inheritdoc/>
        public void UnSubscribeTradersMoodChanged(string requestId, InstrumentType instrumentType, ActivePair active)
            => WsClient?.UnSubscribeTradersMoodChanged(requestId, instrumentType, active);

        /// <inheritdoc/>
        public Task UnSubscribeRealtimeData(string requestId, ActivePair pair, TimeFrame tf)
            => WsClient?.UnsubscribeCandlesAsync(requestId, pair, tf);


        /// <inheritdoc/>
        public Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string requestId, ActivePair pair, OrderDirection direction,
            DigitalOptionsExpiryDuration duration, double amount)
            => WsClient?.PlaceDigitalOptions(requestId, pair, direction, duration, amount);


        /// <inheritdoc/>
        public Task<DigitalOptionsPlacedResult> PlaceDigitalOptions(string requestId, string instrumentId, double amount)
            => WsClient?.PlaceDigitalOptions(requestId, instrumentId, amount);

        /// <inheritdoc/>
        public void SubscribeTopAssetsUpdated(string requestId, InstrumentType instrumentType)
            => WsClient?.SubscribeTopAssetsUpdated(requestId, instrumentType);

        /// <inheritdoc/>
        public void SubscribeLiveDeal(string requestId, String message, ActivePair pair, DigitalOptionsExpiryType duration)
            => WsClient?.SubscribeLiveDeal(requestId, message, pair, duration);

        /// <inheritdoc/>
        public void UnSubscribeLiveDeal(string requestId, String message, ActivePair pair, DigitalOptionsExpiryType duration)
            => WsClient?.UnSubscribeLiveDeal(requestId, message, pair, duration);


        public void Dispose()
        {
            connectedSubject?.Dispose();
            WsClient?.Dispose();
        }


        /// <summary>
        ///     listen to all obs, for make all properties updated
        /// </summary>
        private void SubscribeWebSocket()
        {
            //subscribe profile
            HttpClient.ProfileObservable
                .Merge(WsClient.ProfileObservable)
                .DistinctUntilChanged()
                .Where(x => x != null)
                .Subscribe(x => Profile = x);

            //subscribe for instrument updated
            WsClient.InstrumentResultSetObservable
                .Subscribe(x => Instruments = x);

            string requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
            //subscribe for Alerts Changed
            WsClient.SubscribeAlertChangedChanged(requestId);

            //subscribe for Alerts Triggered
            requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
            WsClient.SubscribeAlertTriggeredChanged(requestId);
        }

        #region [Privates]

        private readonly Subject<Profile> _profileSubject = new Subject<Profile>();

        private readonly Subject<bool> connectedSubject = new Subject<bool>();
        private Profile _profile;

        #endregion

        #region [Publics]

        public string Username { get; }
        public string Password { get; }
        public IDictionary<InstrumentType, Instrument[]> Instruments { get; private set; }

        public Profile Profile
        {
            get => _profile;
            private set
            {
                _profileSubject.OnNext(value);
                _profile = value;
            }
        }

        public bool IsConnected { get; private set; }

        //clients
        public IqOptionHttpClient HttpClient { get; }
        public IqOptionWebSocketClient WsClient { get; private set; }

        //obs
        public IObservable<Profile> ProfileObservable => _profileSubject.AsObservable();
        public IObservable<bool> ConnectedObservable => connectedSubject.AsObservable();
        public IObservable<BinaryOptionsResult> BuyResultObservable => WsClient?.BinaryOptionPlacedResultObservable;
        public IObservable<BalanceChanged> BalanceChangedObservable => WsClient?.BalanceChangedObservable;
        public IObservable<AlertChanged> AlertChangedObservable => WsClient?.AlertChangedResultObservable;
        public IObservable<AlertTriggered> AlertTriggeredObservable => WsClient?.AlertTriggeredResultObservable;

        #endregion
    }
}