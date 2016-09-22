using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EligibleService.Claim.ClaimReports
{
    public class Amount : BaseAmount
    {
        [JsonProperty("patient_responsibility")]
        public double? PatientResponsibility { get; set; }

        [JsonProperty("prompt_payment_discount")]
        public double? PromptPaymentDiscount { get; set; }

        [JsonProperty("per_day_limit")]
        public double? PerDayLimit { get; set; }

        [JsonProperty("patient_paid")]
        public double? PatientPaid { get; set; }

        public string RevisedIntrest { get; set; }

        [JsonProperty("negative_ledger_balance")]
        public double? NegetiveLadgerBalance { get; set; }

        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var payer_keys = _additionalData.Keys;
            string key = "";
            foreach (string payer_key in payer_keys)
            {
                if (payer_key.Contains("revised_interest") || payer_key.Contains("revised_intrest"))
                {
                    key = payer_key;
                }
            }
            if (key != "")
                RevisedIntrest = _additionalData[key].ToString();
            else
                RevisedIntrest = null;
        }

        public Amount()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
    }

    public class Amount2 : BaseAmount
    {
        [JsonProperty("deduction")]
        public double? Deduction { get; set; }
    }

}
