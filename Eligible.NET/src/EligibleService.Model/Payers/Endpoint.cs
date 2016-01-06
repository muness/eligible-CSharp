using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Payer
{
    /// <summary>
    /// supported_endpoints Model 
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        /// endpoint - Eligible endpoint supported by the Payer. 
        /// Notice that a payer may have different attributes depending on the endpoint.
        /// </summary>
        [JsonProperty("endpoint")]
        public string EndPoint { get; set; }

        /// <summary>
        /// pass_through_fee - An additional fee for this particular payer which you will be charged.
        /// </summary>
       [JsonProperty("pass_through_fee")]
        public Double? PassThroughFee { get; set; }
        /// <summary>
        /// enrollment_required - indicates if the payer requires an enrollment for each provider. 
        /// If this is true, you need to register the provider NPI first, 
        /// using Enrollments endpoint to perform the transaction.
        /// </summary>
        [JsonProperty("enrollment_required")]
        public bool EnrollmentRequired { get; set; }

        /// <summary>
        /// average_enrollment_process_time for Endopoint
        /// </summary>
        [JsonProperty("average_enrollment_processTime")]
        public int? AverageEnrollmentProcessTime { get; set; }

        /// <summary>
        /// enrollment_mandatory_fields - List of mandatory fields required to enroll with particular payer. 
        /// Each payer can have different set of mandatory fields. 
        /// Example: HPMIN payer requires tax_id and npi to process enrollment.
        /// </summary>
        [JsonProperty("enrollment_mandatory_fields")]
        public Collection<string> EnrollmentMandatoryFields { get; set; }

        /// <summary>
        /// signature_required - There are few payers which require the provider's signature to process the enrollment. 
        /// signature_required is used to know whether the enrollment needs a signature or not. 
        /// If the value of this field is true then the payer requires the provider's signature to process the enrollment. Check Capture Signature section to learn more about easy ways to capture signatures from providers
        /// </summary>
        [JsonProperty("signature_required")]
        public bool? SignatureRequired { get; set; }

        [JsonProperty("blue_ink_required")]
        public bool? BlueInkRequired { get; set; }

        /// <summary>
        /// message - Additional steps, which your users to follow while completing the enrollment. Example: "Enroll on Michigan Medicaid website with Eligible submitter ID c0now" 
        /// In this case your users must use c0now as submitter id in the Michigan Medicaid website.
        /// </summary>

        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// status - It is used to check whether payer is working or not. 
        /// There are chances that payer will be down for maintenance or facing some problems so you can use this know the status of a payer.
        /// </summary>

        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// status_details - Additional details regarding payer status.
        /// </summary>

        [JsonProperty("status_details")]
        public string StatusDetails { get; set; }

        /// <summary>
        /// status_updated_at - Last updated time of payer status.
        /// </summary>
        [JsonProperty("status_updated_at")]
        public DateTime? StatusUpdatedAt { get; set; }

        [JsonProperty("original_signature_pdf")]
        public bool? OriginalSignaturePdf { get; set; }

    }
}
