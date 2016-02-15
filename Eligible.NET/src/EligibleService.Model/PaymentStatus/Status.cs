using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.PaymentStatus
{
    public class Status
    {
        [JsonProperty("paid")]
        public bool? Paid { get; set; }

        [JsonProperty("adjudication_status")]
        public string AdjudicationStatus { get; set; }

        [JsonProperty("codes")]
        public Collection<Code> Codes { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("finalized_date")]
        public string FinalizedDate { get; set; }

        [JsonProperty("remittance_date")]
        public string RemittanceDate { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("trace_number")]
        public string TraceNumber { get; set; }
    }

}
