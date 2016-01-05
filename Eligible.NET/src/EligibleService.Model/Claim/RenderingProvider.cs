using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class RenderingProvider  : Provider
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("organization_name")]
        public string OrganizationName { get; set; }
        
        [JsonProperty("taxonomy_code")]
        public string TaxonomyCode { get; set; }

    }
}
