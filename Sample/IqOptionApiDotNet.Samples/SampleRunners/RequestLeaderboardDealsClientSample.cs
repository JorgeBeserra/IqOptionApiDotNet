using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class RequestLeaderboardDealsClientSample : SampleRunner
    {
        // Get Leaderboard Top Traders
        // By: Jorge Beserra
        public override async Task RunSample()
        {
            if (await IqClientApiDotNet.ConnectAsync())
            {
                var leader = await IqClientApiDotNet.RequestLeaderboardDealsClientAsync(0, 191, 1, 10, 64, 64, 64, 64, 2);
                _logger.Information(JsonConvert.SerializeObject(leader));
            }
        }
    }
}