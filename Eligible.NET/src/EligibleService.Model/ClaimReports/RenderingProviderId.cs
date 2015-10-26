using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class RenderingProviderId : Detail
    {
        [JsonProperty("id_type")]
        public string IdType { get; set; }

        [JsonProperty("id_type_label")]
        public string IdTypeLabel { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }      
    }
}
