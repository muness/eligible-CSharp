using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace EligibleService.Exceptions
{
    /// <summary>
    /// Eligible Error structure.
    /// </summary>
    public class CoverageError
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

        public string FollowUpActionDescription { get; set; }

        public string FollowUpActionCode { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var payer_keys = _additionalData.Keys;
            string followUpActionDescription = null;
            string followUpActionCode = null;
            foreach (string payer_key in payer_keys)
            {
                if (payer_key.Contains("follow_up_action_description") || payer_key.Contains("follow-up_action_description"))
                {
                    followUpActionDescription = payer_key;
                }
                else if (payer_key.Contains("follow_up_action_code") || payer_key.Contains("follow-up_action_code"))
                {
                    followUpActionCode = payer_key;
                }
            }

            if (followUpActionDescription != null)
                FollowUpActionDescription = _additionalData[followUpActionDescription].ToString();

            if (followUpActionCode != null)
                FollowUpActionCode = _additionalData[followUpActionCode].ToString();
        }

        public CoverageError()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
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
