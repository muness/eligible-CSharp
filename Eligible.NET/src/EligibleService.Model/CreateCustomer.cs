using Newtonsoft.Json;

namespace EligibleService.Model.Customer
{
    public class CustomerParams
    {
        [JsonProperty("customer")]
        public CustomerTag Customer { get; set; }
    }

    public class CustomerTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }
    }
}
