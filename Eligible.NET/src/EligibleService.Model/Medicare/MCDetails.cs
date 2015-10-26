using Newtonsoft.Json;

namespace EligibleService.Model.Medicare
{
    /// <summary>
    /// MC Type model
    /// </summary>
    public class MCDetails : BasicDetails
    {
        [JsonProperty("insurance_type")]
        public string InsuranceType { get; set; }
        [JsonProperty("insurance_type_label")]
        public string InsuranceTypeLabel { get; set; }
        [JsonProperty("mco_bill_option_code")]
        public string McoBillOptionCode { get; set; }
        [JsonProperty("mco_bill_option_label")]
        public string McoBillOptionLabel { get; set; }
        [JsonProperty("locked")]
        public bool Locked { get; set; }
    }
}
