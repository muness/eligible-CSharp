using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    public class Financial : FinancialRemainings
    {
        [JsonProperty("spent")]
        public FinancialFlows Spent { get; set; }

        [JsonProperty("totals")]
        public FinancialFlows Totals { get; set; }
    }

    public class FinancialRemainings
    {
        [JsonProperty("remainings")]
        public FinancialFlows Remainings { get; set; }
    }
}
