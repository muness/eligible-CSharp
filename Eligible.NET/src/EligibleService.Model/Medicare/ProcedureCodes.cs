using Newtonsoft.Json;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Medicare Procedure codes
    /// </summary>
    public class ProcedureCodes : PaymentDetails
    {
        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        [JsonProperty("procedure_label")]
        public string ProcedureLabel { get; set; }

        [JsonProperty("plan_type")]
        public string PlanType { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("next_eligible_date")]
        public EligibleDate NextEligibleDate { get; set; }
    }
}
