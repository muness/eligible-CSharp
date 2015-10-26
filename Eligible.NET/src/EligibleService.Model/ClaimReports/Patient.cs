using Newtonsoft.Json;

namespace EligibleService.Claim.ClaimReports
{
    public class Patient
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
