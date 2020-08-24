using System;
using System.Linq;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class ResetTrainingBalanceSample : SampleRunner
    {
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.ResetTrainingBalanceAsync(requestId);
            }
        }
    }
}