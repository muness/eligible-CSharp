using EligibleService.Claim.ClaimReports;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Claim.RealtimeClaims
{
    public class ServiceLine
    {
        [JsonProperty("procedure_qualifier")]
        public string ProcedureQualifier { get; set; }

        [JsonProperty("procedure_code")]
        public object ProcedureCode { get; set; }

        [JsonProperty("procedure_modifiers")]
        public Collection<object> ProcedureModifiers { get; set; }

        [JsonProperty("revenue_code")]
        public object RevenueCode { get; set; }

        [JsonProperty("service_start")]
        public string ServiceStart { get; set; }

        [JsonProperty("service_end")]
        public string ServiceEnd { get; set; }

        [JsonProperty("amount")]
        public Amount2 Amount { get; set; }

        [JsonProperty("quantity")]
        public Quantity Quantity { get; set; }

        [JsonProperty("adjustments")]
        public Collection<Adjustment> Adjustments { get; set; }

        [JsonProperty("rendering_provider_ids")]
        public Collection<RealRenderingProviderIds> RenderingProviderIds { get; set; }

        [JsonProperty("allowed_amount")]
        public double? AllowedAmount { get; set; }
    }

}
