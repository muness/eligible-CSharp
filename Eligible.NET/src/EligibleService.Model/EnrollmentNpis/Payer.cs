using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.EnrollmentNpis
{
    public class EnrollmentPayer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("names")]
        public Collection<string> Names { get; set; }

        [JsonProperty("endpoints")]
        public Collection<string> Endpoints { get; set; }
    }

}
