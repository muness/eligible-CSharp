using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Coverage BenefitDetails Model
    /// </summary>
    public class BenefitDetails
    {
        [JsonProperty("benefit_description")]
        public FinancialFlowsList BenefitDescription { get; set; }

        [JsonProperty("managed_care")]
        public FinancialFlowsList ManagedCare { get; set; }

        [JsonProperty("unlimited")]
        public FinancialFlowsList Unlimited { get; set; }
    }
}
