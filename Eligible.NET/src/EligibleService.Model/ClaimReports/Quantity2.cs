using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Quantity2
    {
        [JsonProperty("billed")]
        public double? Billed { get; set; }

        [JsonProperty("paid")]
        public double? Paid { get; set; }

        [JsonProperty("federal")]
        public FederalQuantity Federal { get; set; }
    }

    public class FederalQuantity
    {

        [JsonProperty("category_1")]
        public int? Category1 { get; set; }

        [JsonProperty("category_2")]
        public int? Category2 { get; set; }

        [JsonProperty("category_3")]
        public int? Category3 { get; set; }

        [JsonProperty("category_4")]
        public int? Category4 { get; set; }

        [JsonProperty("category_5")]
        public int? Category5 { get; set; }
    }

}
