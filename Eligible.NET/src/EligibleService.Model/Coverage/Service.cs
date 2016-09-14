using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class Service
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty("coverage_status")]
        public string CoverageStatus { get; set; }

        [JsonProperty("coverage_status_label")]
        public string CoverageStatusLabel { get; set; }

        [JsonProperty("facility")]
        public FinancialFlowsList Facility { get; set; }

        [JsonProperty("coverage_basis")]
        public Collection<CoverageBasis> CoverageBasis { get; set; }

        [JsonProperty("noncovered")]
        public Collection<NonCovered> NonCovered { get; set; }

        [JsonProperty("benefit_details")]
        public BenefitDetails BenefitDetails { get; set; }

        [JsonProperty("financials")]
        public Financials Financials { get; set; }

        [JsonProperty("visits")]
        public Financial Visits { get; set; }

        [JsonProperty("additional_insurance_policies")]
        public Collection<AdditionalInsurancePolicy> AdditionalInsurancePolicies { get; set; }
    }
}
