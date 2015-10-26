
using Newtonsoft.Json;
namespace EligibleService.Model
{
    /// <summary>
    /// Common Address structure used by Coverages,Payers and Medicare
    /// </summary>
    public class Address
    {
        [JsonProperty("street_line_1")]
        public string StreetLine1 { get; set; }
        [JsonProperty("street_line_2")]
        public string StreetLine2 { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("zip")]
        public string Zip { get; set; }
    }
}
