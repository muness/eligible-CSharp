using Newtonsoft.Json;
using EligibleService.Model;

namespace EligibleService.Claim.RealtimeClaimParams
{
    public class Dependent
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }

}
