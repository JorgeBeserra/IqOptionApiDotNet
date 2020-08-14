using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class SubscribeRealtimeCandlesSample : SampleRunner
    {
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                // subscribe to pair to get real-time data for tf1min and tf5min
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var streamMin1 = await IqClientApiDotNet.SubscribeRealtimeQuoteAsync(requestId, ActivePair.EURUSD_OTC, TimeFrame.Min1);

                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var streamMin5 = await IqClientApiDotNet.SubscribeRealtimeQuoteAsync(requestId, ActivePair.EURUSD_OTC, TimeFrame.Min5);

                streamMin5.Merge(streamMin1)
                    .Subscribe(candleInfo =>
                    {
                        Console.WriteLine(
                            $"Now {ActivePair.EURUSD_OTC} {candleInfo.TimeFrame} : Bid={candleInfo.Bid}\t Ask={candleInfo.Ask}\t");
                    });


                // hold 2 secs
                Thread.Sleep(2000);

                // after this line no-more realtime data for min5 print on console
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                await IqClientApiDotNet.UnSubscribeRealtimeData(requestId, ActivePair.EURUSD_OTC, TimeFrame.Min5);
            }
        }
    }
}