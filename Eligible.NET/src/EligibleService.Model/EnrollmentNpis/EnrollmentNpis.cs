using EligibleService.Model.Claim;
using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

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
    }

}
