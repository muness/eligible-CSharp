using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    /// <summary>
    /// Claim response model after submitting claim
    /// </summary>
    public class ClaimResponse : JsonResponseClass
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("errors")]
        public Collection<EligibleService.Exceptions.ClaimError> Errors { get; set; }
    }
}
