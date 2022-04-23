using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class SetUserSettingsSample : SampleRunner
    {        
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var userSettings = await IqClientApiDotNet.SetUserSettings(requestId);
                _logger.Information(JsonConvert.SerializeObject(userSettings));
            }
        }
    }
}
