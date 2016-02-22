using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class Adjustments
    {
        [JsonProperty("adjustment_reason_code")]
        public string AdjustmentReasonCode { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("quantity")]
        public double? Quantity { get; set; }
    }
}
