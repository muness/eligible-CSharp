using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.CostEstimates
{
    public class Estimate
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("type_label")]
        public string TimeLabel { get; set; }

        [JsonProperty("plan_type")]
        public string PlanType { get; set; }

        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("deductible")]
        public double? Deductible { get; set; }

        [JsonProperty("deductible_remaining")]
        public double? DeductibleRemaining { get; set; }

        [JsonProperty("coinsurance_percent")]
        public int? CoinsurancePercent { get; set; }

        [JsonProperty("copayment")]
        public bool? Copayment { get; set; }

        [JsonProperty("info_valid_till")]
        public string InfoValidTill { get; set; }

        [JsonProperty("info_valid_until")]
        public string InfoValidUntil { get; set; }

        [JsonProperty("visits")]
        public Collection<Visits> Visits { get; set; }
    }
}
