using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class SubscribeTradersMoodSample : SampleRunner{
        public override async Task RunSample(){

            if(await IqClientApiDotNet.ConnectAsync()){

                // call the subscribe to listening when mood changed
                IqClientApiDotNet.WsClient.TradersMoodObservable().Subscribe(x => {

                    // values goes here
                    _logger.Information(
                        $"TradersMood on {x.InstrumentType} - {x.ActivePair} values Higher :{x.Higher}, Lower: {x.Lower}"
                    );

                });

                string requestId;

                // begin subscribe 2 pairs
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.SubscribeTradersMoodChanged(requestId, InstrumentType.BinaryOption, ActivePair.EURUSD);

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.SubscribeTradersMoodChanged(requestId, InstrumentType.BinaryOption, ActivePair.GBPUSD);

                //wait for 10 secs
                await Task.Delay(10000);

                // after unsubscribe GBPUSD moods will not come anymore
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                IqClientApiDotNet.UnSubscribeTradersMoodChanged(requestId, InstrumentType.BinaryOption, ActivePair.GBPUSD);

            }
        }
    }
}