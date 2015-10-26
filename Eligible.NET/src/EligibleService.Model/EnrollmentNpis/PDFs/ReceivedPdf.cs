using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
