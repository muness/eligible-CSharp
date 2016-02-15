using Newtonsoft.Json;

namespace EligibleService.Claim.RealtimeClaims
{
    public class Financials
    {
        [JsonProperty("type_code")]
        public string TypeCode { get; set; }

        [JsonProperty("type_label")]
        public string TypeLabel { get; set; }

        [JsonProperty("total_payment_amount")]
        public string TotalPaymentAmount { get; set; }

        [JsonProperty("credit")]
        public bool? Credit { get; set; }

        [JsonProperty("debit")]
        public bool? Debit { get; set; }

        [JsonProperty("payment_method_code")]
        public string PaymentMethodCode { get; set; }

        [JsonProperty("payment_method_label")]
        public string PaymentMethodLabel { get; set; }

        [JsonProperty("payment_format_code")]
        public string PaymentFormatCode { get; set; }

        [JsonProperty("payment_format_label")]
        public string PaymentFormatLabel { get; set; }

        [JsonProperty("payment_date")]
        public string PaymentDate { get; set; }

        [JsonProperty("payment_trace_number")]
        public string PaymentTraceNumber { get; set; }

        [JsonProperty("sender")]
        public Sender Sender { get; set; }

        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }
    }

}
