using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IqOptionApiDotNet.Models
{
    public class FinancialInformationActive
    {
        [JsonProperty("charts")]
        public FinancialInformationCharts Charts { get; set; }

        [JsonProperty("fininfo")]
        public FinancialInformationFininfo Fininfo { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("index_fininfo")]
        public FinancialInformationIndexFininfo IndexFininfo { get; set; }

        [JsonProperty("media")]
        public FinancialInformationMedia Media { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("ticker")]
        public string Ticker { get; set; }
    }
}
