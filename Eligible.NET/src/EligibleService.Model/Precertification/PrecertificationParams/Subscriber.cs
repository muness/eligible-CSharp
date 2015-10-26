using EligibleService.Model;
using Newtonsoft.Json;
namespace EligibleService.Claim.Precert
{
    public class PrecertSubscriber
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }
    }

}
