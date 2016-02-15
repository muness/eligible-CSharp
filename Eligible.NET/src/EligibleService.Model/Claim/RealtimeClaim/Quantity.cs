using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Quantity
    {
        [JsonProperty("billed")]
        public int? Billed { get; set; }

        [JsonProperty("paid")]
        public int? Paid { get; set; }
    }

}
