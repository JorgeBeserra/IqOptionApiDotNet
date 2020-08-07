using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationMedia
    {
        [JsonProperty("siteBackground")]
        public Uri SiteBackground { get; set; }
    }
}
