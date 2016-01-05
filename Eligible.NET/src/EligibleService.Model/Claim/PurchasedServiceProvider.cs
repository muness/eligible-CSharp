using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class PurchasedServiceProvider
    {
        [JsonProperty("entity")]
        public string Entity { get; set; }

        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("secondary_id_type")]
        public string SecondaryIdType { get; set; }

        [JsonProperty("secondary_id")]
        public string SecondaryId { get; set; }
    }
}
