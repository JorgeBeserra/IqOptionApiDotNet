using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationResult
    {

        [JsonProperty("data")]
        public FinancialInformationData Data { get; set; }

    }
}
