using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class Delivery
    {
        [JsonProperty("quantity_type")]
        public string QuantityType { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }
    }

}
