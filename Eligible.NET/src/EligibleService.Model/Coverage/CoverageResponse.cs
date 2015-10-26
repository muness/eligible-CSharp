using EligibleService.Model.Coverage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace EligibleService.Model
{
    /// <summary>
    /// Covergae structure
    /// </summary>

    public class CoverageResponse : JsonResponseClass
    {
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("known_issues")]
        public Collection<string> KnownIssues { get; set; }

        [JsonProperty("demographics")]
        public Demographics Demographics { get; set; }

        [JsonProperty("insurance")]
        public Insurence Insurance { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("services")]
        public Collection<Service> Services { get; set; }

    }
}
