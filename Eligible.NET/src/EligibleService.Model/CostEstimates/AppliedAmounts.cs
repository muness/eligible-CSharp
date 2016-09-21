using Newtonsoft.Json;

namespace EligibleService.Model.CostEstimates
{
    public class AppliedAmounts
    {
        [JsonProperty("deductible")]
        public DeductibleMedicare Deductible { get; set; }

        [JsonProperty("coinsurance")]
        public CoinsuranceMedicare Coinsurance { get; set; }

        [JsonProperty("copayment")]
        public DeductibleMedicare Copayment { get; set; }
    }

    public class DeductibleMedicare
    {
        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("limited_by_stop_loss")]
        public bool? LimitedByStopLoss { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }

    public class CoinsuranceMedicare
    {
        [JsonProperty("percent")]
        public double? Percent { get; set; }

        [JsonProperty("applied_to")]
        public double? AppliedTo { get; set; }

        [JsonProperty("amount")]
        public double? Amount { get; set; }

        [JsonProperty("limited_by_stop_loss")]
        public bool? LimitedByStopLoss { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }
}
