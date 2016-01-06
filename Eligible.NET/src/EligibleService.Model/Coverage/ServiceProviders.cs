using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class ServiceProviders
    {
        [JsonProperty("physicians")]
        public Collection<Physician> Physicians { get; set; }
    }
}
