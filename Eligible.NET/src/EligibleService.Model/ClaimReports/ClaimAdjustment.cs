using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class ClaimAdjustment
    {
        [JsonProperty("type_code")]
        public string TypeCode { get; set; }

        [JsonProperty("type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty("reason_code")]
        public string ReasonCode { get; set; }

        [JsonProperty("reason_label")]
        public string ReasonLabel { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("quantity")]
        public double? Quantity { get; set; }
    }
}
