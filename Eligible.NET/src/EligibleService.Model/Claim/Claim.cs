using Newtonsoft.Json;
using RestSharp.Serializers;

namespace EligibleService.Model.Claim
{
    /// <summary>
    /// Claim Parameters Class to create a Claim
    /// </summary>
    public class ClaimParams
    {
        /// <summary>
        /// Optional parameter
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Optional parameter
        /// </summary>
        [JsonProperty("scrub_eligibility")]
        public bool ScrubEligibility { get; set; }

        /// <summary>
        /// Required to create Claim
        /// </summary>
        [JsonProperty("api_key")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Optional parameter
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }
        
        /// <summary>
        /// Identifies an organizational entity or an individual requesting payment for services.
        /// </summary>
        [JsonProperty("billing_provider")]
        public BillingProvider BillingProvider { get; set; }

        /// <summary>
        /// Payer details you want to send claim to.
        /// </summary>
        [JsonProperty("payer")]
        public ClaimPayer Payer { get; set; }

        /// <summary>
        /// The primary person for which the health insurance plan is established, 
        /// which could be same as patient or not. If a dependent has a unique "identifier" (id) assigned by the insurance company, 
        /// then the patient is considered to be the subscriber and should be sent as the subscriber.
        /// </summary>
        [JsonProperty("subscriber")]
        public Subscriber Subscriber { get; set; }

        /// <summary>
        /// Add dependent block if and only if patient is dependent,
        /// else either leave it empty or don't include it in the request at all. 
        /// If a dependent has a unique "identifier" (id) assigned by the insurance company, 
        /// then the patient is considered to be the subscriber and should be sent as the subscriber.
        /// </summary>
        [JsonProperty("dependent")]
        public Dependent Dependent { get; set; }

        /// <summary>
        /// Claim object.
        /// </summary>
        [JsonProperty("claim")]
        public Claim Claim { get; set; }

        /// <summary>
        /// Required when the address for payment is different than that of the Billing Provider.
        /// </summary>
        [JsonProperty("pay_to_address")]
        public Address PayToAddress { get; set; }

        [JsonProperty("other_payers")]
        public OtherPayers OtherPayers { get; set; }

        [JsonProperty("pay_to_plan")]
        public PayToPlan PayToPlan { get; set; }

        [JsonProperty("referring_provider")]
        public Provider ReferringProvider { get; set; }

        [JsonProperty("rendering_provider")]
        public RenderingProvider RenderingProvider { get; set; }

        [JsonProperty("supervising_provider")]
        public Provider SupervisingProvider { get; set; }

        [JsonProperty("service_facility")]
        public ServiceFacility ServiceFacility { get; set; }

        [JsonProperty("contract_information")]
        public ContractInformation ContractInformation { get; set; }

        [JsonProperty("medicare_cross_over_info")]
        public MedicareCrossoverInfo MedicareCrossoverInfo { get; set; }

        [JsonProperty("receiver")]
        public Receiver Receiver { get; set; }

        [JsonProperty("attending_provider")]
        public AttendingProvider AttendingProvider { get; set; }

        [JsonProperty("operating_physician")]
        public AttendingProvider OperatingPhysician { get; set; }

        [JsonProperty("other_operating_physician")]
        public AttendingProvider OtherOperatingPhysician { get; set; } 
    }
}
