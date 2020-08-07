using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
