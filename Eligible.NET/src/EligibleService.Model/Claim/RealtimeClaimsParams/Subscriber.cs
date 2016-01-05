using Newtonsoft.Json;
using EligibleService.Model;

namespace EligibleService.Claim.RealtimeClaimParams
{
    public class Subscriber : Name
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("group_name")]
        public string GroupName { get; set; }
    }

}
