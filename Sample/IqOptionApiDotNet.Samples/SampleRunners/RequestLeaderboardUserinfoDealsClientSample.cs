using System;
using System.Threading.Tasks;
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
                long[] countryes = {0 };
                var userId = 0;
                var leader = await IqClientApiDotNet.RequestLeaderboardUserinfoDealsClientAsync(countryes, userId);
                _logger.Information(JsonConvert.SerializeObject(leader));
            }
        }
    }
}