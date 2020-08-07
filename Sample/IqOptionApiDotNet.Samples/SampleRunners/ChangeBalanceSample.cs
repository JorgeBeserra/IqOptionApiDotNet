using System.Linq;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class ChangeBalanceSample : SampleRunner
    {
        public override async Task RunSample()
        {
            if (await IqClientApiDotNet.ConnectAsync())
            {
                var profile = await IqClientApiDotNet.GetProfileAsync();

                var demo = profile.Balances.FirstOrDefault(x => x.Type == BalanceType.Practice);
                await IqClientApiDotNet.ChangeBalanceAsync(demo.Id);

                var real = profile.Balances.FirstOrDefault(x => x.Type == BalanceType.Real);
                await IqClientApiDotNet.ChangeBalanceAsync(real.Id);
            }
        }
    }
}