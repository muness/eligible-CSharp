using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Exceptions
{
    public class EligibleGenericError
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("errors")]
        public Collection<GenericError> Errors { get; set; }
    }

    public class GenericError : BasicError
    {
        [JsonProperty("expected_value")]
        public string ExpectedValue { get; set; }
    }

    public class CostEstimateError : EligibleGenericError
    {
        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
        [JsonProperty("warnings")]
        public Collection<Exceptions.GenericError> Warnings { get; set; }
    }

    public class MedicareCostEstimateError : EligibleGenericError
    {
        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }
}
