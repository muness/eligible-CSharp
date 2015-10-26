using Newtonsoft.Json;

namespace EligibleService.Model.EnrollmentNpis
{
    public class AuthorizedSigner
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("contact_number")]
        public string ContactNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("signature")]
        public Signature Signature { get; set; }
    }

}
