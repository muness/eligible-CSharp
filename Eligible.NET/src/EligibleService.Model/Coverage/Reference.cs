using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    public class Reference
    {
        [JsonProperty("reference_code")]
        public string ReferenceCode { get; set; }

        [JsonProperty("reference_label")]
        public string ReferenceLabel { get; set; }

        [JsonProperty("reference_number")]
        public string ReferenceNumber { get; set; }
    }
}
