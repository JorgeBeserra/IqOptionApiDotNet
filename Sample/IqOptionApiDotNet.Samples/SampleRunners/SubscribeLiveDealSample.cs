using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class SubscribeLiveDealSample : SampleRunner
    {
        

        public override async Task RunSample()
        {
            string requestId;
            
            if (await IqClientApiDotNet.ConnectAsync())
            {
                // subscribe to pair to get real-time data for tf1min and tf5min
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.SubscribeLiveDeal(requestId, "live-deal-digital-option", ActivePair.EURUSD, DigitalOptionsExpiryType.PT1M);

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.SubscribeLiveDeal(requestId, "live-deal-digital-option", ActivePair.EURUSD, DigitalOptionsExpiryType.PT5M);

                // call the subscribe to listening when mood changed
                IqClientApiDotNet.WsClient.LiveDealObservable().Subscribe(x => {

                    // values goes here
                    _logger.Information(
                        $"Lives User Id: {x.UserId} Created {x.CreatedAt} Amount: {x.AmountEnrolled} Direction: {x.InstrumentDir}"
                    );

                });

                // hold 2 secs
                Thread.Sleep(2000);

                // after this line no-more realtime data for min5 print on console
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.UnSubscribeLiveDeal(requestId, "live-deal-digital-option", ActivePair.EURUSD, DigitalOptionsExpiryType.PT1M);

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.UnSubscribeLiveDeal(requestId, "live-deal-digital-option", ActivePair.EURUSD, DigitalOptionsExpiryType.PT5M);
            }
        }
    }
}