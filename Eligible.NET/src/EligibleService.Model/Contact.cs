using Newtonsoft.Json;
namespace EligibleService.Model
{
    /// <summary>
    /// Contact format used by Coverage and Medicare
    /// </summary>
    public class Contact
    {
        [JsonProperty("contact_type")]
        public string ContactType { get; set; }

        [JsonProperty("contact_value")]
        public string ContactValue { get; set; }
    }
}
