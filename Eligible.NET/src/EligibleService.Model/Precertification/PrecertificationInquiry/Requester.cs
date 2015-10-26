using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Requester : Name
    {
        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("taxonomy_code")]
        public string TaxonomyCode { get; set; }
    }

}
