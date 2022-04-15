using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IqOptionApiDotNet.Samples.SampleRunners
{
    public class GetInitializationDataSample : SampleRunner
    {        
        public override async Task RunSample()
        {
            string requestId;
            if (await IqClientApiDotNet.ConnectAsync())
            {
                requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var initializationData = await IqClientApiDotNet.GetInitializationData(requestId);

                var binarias = initializationData.BinaryOption.Actives;
                var str = new StringBuilder();

                //Ativos abertos
                foreach(var ativo in binarias)
                {
                    if (ativo.Value.Enabled && !ativo.Value.IsSuspended)
                    {
                        str.AppendLine(ativo.Key.ToString());
                    }
                }

                _logger.Information(JsonConvert.SerializeObject(initializationData));
                _logger.Information(str.ToString());
            }
        }
    }
}
