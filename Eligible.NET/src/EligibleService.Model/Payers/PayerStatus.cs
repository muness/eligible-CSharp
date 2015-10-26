using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model
{
    /// <summary>
    /// List of Payer Statusses Model
    /// </summary>
    

    public class StatusResponse : JsonResponseClass
    {
        [JsonProperty("statuses")]
        public Collection<PayerStatus> Statuses { get; set; }
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
