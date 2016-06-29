using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Coverage
{
    public class PlanDates : Dates
    {
        [JsonProperty("date_source")]
        public string DateSource { get; set; }
    }
}
