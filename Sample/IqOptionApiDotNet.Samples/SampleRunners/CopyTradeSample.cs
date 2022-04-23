using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class CopyTradeSample : ISampleRunner
    {
        public async Task RunSample()
        {           
            var trader = new IqOptionApiDotNetClient("a@b.com", "changeme");
            var follower = new IqOptionApiDotNetClient("b@c.com", "changeme");

            await Task.WhenAll(trader.ConnectAsync(), follower.ConnectAsync());

            string requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
            // for binary
            trader.WsClient.OpenOptionObservable().Subscribe(x => {
                follower.BuyAsync(requestId, BalanceType.Practice, x.Active, (int) x.Amount, x.Direction, x.ExpirationTime);
            });

            // for digitals forex and others
            trader.WsClient.PositionChangedObservable().Subscribe(x =>
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                if (x.InstrumentType == InstrumentType.DigitalOption)
                    follower.PlaceDigitalOptions(requestId, x.InstrumentId, x.InvestAmount);
            });
        }
    }
}