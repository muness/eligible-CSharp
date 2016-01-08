using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Dependent
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("ssn")]
        public string Ssn { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("relationship_code")]
        public string RelationshipCode { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

}
