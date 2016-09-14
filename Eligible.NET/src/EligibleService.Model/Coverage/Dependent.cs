using Newtonsoft.Json;

namespace EligibleService.Model.Coverage
{
    /// <summary>
    /// Dependent has these extra fields compared to Subscriber
    /// </summary>
    public class Dependent : Demographic
    {
        [JsonProperty("relationship")]
        public string Relationship { get; set; }

        [JsonProperty("relationship_code")]
        public string RelationshipCode { get; set; }
    }
}
