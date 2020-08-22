using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class RequestLeaderboardUserinfoDealsClientSample : SampleRunner
    {
        // Get Leaderboard Trader infor
        // By: Jorge Beserra
        public override async Task RunSample()
        {
            if (await IqClientApiDotNet.ConnectAsync())
            {
                string requestId;
                CountryType[] countryes = {CountryType.Worldwide, };
                var userId = 0;
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var leader = await IqClientApiDotNet.RequestLeaderboardUserinfoDealsClientAsync(requestId, countryes, userId);
                _logger.Information(JsonConvert.SerializeObject(leader));
            }
        }
    }
}