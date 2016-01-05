using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Precertification
{
    public class PatientEvent
    {
        [JsonProperty("place_of_service")]
        public string PlaceOfService { get; set; }

        [JsonProperty("diagnosis_codes")]
        public Collection<string> DiagnosisCodes { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("certification")]
        public Certification Certification { get; set; }

        [JsonProperty("providers")]
        public Collection<Provider> Providers { get; set; }

        [JsonProperty("services")]
        public Collection<Service> Services { get; set; }
    }

}
