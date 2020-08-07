using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationData
    {
        [JsonProperty("active")]
        public FinancialInformationActive Active { get; set; }
    }
}
