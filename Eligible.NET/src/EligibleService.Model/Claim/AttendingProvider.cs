using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Claim
{
    public class AttendingProvider : Name
    {
        [JsonProperty("npi")]
        public string Npi { get; set; }

        [JsonProperty("taxonomy_code")]
        public string TaxonomyCode { get; set; }
    }
}
