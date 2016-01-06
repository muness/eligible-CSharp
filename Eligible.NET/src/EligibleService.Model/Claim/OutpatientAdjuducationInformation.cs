using Newtonsoft.Json;
using System.Collections.ObjectModel;

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
