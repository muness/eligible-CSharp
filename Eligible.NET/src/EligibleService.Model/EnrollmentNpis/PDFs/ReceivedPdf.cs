using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;

namespace EligibleService.Model
{
    public class ReceivedPdfResponse : JsonResponseClass
    {
        [JsonProperty("received_pdf")]
        public ReceivedPdf ReceivedPdf { get; set; }
    }

    public class ReceivedPdf : PdfResponse
    {
        [JsonProperty("notification_message")]
        public string NotificationMessage { get; set; }
    }
}
