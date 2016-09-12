using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Exceptions
{
    public class PaymentStatusError
    {
        [JsonProperty("known_issues")]
        public Collection<string> KnownIssues { get; set; }

        [JsonProperty("created_at", ItemConverterType = typeof(JavaScriptDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("error")]
        public PaymentStatusErrorStructure Error { get; set; }
    }

    public class PaymentStatusErrorStructure : CoverageErrorWithoutFollowUpAction
    {
        [JsonProperty("follow-up_action_description")]
        public string FollowUpActionDescription { get; set; }

        [JsonProperty("follow-up_action_code")]
        public string FollowUpActionCode { get; set; }
    }
}
