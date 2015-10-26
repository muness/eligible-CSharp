using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model
{

    public class ClaimAcknowledgementsResponse : AcknowledgementCommonProperties
    {
        [JsonProperty("acknowledgements")]
        public Collection<Acknowledgement> Acknowledgements { get; set; }

        [JsonProperty("payer_control_number")]
        public string PayerControlNumber { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

    }


    public class AcknowledgementCommonProperties : JsonResponseClass
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("num_of_pages")]
        public int? NumOfPages { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
    public class Acknowledgement
    {
        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("errors")]
        public Collection<EligibleService.Exceptions.ClaimError> Errors { get; set; }
    }


    public class MultipleAcknowledgementsResponse : AcknowledgementCommonProperties
    {
        [JsonProperty("acknowledgements")]
        public Collection<MultipleAcknowledgementFormat> Acknowledgements { get; set; }
    }


    public class MultipleAcknowledgementFormat
    {
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("payer_control_number")]
        public string PayerControlNumber { get; set; }

        [JsonProperty("submission_status")]
        public string SubmissionStatus { get; set; }

        [JsonProperty("codes")]
        public AcknowledgeCodes Codes { get; set; }
    }


    public class AcknowledgeCodes
    {
        [JsonProperty("category_code")]
        public string CategoryCode { get; set; }

        [JsonProperty("category_label")]
        public string CategoryLabel { get; set; }

        [JsonProperty("status_code")]
        public string StatusCode { get; set; }

        [JsonProperty("status_label")]
        public string StatusLabel { get; set; }
    }
}
