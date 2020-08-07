using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetFinancialInformationSample : SampleRunner
    {
        // Get Financial Information from ACTIVE PAIR
        // By: Jorge Beserra
        public override async Task RunSample()
        {
            if (await IqClientApiDotNet.ConnectAsync())
            {
                var financialinformation = await IqClientApiDotNet.GetFinancialInformationAsync(Models.ActivePair.EURUSD);
                _logger.Information(JsonConvert.SerializeObject(financialinformation));
            }
        }
    }
}