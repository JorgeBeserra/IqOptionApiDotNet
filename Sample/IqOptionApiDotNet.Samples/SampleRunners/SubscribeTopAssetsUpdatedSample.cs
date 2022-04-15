using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class SubscribeTopAssetsUpdatedSample : SampleRunner
    {
        

        public override async Task RunSample()
        {
            string requestId;
            
            if (await IqClientApiDotNet.ConnectAsync())
            {
                // subscribe to top assets updated
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.SubscribeTopAssetsUpdated(requestId, InstrumentType.DigitalOption);

                // call the subscribe to listening when mood changed
                /*
                IqClientApiDotNet.WsClient.TopAssetsUpdatedObservable().Subscribe(x => {

                    // values goes here
                    _logger.Information(
                        $"Lives User Id: {x.UserId} Created {x.CreatedAt} Amount: {x.AmountEnrolled} Direction: {x.InstrumentDir}"
                    );

                });
                */
                // hold 2 secs
                Thread.Sleep(2000);

                // after this line no-more realtime top assets updated
                //requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                //IqClientApiDotNet.Uns(requestId, "live-deal-digital-option", ActivePair.EURUSD, DigitalOptionsExpiryType.PT1M);
                
            }
        }
    }
}