using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.PaymentStatus
{
    public class ServiceLine
    {
        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        [JsonProperty("procedure_modifiers")]
        public Collection<string> ProcedureModifiers { get; set; }

        [JsonProperty("procedure_qualifier_code")]
        public string ProcedureQualifierCode { get; set; }

        [JsonProperty("procedure_qualifier_label")]
        public string ProcedureQualifierLabel { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("codes")]
        public Collection<Code> Codes { get; set; }

        [JsonProperty("control_number")]
        public string ControlNumber { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }
    }

}
