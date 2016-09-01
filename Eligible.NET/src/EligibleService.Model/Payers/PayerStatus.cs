using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    /// <summary>
    /// List of Payer Statusses Model
    /// </summary>
    public class StatusResponse : JsonResponseClass
    {
        [JsonProperty("statuses")]
        public Collection<PayerStatus> Statuses { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }

    /// <summary>
    /// Payer status model
    /// </summary>
    public class PayerStatus
    {
        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        [JsonProperty("payer_name")]
        public string PayerName { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
