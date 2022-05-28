using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Ws.Base;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class SubscribeBalanceChangedSample : SampleRunner
    {
        
        public override async Task RunSample()
        {
            string requestId;
            
            if (await IqClientApiDotNet.ConnectAsync())
            {
                // subscribe to balance changed
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.SubscribeBalanceChanged(requestId);               

                // call the subscribe to listening when mood changed
                
                /* IqClientApiDotNet.BalanceChangedObservable().Subscribe(x => {

                    // values goes here
                    _logger.Information(
                        $"Balance Changed...!!!"
                    );

                });*/
                
                // hold 10 secs
                Thread.Sleep(10000);

                // after this line no-more realtime data for min5 print on console
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.UnSubscribeBalanceChanged(requestId);

            }
        }
    }
}