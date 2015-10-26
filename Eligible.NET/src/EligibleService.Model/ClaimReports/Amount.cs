using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Amount : BaseAmount
    {
        [JsonProperty("patient_responsibility")]
        public double? PatientResponsibility { get; set; }

        [JsonProperty("prompt_payment_discount")]
        public double? PromptPaymentDiscount { get; set; }

        [JsonProperty("per_day_limit")]
        public double? PerDayLimit { get; set; }

        [JsonProperty("patient_paid")]
        public double? PatientPaid { get; set; }

        [JsonProperty("revised_intrest")]
        public double? RevisedIntrest { get; set; }

        [JsonProperty("negetive_ladger_balance")]
        public double? NegetiveLadgerBalance { get; set; }
    }

    public class Amount2 : BaseAmount
    {
        [JsonProperty("deduction")]
        public double? Deduction { get; set; }
    }

}
