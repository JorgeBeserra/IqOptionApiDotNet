using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetUserProfileClientSample : SampleRunner
    {
        // Get User Profile Client Informations Using ID User
        // By: Jorge Beserra
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var profile = await IqClientApiDotNet.GetUserProfileClientAsync(requestId, 0);
                
                _logger.Information(JsonConvert.SerializeObject(profile));
            }
        }
    }
}