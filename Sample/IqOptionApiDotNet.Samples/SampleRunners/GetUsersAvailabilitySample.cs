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
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                long[] userId = { 0, 0, 0 };
                var profile = await IqClientApiDotNet.GetUsersAvailabilityAsync(requestId, userId);
                _logger.Information(JsonConvert.SerializeObject(profile));
            }
        }
    }
}