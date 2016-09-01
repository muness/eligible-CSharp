using EligibleService.Model.Payer;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    /// <summary>
    /// Common structure for All payers Payers, 
    /// as defined by the United States healthcare industry, 
    /// are parties other than patients such as insurance companies, 
    /// third-party administrators, and government entities
    /// who finance or reimburse the cost of healthcare services.
    /// </summary>
    public class PayerData : JsonResponseClass
    {
        /// <summary>
        /// payer_id - Unique ID assigned by Eligible
        /// </summary>
        [JsonProperty("payer_id")]
        public string PayerId { get; set; }

        /// <summary>
        /// names - List of names of the payer
        /// </summary>
        [JsonProperty("names")]
        public Collection<string> Names { get; set; }

        /// <summary>
        /// created_at - Payer created Date
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// updated_at - Payer last updated Date
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// supported_endpoints - List of Eligible endpoints supported by the payer.
        /// </summary>
        [JsonProperty("supported_endpoints")]
        public Collection<Endpoint> SupportedEndpoints { get; set; }
    }

    public class PayerResponse : PayerData
    {
        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }

    public class PayersResponse : JsonResponseClass
    {
        public Collection<PayerData> Payers { get; set; }

        [JsonProperty("eligible_id")]
        public string EligibleId { get; set; }
    }
}

