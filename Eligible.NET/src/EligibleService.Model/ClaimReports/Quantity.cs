using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Quantity
    {
        [JsonProperty("actual")]
        public Actual Actual { get; set; }

        [JsonProperty("estimated")]
        public Estimated Estimated { get; set; }

        [JsonProperty("not_replaced_blood_unit")]
        public int? NotReplacedBloodUnit { get; set; }

        [JsonProperty("outlier_days")]
        public int? OutlierDays { get; set; }

        [JsonProperty("prescription")]
        public int? Prescription { get; set; }

        [JsonProperty("visits")]
        public int? Visits { get; set; }

        [JsonProperty("federal")]
        public Federal Federal { get; set; }
    }

    public class Federal
    {

        [JsonProperty("category_1")]
        public double? Category1 { get; set; }

        [JsonProperty("category_2")]
        public double? Category2 { get; set; }

        [JsonProperty("category_3")]
        public double? Category3 { get; set; }

        [JsonProperty("category_4")]
        public double? Category4 { get; set; }

        [JsonProperty("category_5")]
        public double? Category5 { get; set; }
    }

}
