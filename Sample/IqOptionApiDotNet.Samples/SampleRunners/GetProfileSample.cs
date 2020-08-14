using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetProfileSample : SampleRunner
    {


        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var profile = await IqClientApiDotNet.GetProfileAsync(requestId);
                _logger.Information(JsonConvert.SerializeObject(profile));
            }
        }
    }
}