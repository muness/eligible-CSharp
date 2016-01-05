using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class DurableMedicalEquipment
    {
        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        [JsonProperty("length_of_medical_necessity")]
        public string LengthOfMedicalNecessity { get; set; }

        [JsonProperty("rental_price")]
        public string RentalPrice { get; set; }

        [JsonProperty("purchase_price")]
        public string PurchasePrice { get; set; }

        [JsonProperty("frequency_code")]
        public string FrequencyCode { get; set; }

        [JsonProperty("begin_therapy_date")]
        public string BeginTherapyDate { get; set; }

        [JsonProperty("certificate")]
        public Certificate Certificate { get; set; }

    }

    public class Certificate
    {
        [JsonProperty("recertification_date")]
        public string RecertificationDate { get; set; }

        [JsonProperty("last_certification_date")]
        public string LastCertificationDate { get; set; }

        [JsonProperty("attachment_transmission_code")]
        public string AttachmentTransmissionCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("condition_indicators")]
        public Collection<string> ConditionIndicators { get; set; }

    }
}
