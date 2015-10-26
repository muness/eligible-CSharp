using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class SupplementalInformation
    {
        [JsonProperty("report_type_code")]
        public string ReportTypeCode { get; set; }

        [JsonProperty("report_type")]
        public string ReportType { get; set; }

        [JsonProperty("report_transmission_code")]
        public string ReportTransmissionCode { get; set; }

        [JsonProperty("attachment_id")]
        public string AttachmentId { get; set; }

        [JsonProperty("certificate_medical_necessity")]
        public string CertificateMedicalNecessity { get; set; }

        [JsonProperty("supported_documentation")]
        public string SupportedDocumentation { get; set; }

    }
}
