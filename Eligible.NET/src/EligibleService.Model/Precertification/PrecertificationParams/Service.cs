using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class PrecertService
    {
        [JsonProperty("claim_type")]
        public string ClaimType { get; set; }

        [JsonProperty("service_type_code")]
        public string ServiceTypeCode { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }
    }

}
