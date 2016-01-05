using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Exceptions
{
    public class ClaimErrors
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("errors")]
        public Collection<ClaimError> Errors { get; set; }
    }
    public class ClaimError : BasicError
    {
        [JsonProperty("expected_value")]
        public string ExpectedValue { get; set; }
    }
}
