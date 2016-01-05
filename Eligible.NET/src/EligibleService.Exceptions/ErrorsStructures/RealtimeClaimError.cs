using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Exceptions
{
    public class RealtimeClaimError
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("errors")]
        public Collection<BasicError> Errors { get; set; }
    }
}
