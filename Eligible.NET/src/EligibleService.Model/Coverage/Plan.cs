using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class Plan
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coverage_status")]
        public string CoverageStatus { get; set; }

        [JsonProperty("coverage_status_label")]
        public string CoverageStatusLabel { get; set; }

        [JsonProperty("plan_number")]
        public string PlanNumber { get; set; }

        [JsonProperty("plan_name")]
        public string PlanName { get; set; }

        [JsonProperty("plan_type")]
        public string PlanType { get; set; }

        [JsonProperty("plan_type_label")]
        public string PlanTypeLabel { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        [JsonProperty("coverage_basis")]
        public Collection<string> CoverageBasis { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<string> Comments { get; set; }

        [JsonProperty("exclusions")]
        public Exclusions Exclusions { get; set; }

        [JsonProperty("financials")]
        public Financials Financials { get; set; }

        [JsonProperty("benefit_details")]
        public BenefitDetails BenefitDetails { get; set; }

        [JsonProperty("additional_insurance_policies")]
        public Collection<AdditionalInsurancePolicy> AdditionalInsurancePolicies { get; set; }
    }
}
