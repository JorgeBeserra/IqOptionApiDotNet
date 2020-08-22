using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
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
                /*
                 * During the tests I found that the IQ blocks for a time when there 
                 * are many requests so if you receive timeout errors wait 
                 * about 5 or 10 minutes for the next request.
                 */
                
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                CountryType country = CountryType.Worldwide;
                long from_position = 1;
                long to_position = 10;
                var leader = await IqClientApiDotNet.RequestLeaderboardDealsClientAsync(requestId, country, from_position, to_position);
                _logger.Information(JsonConvert.SerializeObject(leader));
            }
        }
    }
}