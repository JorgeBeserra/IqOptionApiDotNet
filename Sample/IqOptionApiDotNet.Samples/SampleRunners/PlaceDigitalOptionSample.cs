using System;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.DigitalOptions;
using IqOptionApiDotNet.Ws;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class PlaceDigitalOptionSample : SampleRunner
    {
        public override async Task RunSample()
        {
            
            string requestId;
            if(await IqClientApiDotNet.ConnectAsync())
            {
                // Validando Instrument Index
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var instrument = await IqClientApiDotNet.GetInstrumentsAsync(requestId, ActivePair.EURUSD);

                Console.WriteLine($"Placed position Id: {instrument.Message.Instruments[0].Index}");

                IqClientApiDotNet.WsClient?.PositionChangedObservable().Subscribe(x =>
                {
                    Console.WriteLine(string.Format("PortfolioChange - {0}, InstrumentId: {1}, Side: {2} {3}, Margin(Amount): {4}",
                        x.Id,
                        x.InstrumentId,
                        x.PortfolioChangedEventInfo.Status,
                        x.PortfolioChangedEventInfo.Type,
                        x.InvestAmount));
                });

                while (true)
                {
                    await Task.Delay(TimeSpan.FromSeconds(10));
                    requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                    var position = await IqClientApiDotNet.PlaceDigitalOptions(requestId, ActivePair.EURUSD, OrderDirection.Call, DigitalOptionsExpiryDuration.M1, 5);

                    Console.WriteLine($"Placed position Id: {position.Id}");
                }
            }
        }
    }
}