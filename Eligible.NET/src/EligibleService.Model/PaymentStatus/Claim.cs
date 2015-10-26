using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.PaymentStatus
{
    public class PaymentClaim
    {
        [JsonProperty("payer_control_number")]
        public string PayerControlNumber { get; set; }

        [JsonProperty("trace_number")]
        public string TraceNumber { get; set; }

        [JsonProperty("bill_type")]
        public string BillType { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("prescription_number")]
        public string PrescriptionNumber { get; set; }

        [JsonProperty("voucher_id")]
        public string VoucherId { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }

        [JsonProperty("statuses")]
        public Collection<Status> Statuses { get; set; }

        [JsonProperty("service_lines")]
        public Collection<ServiceLine> ServiceLines { get; set; }
    }

}
