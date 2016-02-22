using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Model.Claim
{
    public class ServiceLine
    {
        [JsonProperty("revenue_code")]
        public string RevenueCode { get; set; }

        [JsonProperty("revenue_description")]
        public string RevenueDescription { get; set; }

        [JsonProperty("line_number")]
        public string LineNumber { get; set; }

        [JsonProperty("prescription_date")]
        public string PrescriptionDate { get; set; }

        [JsonProperty("last_seen_date")]
        public string LastSeenDate { get; set; }

        [JsonProperty("shipped_date")]
        public string ShippedDate { get; set; }

        [JsonProperty("test_date")]
        public string TestDate { get; set; }

        [JsonProperty("clia_number")]
        public string CliaNumber { get; set; }

        [JsonProperty("emergency")]
        public bool? Emergency { get; set; }

        [JsonProperty("sales_tax_amount")]
        public string SalesTaxAmount { get; set; }

        [JsonProperty("postage_amount")]
        public string PostageAmount { get; set; }

        [JsonProperty("service_date")]
        public string ServiceDate { get; set; }
        /// <summary>
        /// Required for creating a claim.
        /// date the service/procedure/product started. Required for professional claims and optional for other type of claims. ex: "service_date_from": "2014-05-07"
        /// </summary>
        [JsonProperty("service_date_from")]
        public string ServiceDateFrom { get; set; }

        /// <summary>
        /// Required for creating a claim.
        /// date the service/procedure/product ended. Required for professional claims and optional for other type of claims. ex: "service_date_to": "2014-05-07"
        /// </summary>
        [JsonProperty("service_date_to")]
        public string ServiceDateTo { get; set; }

        /// <summary>
        /// Required for creating a claim.
        /// place of service code for where the product or service was given in. ex: "place_of_service": "11"
        /// </summary>
        [JsonProperty("place_of_service")]
        public string PlaceOfService { get; set; }

        /// <summary>
        /// Required for creating a claim. 
        /// cpt code, hcpcs code, etc. (the service/procedure/product that was performed that payment is being requested for.). ex: "procedure_code": "90837"
        /// </summary>
        [JsonProperty("procedure_code")]
        public string ProcedureCode { get; set; }

        /// <summary>
        /// Required for creating a claim.
        /// list of modifiers applicable for the service. ex: "procedure_modifiers": ["25"]
        /// </summary>
        [JsonProperty("procedure_modifiers")]
        public Collection<string> ProcedureModifiers { get; set; }
        
        /// <summary>
        /// Required for creating a claim.
        /// Index of diagnosis code in diagnosis_codes(claim) which are applicable for this service. It starts from 1 to length of diagnosis_codes. ex: "diagnosis_code_pointers": ["1"]
        /// </summary>
        [JsonProperty("diagnosis_code_pointers")]
        public Collection<string> DiagnosisCodePointers { get; set; }

        /// <summary>
        /// Required for creating a claim. 
        /// the monetary amount being charged for this service/procedure/product. ex: "charge_amount": 98.8
        /// </summary>
        [JsonProperty("charge_amount")]
        public string ChargeAmount { get; set; }

        /// <summary>
        /// Required for creating a claim.
        /// Units for the service. ex: "units": "1"
        /// </summary>
        [JsonProperty("units")]
        public string Units { get; set; }

        /// <summary>
        /// Required for creating a claim.
        /// </summary>
        [JsonProperty("rendering_provider")]
        public RenderingProvider RenderingProvider { get; set; }

        /// <summary>
        /// Required for creating a claim.
        /// "HC" (CPT/HCPCS) other values are "ER", "IV", "HP". Required for professional claims and optional for other type of claims. ex: "procedure_qualifier": "HC"
        /// </summary>
        [JsonProperty("procedure_qualifier")]
        public string ProcedureQualifier { get; set; }

        [JsonProperty("procedure_count")]
        public string ProcedureCount { get; set; }

        [JsonProperty("tooth_code")]
        public string ToothCode { get; set; }

        [JsonProperty("tooth_surface_codes")]
        public Collection<string> ToothSurfaceCodes { get; set; }

        [JsonProperty("outside_lab_charges")]
        public Collection<string> OutsideLabCharges { get; set; }

        [JsonProperty("prior_authorization_number")]
        public Collection<string> PriorAuthorizationNumber { get; set; }

        [JsonProperty("authorization_exception_code")]
        public Collection<string> AuthorizationExceptionCode { get; set; }

        [JsonProperty("mammography_certification_number")]
        public Collection<string> MammographyCertificationNumber { get; set; }

        [JsonProperty("referral_number")]
        public Collection<string> EeferralNumber { get; set; }

        [JsonProperty("description")]
        public Collection<string> Description { get; set; }

        [JsonProperty("durable_medical_equipment")]
        public DurableMedicalEquipment DurableMedicalEquipment { get; set; }

        [JsonProperty("referring_provider")]
        public Provider ReferringProvider { get; set; }

        [JsonProperty("supervising_provider")]
        public Provider SupervisingProvider { get; set; }

        [JsonProperty("assistent_surgeon")]
        public Provider AssistentSurgeon { get; set; }

        [JsonProperty("service_facility")]
        public ServiceFacility ServiceFacility { get; set; }

        [JsonProperty("purchased_service_provider")]
        public PurchasedServiceProvider PurchasedServiceProvider { get; set; }

        [JsonProperty("supplemental_information")]
        public SupplementalInformation SupplementalInformation { get; set; }

        [JsonProperty("ordering_provider")]
        public Provider OrderingProvider { get; set; }

        [JsonProperty("ambulance")]
        public Ambulance Ambulance { get; set; }

        [JsonProperty("cob")]
        public Cob Cob { get; set; }

        [JsonProperty("service_units")]
        public string ServiceUnits { get; set; }

        [JsonProperty("non_covered_amount")]
        public string NonCoveredAmount { get; set; }

        [JsonProperty("service_tax_amount")]
        public string ServiceTaxAmount { get; set; }

        [JsonProperty("facility_tax_amount")]
        public string FacilityTaxAmount { get; set; }

        [JsonProperty("prosthesis_crown_inlay_code")]
        public string ProsthesisCrownInlayCode { get; set; }

        [JsonProperty("estimated_prior_replacement_date")]
        public string EstimatedPriorReplacementDate { get; set; }

        [JsonProperty("exact_prior_replacement_date")]
        public string ExactPriorReplacementDate { get; set; }

        [JsonProperty("appliance_placement_date")]
        public string AppliancePlacementDate { get; set; }

        [JsonProperty("replacement_date")]
        public string ReplacementDate { get; set; }

        [JsonProperty("treatment_start_date")]
        public string TreatmentStartDate { get; set; }

        [JsonProperty("treatment_completion_date")]
        public string TreatmentCompletionDate { get; set; }

        [JsonProperty("predetermination_identifier")]
        public string PredeterminationIdentifier { get; set; }

        
    }
}
