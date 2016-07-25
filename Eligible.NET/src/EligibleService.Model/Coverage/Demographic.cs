using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Coverage Subscriber/Dependent model
    /// </summary>
    public class Demographic
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("member_id")]
        public string MemberId { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
