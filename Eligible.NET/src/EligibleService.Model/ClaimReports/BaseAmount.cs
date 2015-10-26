using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class BaseAmount
    {
        [JsonProperty("billed")]
        public double? Billed { get; set; }

        [JsonProperty("paid")]
        public double? Paid { get; set; }

        [JsonProperty("total_coverage")]
        public double? TotalCoverage { get; set; }

        [JsonProperty("tax")]
        public double? Tax { get; set; }

        [JsonProperty("total_claim_before_taxes")]
        public double? TotalClaimBeforeTaxes { get; set; }

        [JsonProperty("federal")]
        public Federal Federal { get; set; }
    }

}
