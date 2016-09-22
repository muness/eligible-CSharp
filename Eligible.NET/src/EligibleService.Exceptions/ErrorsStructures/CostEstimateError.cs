using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Exceptions
{
    public class CostEstimateError
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("known_issues")]
        public Collection<string> KnownIssues { get; set; }

        [JsonProperty("errors")]
        public Collection<CostEstimateWarnings> Errors { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("warnings")]
        public Collection<CostEstimateWarnings> Warnings { get; set; }
    }

    public class CostEstimateWarnings : BasicError
    {
        [JsonProperty("expected_value")]
        public string ExpectedValue { get; set; }

        [JsonProperty("path")]
        public Collection<string> Path { get; set; }
        
    }
}
