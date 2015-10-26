using EligibleService.Model.Claim;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace EligibleService.Model
{
    public class CustomerResponse : JsonResponseClass
    {
        [JsonProperty("customer")]
        public CustomerModel Customer { get; set; }
    }

    public class CustomerModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("site_name")]
        public string SiteName { get; set; }
    }

    public class CustomersResponse : JsonResponseClass
    {
        [JsonProperty("customers")]
        public Collection<CustomerResponse> Customers { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("num_of_pages")]
        public int? NumOfPages { get; set; }

        [JsonProperty("total")]
        public int? Total { get; set; }
    }
}
