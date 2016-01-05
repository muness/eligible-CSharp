using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class Adjustments
    {
        [JsonProperty("adjustment_reason_code")]
        public Collection<string> AdjustmentReasonCode { get; set; }

        [JsonProperty("amount")]
        public Collection<string> Amount { get; set; }

        [JsonProperty("quantity")]
        public Collection<string> Quantity { get; set; }

    }
}
