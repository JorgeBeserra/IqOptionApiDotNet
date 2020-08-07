using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetUsersAvailabilitySample : SampleRunner
    {
        // Get Status from Users ID array
        // By: Jorge Beserra
        public override async Task RunSample()
        {
            if (await IqClientApiDotNet.ConnectAsync())
            {
                long[] userId = { 0, 0, 0 };
                var profile = await IqClientApiDotNet.GetUsersAvailabilityAsync(userId);
                _logger.Information(JsonConvert.SerializeObject(profile));
            }
        }
    }
}