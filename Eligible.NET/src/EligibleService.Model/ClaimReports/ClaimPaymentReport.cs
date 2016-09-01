using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using EligibleService.Model;
using EligibleService.Claim.ClaimReports;

namespace EligibleService.Model
{
    public class ClaimPaymentReportsResponse : AcknowledgementCommonProperties
    {
        [JsonProperty("reports")]
        public Collection<PaymentReport> Reports { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }

    public class PaymentReport : JsonResponseClass
    {
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("effective_date")]
        public string EffectiveDate { get; set; }

        [JsonProperty("payer")]
        public ReportsPayer Payer { get; set; }

        [JsonProperty("financials")]
        public Financials Financials { get; set; }

        [JsonProperty("payee")]
        public Payee Payee { get; set; }

        [JsonProperty("patient")]
        public Patient Patient { get; set; }

        [JsonProperty("corrected_patient")]
        public Patient CorrectedPatient { get; set; }

        [JsonProperty("other_patient")]
        public Patient OtherPatient { get; set; }

        [JsonProperty("service_provider")]
        public ServiceProvider ServiceProvider { get; set; }

        [JsonProperty("claim")]
        public ReportsClaim Claim { get; set; }
    }
    public class ClaimPaymentReportResponse : PaymentReport
    {
        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }

}
