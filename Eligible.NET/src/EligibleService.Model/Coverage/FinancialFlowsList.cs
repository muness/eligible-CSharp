using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Coverage
{
    public class FinancialFlowsList
    {
        [JsonProperty("amounts")]
        public Collection<FinancialFlow> Amounts { get; set; }
    }
    
}
