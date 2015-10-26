using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Report
    {
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("payer")]
        public RealPayer Payer { get; set; }

        [JsonProperty("financials")]
        public Financials Financials { get; set; }

        [JsonProperty("payee")]
        public Payee Payee { get; set; }

        [JsonProperty("patient")]
        public Patient Patient { get; set; }

        [JsonProperty("claim")]
        public RealClaim Claim { get; set; }
    }

}
