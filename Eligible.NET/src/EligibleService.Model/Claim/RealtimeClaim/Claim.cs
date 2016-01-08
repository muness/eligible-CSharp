using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.RealtimeClaims
{
    public class RealClaim
    {
        [JsonProperty("control_number")]
        public string ControlNumber { get; set; }

        [JsonProperty("received_date")]
        public string ReceivedDate { get; set; }

        [JsonProperty("filing_indicator_type")]
        public string FilingIndicatorType { get; set; }

        [JsonProperty("filing_indicator_label")]
        public string FilingIndicatorLabel { get; set; }

        [JsonProperty("place_of_service")]
        public object PlaceOfService { get; set; }

        [JsonProperty("frequency")]
        public object Frequency { get; set; }

        [JsonProperty("responsibility_sequence")]
        public object ResponsibilitySequence { get; set; }

        [JsonProperty("status")]
        public Collection<string> Status { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("service_lines")]
        public Collection<ServiceLine> ServiceLines { get; set; }
    }
}
