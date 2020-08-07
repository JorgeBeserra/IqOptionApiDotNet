using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationCharts
    {
        [JsonProperty("dtd")]
        public FinancialInformationDtd Dtd { get; set; }

        [JsonProperty("m1")]
        public FinancialInformationDtd M1 { get; set; }

        [JsonProperty("y1")]
        public FinancialInformationDtd Y1 { get; set; }

        [JsonProperty("ytd")]
        public FinancialInformationDtd Ytd { get; set; }
    }
}
