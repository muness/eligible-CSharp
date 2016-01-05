using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class AttendingProvider : Name
    {
        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("taxonomy_code")]
        public string TaxonomyCode { get; set; }
    }
}
