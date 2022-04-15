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
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var financialinformation = await IqClientApiDotNet.GetFinancialInformationAsync(requestId, Models.ActivePair.EURUSD);
                _logger.Information(JsonConvert.SerializeObject(financialinformation));
            }
        }
    }
}