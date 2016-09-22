﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Exceptions
{
    /// <summary>
    /// Eligible Error structure.
    /// </summary>
    public class CoverageError : CoverageErrorWithoutFollowUpAction
    {
        [JsonProperty("follow_up_action_description")]
        public string FollowUpActionDescription { get; set; }

        [JsonProperty("follow_up_action_code")]
        public string FollowUpActionCode { get; set; }
    }

    public class CoverageErrorWithoutFollowUpAction
    {
        [JsonProperty("response_code")]
        public string ResponseCode { get; set; }

        [JsonProperty("response_description")]
        public string ResponseDescription { get; set; }

        [JsonProperty("agency_qualifier_code")]
        public string AgencyQualifierCode { get; set; }

        [JsonProperty("agency_qualifier_description")]
        public string AgencyQualifierDescription { get; set; }

        [JsonProperty("reject_reason_code")]
        public string RejectReasonCode { get; set; }

        [JsonProperty("reject_reason_description")]
        public string RejectReasonDescription { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }
    }

    public class CoverageErrorDetails
    {
        [JsonProperty("created_at", ItemConverterType = typeof(JavaScriptDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("error")]
        public CoverageError Error { get; set; }

        [JsonProperty("known_issues")]
        public Collection<string> KnownIssues { get; set; }
    }
}
