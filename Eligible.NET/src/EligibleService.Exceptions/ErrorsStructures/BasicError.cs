using Newtonsoft.Json;

namespace EligibleService.Exceptions
{
    public class BasicError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("param")]
        public string Param { get; set; }
    }
}
