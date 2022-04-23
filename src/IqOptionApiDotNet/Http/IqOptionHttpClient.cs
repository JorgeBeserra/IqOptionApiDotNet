﻿﻿using System;
using System.Net;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using IqOptionApiDotNet.extensions;
 using IqOptionApiDotNet.Logging;
 using IqOptionApiDotNet.Models;
 using Microsoft.Extensions.Logging;
 using RestSharp;

namespace IqOptionApiDotNet.Http
{
    public class IqOptionHttpClient
    {
        private ILogger _logger;

        public IqOptionHttpClient(string username, string password, string host = "iqoption.com")
        {
            Client = new RestClient(ApiEndPoint(host));

            LoginModel = new LoginModel {Email = username, Password = password};

            _logger = IqOptionApiLog.Logger;
        }

        public LoginModel LoginModel { get; }
        public SsidResultMessage SecuredToken { get; private set; }
        public RestClient Client { get; }

        protected static Uri ApiEndPoint(string host)
        {
            return new Uri($"https://{host}/api");
        }

        #region [Profile]

        public IObservable<Profile> ProfileObservable => _profileSubject.AsObservable();
        private readonly Subject<Profile> _profileSubject = new Subject<Profile>();
        private Profile _profile;

        public Profile Profile
        {
            get => _profile;
            private set
            {
                _profileSubject.OnNext(value);
                _profile = value;
            }
        }
        
        #endregion

        #region Web-Methods

        public Task<IqHttpResult<SsidResultMessage>> LoginAsync()
        {
            var tcs = new TaskCompletionSource<IqHttpResult<SsidResultMessage>>();
            try
            {
                var body = new
                {
                    identifier = LoginModel.Email,
                    password = LoginModel.Password
                };

                var client = new RestClient("https://auth.iqoption.com/api/v2/login");
                var request = new RestRequest() { RequestFormat = DataFormat.Json }
                    .AddHeader("Accept", "application/json")
                    .AddHeader("Accept-Encoding", "gzip, deflate, br")
                    .AddHeader("Accept-Language", "pt-BR,pt;q=0.8,en-US;q=0.5,en;q=0.3")
                    .AddHeader("content-type", "application/json")
                    .AddHeader("Host", "auth.iqoption.com")
                    .AddHeader("Origin", "login.iqoption.com")
                    .AddHeader("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:98.0) Gecko/20100101 Firefox/98.0")
                    .AddJsonBody(body);               

                client.PostAsync(request)
                    .ContinueWith(t =>
                    {
                        
                        switch (t.Result.StatusCode)
                        {
                            
                            case HttpStatusCode.OK:
                            {
                                    
                                var resultSsid = t.Result.Content.JsonAs<SsidResultMessage>();
                                var result = t.Result.Content.JsonAs<IqHttpResult<SsidResultMessage>>();

                                result.Data = t.Result.Content.JsonAs<SsidResultMessage>();
                                SecuredToken = resultSsid;

                                //Client.CookieContainer = new CookieContainer();
                                Client.CookieContainer.Add(new Cookie("ssid", SecuredToken.Ssid, "/", "iqoption.com"));
                                result.IsSuccessful = true;
                                tcs.TrySetResult(result);
                                break;
                            }
                            default:
                            {
                                var error = t.Result.Content.JsonAs<IqHttpResult<SsidResultMessage>>();
                                error.IsSuccessful = false;
                                tcs.TrySetResult(error);
                                break;
                            }
                        }
                    });
            }
            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }


            return tcs.Task;
        }

        public Task<IqHttpResult<Profile>> GetProfileAsync(string requestId)
        {
            return Client.ExecuteGetAsync(new GetProfileRequest(requestId)).ContinueWith(t =>
            {
                if (t.Result != null && t.Result.StatusCode == HttpStatusCode.OK)
                    return t.Result.Content.JsonAs<IqHttpResult<Profile>>();

                return null;
            });
        }

        public async Task<IqHttpResult<IHttpResultMessage>> ChangeBalanceAsync(long balanceId)
        {
            var result = await Client.ExecutePostAsync(new ChangeBalanceRequest(balanceId));

            if (result.StatusCode == HttpStatusCode.OK)
                return result.Content.JsonAs<IqHttpResult<IHttpResultMessage>>();

            return null;
        }

        #endregion
    }
}