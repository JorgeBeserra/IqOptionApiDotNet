using Newtonsoft.Json;

namespace IqOptionApiDotNet.Models
{
    public partial class UsersAvailabilityResult
    {
         [JsonProperty("statuses")]
         public UsersAvailabilityStatus[] Statuses { get; set; }
    }
}