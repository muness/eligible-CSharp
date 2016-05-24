using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace EligibleService.Model.Coverage
{
    public class PreexistingCondition
    {
        [JsonProperty("waiting_period")]
        public Collection<WaitingPeriod> WaitingPeriod { get; set; }
    }

    public class Period
    {
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("comments")]
        public Collection<string> Comments { get; set; }
    }

    public class WaitingPeriod
    {
        public Period period { get; set; }
        [JsonExtensionData]
        private IDictionary<string, JToken> _additionalData;
        List<string> dateLabels = new List<string>(
            new string[] {  "", "discharge", "issue", "effective_fate_of_change", "period_start", "period_end", "completion",
                            "coordination_of_benefits","plan", "benefit", "primary_care_provider", "latest_visit_or_consultation",
                            "eligibilty", "added", "consolidated_omnibus_budget_reconciliation_begin", "consolidated_omnibus_budget_reconciliation_end",
                            "premium_paid_to_date_begin", "premium_paid_to_date_end", "plan_begin", "plan_end,benefit_begin",
                            "benefit_end", "eligibility_begin", "eligibility_end", "enrollment", "admission", "date_of_death",
                            "certification", "service","policy_effective", "policy_expiration", "date_of_last_update", "status" });

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            var payer_key = _additionalData.Keys;
            string key = "";
            foreach (string dateLabel in dateLabels)
            {
                if (payer_key.Contains(dateLabel))
                    key = dateLabel;
            }
            period = JsonConvert.DeserializeObject<Period>(_additionalData[key].ToString());
        }

        public WaitingPeriod()
        {
            _additionalData = new Dictionary<string, JToken>();
        }
    }
}
