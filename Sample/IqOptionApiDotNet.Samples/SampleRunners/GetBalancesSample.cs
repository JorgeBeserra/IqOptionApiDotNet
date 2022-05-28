using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetBalancesSample : SampleRunner
    {

        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);

                BalanceType[] balanceType = new BalanceType[] { BalanceType.Real, BalanceType.Practice };

                var balances = await IqClientApiDotNet.GetBalancesAsync(requestId, balanceType);

                _logger.Information(JsonConvert.SerializeObject(balances));
            }
        }
    }
}