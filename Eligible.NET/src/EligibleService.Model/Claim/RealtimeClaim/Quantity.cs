using EligibleService.Claim.ClaimReports;
using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Quantity
    {
        [JsonProperty("billed")]
        public double? Billed { get; set; }

        [JsonProperty("paid")]
        public double? Paid { get; set; }

        [JsonProperty("federal")]
        public Federal Federal { get; set; }
    }

}
