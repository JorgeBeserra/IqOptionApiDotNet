using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetTopAssetsSample : SampleRunner
    {
        // Get User Profile Client Informations Using ID User
        // By: Jorge Beserra
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var topAssets = await IqClientApiDotNet.GetTopAssetsAsync(requestId, InstrumentType.DigitalOption);
                _logger.Information(JsonConvert.SerializeObject(topAssets.Data));
            }
        }
    }
}