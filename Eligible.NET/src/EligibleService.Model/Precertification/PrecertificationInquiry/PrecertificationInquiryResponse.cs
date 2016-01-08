using EligibleService.Model.Precertification;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    public class PrecertificationInquiryResponse : JsonResponseClass
    {
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }

        [JsonProperty("payer")]
        public EligibleService.Model.Precertification.Payer Payer { get; set; }

        [JsonProperty("requester")]
        public Requester Requester { get; set; }

        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        [JsonProperty("dependent")]
        public Dependent Dependent { get; set; }

        [JsonProperty("patient_events")]
        public Collection<PatientEvent> PatientEvents { get; set; }
    }

}
