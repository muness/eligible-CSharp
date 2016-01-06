using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;

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
