using EligibleService.Model;
using Newtonsoft.Json;

namespace EligibleService.Claim.Precert
{
    public class PrecertDependent
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }
    }

}
