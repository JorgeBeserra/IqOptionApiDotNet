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

                // Observable to AlertChanged
                IqClientApiDotNet.BalanceChangedObservable.Subscribe(x => {
                    // values goes here
                    _logger.Information(
                        $"Alert Changed reason {x.CurrentBalance}"
                    );
                });

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                
                BalanceType[] balanceType = new BalanceType[] { BalanceType.Practice };

                var balances = await IqClientApiDotNet.GetBalancesAsync(requestId, balanceType);

                Balance balance = balances.FirstOrDefault(x => x.Type == BalanceType.Practice);

                IqClientApiDotNet.balanceType = BalanceType.Practice;

                /*
                Don't forget to check if it is in the live account or in training 
                before taking your Balance Changed tests
                */

                _logger.Information(
                        $"Balance Changed on UserId: {balance.UserId} - Amount: {balance.Amount}, Enrolled Amount: {balance.EnrolledAmount}"
                    );

            }
        }
    }
}