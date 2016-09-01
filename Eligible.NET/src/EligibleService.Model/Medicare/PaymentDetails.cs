using Newtonsoft.Json;
using System;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// Payment Model
    /// </summary>
    public class PaymentDetails
    {
        [JsonProperty("deductible")]
        public double? Deductible { get; set; }

        [JsonProperty("deductible_remaining")]
        public double? DeductibleRemaining { get; set; }

        [JsonProperty("coinsurance_percent")]
        public int? CoinsurancePercent { get; set; }

        [JsonProperty("copayment")]
        public int? Copayment { get; set; }

        [JsonProperty("info_valid_till")]
        public string InfoValidTill { get; set; }

        [JsonProperty("info_valid_until")]
        public string InfoValidUntil { get; set; }
    }
}
