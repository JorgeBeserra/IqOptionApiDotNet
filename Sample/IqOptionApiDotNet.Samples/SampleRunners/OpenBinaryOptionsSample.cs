using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class OpenBinaryOptionsSample : SampleRunner
    {
        public override async Task RunSample()
        {
            if (await IqClientApiDotNet.ConnectAsync())
            {
                string requestId;
                while (true)
                {
                    await Task.Delay(5000);
                    requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    var result = await IqClientApiDotNet.BuyAsync(requestId, ActivePair.EURUSD_OTC, (decimal)1.5, OrderDirection.Call,
                        DateTimeOffset.Now);
                    Console.WriteLine($"PositionId = {result.PositionId}");
                }
            }
        }
    }
}