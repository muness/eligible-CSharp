using EligibleService.Claim.ClaimReports;
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

        [JsonProperty("expiration_date")]
        public string ExpirationDate { get; set; }

        [JsonProperty("filing_indicator_type")]
        public string FilingIndicatorType { get; set; }

        [JsonProperty("filing_indicator_label")]
        public string FilingIndicatorLabel { get; set; }

        [JsonProperty("place_of_service")]
        public string PlaceOfService { get; set; }

        [JsonProperty("frequency")]
        public string Frequency { get; set; }

        [JsonProperty("responsibility_sequence")]
        public string ResponsibilitySequence { get; set; }

        [JsonProperty("status")]
        public Collection<string> Status { get; set; }

        [JsonProperty("drg_code")]
        public string DrgCode { get; set; }

        [JsonProperty("drg_quantity")]
        public string DrgQuantity { get; set; }

        [JsonProperty("adjustments")]
        public Collection<ClaimAdjustment> Adjustments { get; set; }

        [JsonProperty("quantity")]
        public ClaimReports.Quantity Quantity { get; set; }

        [JsonProperty("amount")]
        public ClaimReports.Amount Amount { get; set; }

        [JsonProperty("service_lines")]
        public Collection<ServiceLine> ServiceLines { get; set; }

        [JsonProperty("rendering_provider_ids")]
        public Collection<RealRenderingProviderIds> RenderingProviderIds { get; set; }

        [JsonProperty("moa_codes")]
        public Collection<string> MoaCodes { get; set; }

        [JsonProperty("allowed_amount")]
        public double? AllowedAmount { get; set; }
    }

    public class RealRenderingProviderIds
    {
        [JsonProperty("id_type")]
        public string IdType { get; set; }

        [JsonProperty("id_type_label")]
        public string IdTypeLabel { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
