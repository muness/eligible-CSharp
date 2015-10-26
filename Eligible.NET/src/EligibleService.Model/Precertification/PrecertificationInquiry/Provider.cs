using Newtonsoft.Json;

namespace EligibleService.Model.Precertification
{
    public class Provider : Requester
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

}
