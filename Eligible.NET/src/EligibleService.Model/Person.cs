using Newtonsoft.Json;

namespace EligibleService.Model
{
    public class Person : Name 
    {
        public string PhoneNumber { get; set; }
        [JsonProperty("address")]
        public Address Address { get; set; }

    }

    public class Name
    {
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
    }
}
