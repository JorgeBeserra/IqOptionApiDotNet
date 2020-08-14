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
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var leader = await IqClientApiDotNet.RequestLeaderboardDealsClientAsync(requestId, 0, 191, 1, 10, 64, 64, 64, 64, 2);
                _logger.Information(JsonConvert.SerializeObject(leader));
            }
        }
    }
}