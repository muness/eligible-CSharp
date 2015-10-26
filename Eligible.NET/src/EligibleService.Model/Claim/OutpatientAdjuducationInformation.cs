using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class OutpatientAdjuducationInformation
    {
        [JsonProperty("reimbursement_rate")]
        public string ReimbursementRate { get; set; }

        [JsonProperty("payable_amount")]
        public string PayableAmount { get; set; }

        [JsonProperty("payable_remark_codes")]
        public Collection<string> PayableRemarkCodes { get; set; }
    }
}
