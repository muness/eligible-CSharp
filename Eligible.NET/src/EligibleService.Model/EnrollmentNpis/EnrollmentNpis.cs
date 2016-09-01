using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    public class EnrollmentNpisResponse : JsonResponseClass
    {
        [JsonProperty("enrollment_npi")]
        public EnrollmentNpi EnrollmentNpi { get; set; }
    }

    public class EnrollmentNpisResponses : AcknowledgementCommonProperties
    {
        [JsonProperty("enrollment_npis")]
        public Collection<EnrollmentNpisResponse> EnrollmentNpis { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }
}
