using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class ProviderAdjustment
    {
        [JsonProperty("reason_code")]
        public string ReasonCode { get; set; }

        [JsonProperty("reason_label")]
        public string ReasonLabel { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }
    }
}
