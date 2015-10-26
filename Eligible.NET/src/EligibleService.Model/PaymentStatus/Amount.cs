using Newtonsoft.Json;

namespace EligibleService.Model.PaymentStatus
{
    public class Amount
    {
        [JsonProperty("billed")]
        public int? Billed { get; set; }

        [JsonProperty("paid")]
        public double? Paid { get; set; }
    }

}
