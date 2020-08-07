using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationFininfo
    {
        [JsonProperty("base")]
        public FinancialInformationBase Base { get; set; }

        [JsonProperty("currency")]
        public FinancialInformationBase Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
