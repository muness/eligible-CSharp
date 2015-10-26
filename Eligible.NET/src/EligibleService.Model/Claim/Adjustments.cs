using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class Adjustments
    {
        [JsonProperty("adjustment_reason_code")]
        public Collection<string> AdjustmentReasonCode { get; set; }

        [JsonProperty("amount")]
        public Collection<string> Amount { get; set; }

        [JsonProperty("quantity")]
        public Collection<string> Quantity { get; set; }

    }
}
