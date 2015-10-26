using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Dependent has these extra fields compared to Subscriber
    /// </summary>
    public class Dependent : Demographic
    {
        [JsonProperty("relation_ship")]
        public string Relationship { get; set; }

        [JsonProperty("relation_ship_code")]
        public string RelationshipCode { get; set; }

        [JsonProperty("dependent_first_name")]
        public string DependentFirstName { get; set; }

        [JsonProperty("dependent_last_name")]
        public string DependentLastName { get; set; }

        [JsonProperty("dependent_dob")]
        public string DependentDob { get; set; }
    }
}
