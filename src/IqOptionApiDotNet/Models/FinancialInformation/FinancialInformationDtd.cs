using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationDtd
    {
        [JsonProperty("change")]
        public double Change { get; set; }
    }
}
