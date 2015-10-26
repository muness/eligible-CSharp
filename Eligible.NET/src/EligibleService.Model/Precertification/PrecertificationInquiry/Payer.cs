using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Payer
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

}
