using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetCurrencySample : SampleRunner
    {        
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                string currencyName = "USD";
                var userSettings = await IqClientApiDotNet.GetCurrencyAsync(requestId, currencyName);
                _logger.Information(JsonConvert.SerializeObject(userSettings));
            }
        }
    }
}
