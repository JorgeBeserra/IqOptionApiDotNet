using System;
using System.Threading;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class AlertsSample : SampleRunner
    {


        public override async Task RunSample()
        {
            string requestId;

            if (await IqClientApiDotNet.ConnectAsync())
            {
                // Observable to AlertChanged
                IqClientApiDotNet.AlertChangedObservable.Subscribe(x=> {
                    // values goes here
                    _logger.Information(
                        $"Alert Changed reason {x.Reason} - {x.AssetId} value: {x.Value} {x.Activations}"
                    );
                });

                // Observable to AlertTriggered
                IqClientApiDotNet.AlertTriggeredObservable.Subscribe(x => {
                    // values goes here
                    _logger.Information(
                        $"Alert Triggered - User: {x.UserId} Asset: {x.AssetId} value: {x.Value} Time: {x.Timestamp}"
                    );
                });

                // Get All Alerts
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var alerts = await IqClientApiDotNet.GetAlerts(requestId);
                _logger.Information(JsonConvert.SerializeObject(alerts));

                // Create Alert
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                ActivePair activeId = ActivePair.EURAUD;
                InstrumentType instrumentType = InstrumentType.DigitalOption;
                double value = 200.10;
                int activations = 0; // 1 - For one time OR 2 - For all time
                var alertCreated = await IqClientApiDotNet.CreateAlert(requestId, activeId, instrumentType, value, activations);
                _logger.Information(JsonConvert.SerializeObject(alertCreated));

                // hold 5 secs after update for new value
                Thread.Sleep(5000);

                // Update Alert
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                long alertId = alertCreated.Id; // Get id alert created this sample
                ActivePair newActiveId = ActivePair.EURAUD;
                InstrumentType newInstrumentType = InstrumentType.DigitalOption;
                double newValue = 300.51;
                int newActivations = 0; // 1 - For one time OR 2 - For all time
                var alertUpdated = await IqClientApiDotNet.UpdateAlert(requestId, alertId, newActiveId, newInstrumentType, newValue, newActivations);
                _logger.Information(JsonConvert.SerializeObject(alertUpdated));

                // hold 5 secs after delete
                Thread.Sleep(5000);

                // Delete Alert
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                alertId = alertCreated.Id; // Get id alert created this sample
                var alertDelete = await IqClientApiDotNet.DeleteAlert(requestId, alertId);
                _logger.Information(JsonConvert.SerializeObject(alertDelete));

            }
        }
    }
}