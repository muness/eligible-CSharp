using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model
{
    public class OriginalSignaturePdfResponse : JsonResponseClass
    {
        [JsonProperty("original_signature_pdf")]
        public PdfResponse OriginalSignaturePdf { get; set; }
    }

    public class OriginalSignaturePdfDeleteResponse : JsonResponseClass
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
