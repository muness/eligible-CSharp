using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Model.Customer
{
    public class CustomerParams
    {
        [JsonProperty("customer")]
        public CustomerTag Customer { get; set; }
    }

    public class CustomerTag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }
    }
}
