using System;
using System.Linq;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class ChangeBalanceSample : SampleRunner
    {
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var profile = await IqClientApiDotNet.GetProfileAsync(requestId);

                var demo = profile.Balances.FirstOrDefault(x => x.Type == BalanceType.Practice);

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                await IqClientApiDotNet.ChangeBalanceAsync(requestId, demo.Id);

                var real = profile.Balances.FirstOrDefault(x => x.Type == BalanceType.Real);

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                await IqClientApiDotNet.ChangeBalanceAsync(requestId, real.Id);

                /*
                Don't forget to check if it is in the live account or in training 
                before taking your Balance Changed tests
                */
                IqClientApiDotNet.BalanceChangedObservable.Subscribe(x => {
                    // values goes here
                    _logger.Information(
                        $"Balance Changed on UserId: {x.UserId} - Amount: {x.CurrentBalance.Amount}, Enrolled Amount: {x.CurrentBalance.EnrolledAmount}"
                    );
                });
            }
        }
    }
}