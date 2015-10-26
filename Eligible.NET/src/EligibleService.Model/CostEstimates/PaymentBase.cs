using EligibleService.Model.Coverage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    public class PaymentBase
    {
        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("insurance_type")]
        public string InsuranceType { get; set; }

        [JsonProperty("insurance_type_label")]
        public string InsuranceTypeLabel { get; set; }

        [JsonProperty("pos")]
        public string Pos { get; set; }

        [JsonProperty("pos_label")]
        public string PosLabel { get; set; }

        [JsonProperty("authorization_required")]
        public string AuthorizationRequired { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("quantity_code")]
        public string QuantityCode { get; set; }

        [JsonProperty("quantity_label")]
        public string QuantityLabel { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<String> Comments { get; set; }
    }
}
