using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Subscriber : Name
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

}
