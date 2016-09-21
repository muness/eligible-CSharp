using EligibleService.Model.CostEstimates;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class FinancialFlow : StopLossFinancialFlow
    {
        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_label")]
        public string TimePeriodLabel { get; set; }

        [JsonProperty("service_delivery")]
        public ServiceDelivery ServiceDelivery { get; set; }
    }

    public class FinancialFlowRemainings : StopLossFinancialFlow
    {
        [JsonProperty("service_delivery")]
        public ServiceDelivery ServiceDelivery { get; set; }
    }

    public class StopLossFinancialFlow
    {
        [JsonProperty("amount")]
        public string Amount { get; set; }

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
        public bool? AuthorizationRequired { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("contact_details")]
        public Collection<ContactDetail> ContactDetails { get; set; }

        [JsonProperty("dates")]
        public Collection<Dates> Dates { get; set; }

        [JsonProperty("comments")]
        public Collection<String> Comments { get; set; }

        [JsonProperty("quantity_code")]
        public string QuantityCode { get; set; }

        [JsonProperty("quantity_label")]
        public string QuantityLabel { get; set; }

        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        [JsonProperty("copayment")]
        public bool? Copayment { get; set; }

        [JsonProperty("coinsurance")]
        public bool? Coinsurance { get; set; }

        [JsonProperty("deductible")]
        public bool? Deductible { get; set; }

        [JsonProperty("service_type")]
        public string ServiceType { get; set; }
    }

    public class StopLossFinancialFlowTotal : StopLossFinancialFlow
    {
        [JsonProperty("time_period")]
        public string TimePeriod { get; set; }

        [JsonProperty("time_period_label")]
        public string TimePeriodLabel { get; set; }
    }
}
