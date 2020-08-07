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
            if (await IqClientApiDotNet.ConnectAsync())
            {
                var profile = await IqClientApiDotNet.GetUserProfileClientAsync(0);
                
                _logger.Information(JsonConvert.SerializeObject(profile));
            }
        }
    }
}