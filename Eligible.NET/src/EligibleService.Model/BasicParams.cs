using Newtonsoft.Json;

namespace EligibleService.Model
{
    public class BasicParams
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        [JsonProperty("test")]
        public bool? Test { get; set; }
    }
}
