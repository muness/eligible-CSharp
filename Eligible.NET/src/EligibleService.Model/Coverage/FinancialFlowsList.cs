using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class FinancialFlowsList
    {
        [JsonProperty("amounts")]
        public Collection<Amounts> Amounts { get; set; }
    }

    public class Amounts
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_label")]
        public string TimePeriodLabel { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("insurance_type")]
        public string InsuranceType { get; set; }

        [JsonProperty("insurance_type_label")]
        public string InsuranceTypeLabel { get; set; }

        [JsonProperty("pos")]
        public string Pos { get; set; }

        [JsonProperty("pos_label")]
        public string PosLabel { get; set; }

        [JsonProperty("authorization_required")]
        public bool? AuthorizationRequired { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<String> Comments { get; set; }
    }

    public class LimitationsFinancialFlowsList
    {
        [JsonProperty("amounts")]
        public Collection<LimitationsFinancialAmount> Amounts { get; set; }
    }

    public class LimitationsFinancialAmount : Amounts
    {
        [JsonProperty("quantity_code")]
        public string QuantityCode { get; set; }

        [JsonProperty("quantity_label")]
        public string QuantityLabel { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }
    }

}
