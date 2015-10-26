using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.ClaimReports
{
    public class ServiceLine
    {
        [JsonProperty("procedure_qualifier")]
        public string ProcedureQualifier { get; set; }

        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        [JsonProperty("procedure_modifiers")]
        public Collection<string> ProcedureModifiers { get; set; }

        [JsonProperty("revenue_code")]
        public string RevenueCode { get; set; }

        [JsonProperty("service_start")]
        public string ServiceStart { get; set; }

        [JsonProperty("service_end")]
        public string ServiceEnd { get; set; }

        [JsonProperty("amount")]
        public Amount2 Amount { get; set; }

        [JsonProperty("quantity")]
        public Quantity2 Quantity { get; set; }

        [JsonProperty("rendering_provider_ids")]
        public Collection<RenderingProviderId> RenderingProviderIds { get; set; }

        [JsonProperty("allowed_amount")]
        public double AllowedAmount { get; set; }

        [JsonProperty("additional_ids")]
        public Collection<Detail> AdditionalIds { get; set; }

        [JsonProperty("remark_codes")]
        public Collection<Detail> RemarkCodes { get; set; }

        [JsonProperty("provider_control_number")]
        public string ProviderControlNumber { get; set; }

        [JsonProperty("healthcare_policy")]
        public Collection<string> HealthcarePolicy { get; set; }

        [JsonProperty("adjustments")]
        public Collection<ClaimAdjustment> Adjustments { get; set; }
    }

}
