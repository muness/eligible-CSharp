using Newtonsoft.Json;

namespace EligibleService.Model.Claim
{
    public class Receiver
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
