using Newtonsoft.Json;

namespace EligibleService.Model.PaymentStatus
{
    public class Amount
    {
        [JsonProperty("billed")]
        public double? Billed { get; set; }

        [JsonProperty("paid")]
        public double? Paid { get; set; }
    }

}
