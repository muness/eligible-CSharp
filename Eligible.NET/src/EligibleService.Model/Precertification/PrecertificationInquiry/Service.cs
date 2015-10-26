using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Precertification
{

    public class Service
    {

        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        [JsonProperty("procedure_modifiers")]
        public Collection<string> ProcedureModifiers { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }

        [JsonProperty("certification")]
        public ServiceCertification Certification { get; set; }

        [JsonProperty("providers")]
        public Collection<Provider> Providers { get; set; }
    }

}
