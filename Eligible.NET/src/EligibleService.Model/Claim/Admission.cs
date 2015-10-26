using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class Admission
    {
        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("hour")]
        public string Hour { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("diagnosis_code")]
        public string DiagnosisCode { get; set; }

        [JsonProperty("patient_status_code")]
        public string PatientStatusCode { get; set; }
    }
}
