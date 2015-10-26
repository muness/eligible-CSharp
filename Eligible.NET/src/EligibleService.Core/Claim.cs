using EligibleService.Claim.ClaimReports;
using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Model.Claim;
using EligibleService.Net;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace EligibleService.Core
{
    public class Claim : BaseCore
    {
        public  ClaimParams JsonObj { get; set; }
        public  IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        public Claim() : base() { }
        /// <summary>
        /// Claim submition with ClaimParam object
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public ClaimResponse Create(ClaimParams claimParams, RequestOptions options = null)
        {
            return Create(JsonConvert.SerializeObject(claimParams), options);
        }

        /// <summary>
        /// Claim submition with Hashtable params
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public ClaimResponse Create(Hashtable claimParams, RequestOptions options = null)
        {
            return Create(JsonConvert.SerializeObject(claimParams, Formatting.Indented), options);
        }

        /// <summary>
        /// Claim submition with Json formeted string of  params
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public  ClaimResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(EligibleResources.PathToClaims, jsonParams, SetRequestOptionsObject(options));
            ClaimResponse formatedResponse = RequestProcess.ValidateAndReturnResponse<ClaimResponse, ClaimErrors>(response);
            if (formatedResponse.Success == false)
                throw new EligibleException(formatedResponse);
            else
            {
                formatedResponse.SetJsonResponse(response.Content);
                return formatedResponse;
            }
        }

        /// <summary>
        /// Retrieve Single Claim Acknowledgements
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_acknowledgements_retrieve_single
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns>It returns all acknowledgements of a claim in sorted order by creation time.</returns>
        public  ClaimAcknowledgementsResponse GetClaimAcknowledgements(string referenceId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToClaims,referenceId, EligibleResources.ClaimAcknowledgementsPath), SetRequestOptionsObject(options));
            ClaimAcknowledgementsResponse formatedResponse = RequestProcess.ValidateAndReturnResponse<ClaimAcknowledgementsResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Get Claim multiple Acknowledgements
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_acknowledgements_retrieve_multiple
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        public  MultipleAcknowledgementsResponse GetClaimAcknowledgements(Hashtable requiredParams = null, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToClaims, EligibleResources.ClaimAcknowledgementsPath), SetRequestOptionsObject(options), requiredParams);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<MultipleAcknowledgementsResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Retrieve Single Claim Payment Report
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_payment_reports_retrieve_single
        /// </summary>
        /// <param name="referenceId">Reference Id to get the Claim report</param>
        /// <returns>It return payment report for the claim</returns>
        public  ClaimPaymentReportResponse GetClaimPaymentReport(string referenceId, RequestOptions options = null)
        {
            response = GetReport(Path.Combine(EligibleResources.PathToClaims, referenceId, EligibleResources.PaymentReports), options);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<ClaimPaymentReportResponse, ClaimErrors>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Retrieve Specific Claim Payment Report
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_payment_reports_retrieve_specific
        /// </summary>
        /// <param name="referenceId">Reference id to to get the claim report</param>
        /// <param name="id">Specific claim id</param>
        /// <returns>ClaimPaymentReport object. Returns the specified payment report for the claim.</returns>
        public  ClaimPaymentReportResponse GetClaimPaymentReport(string referenceId, string id, RequestOptions options = null)
        {
            response = GetReport(Path.Combine(EligibleResources.PathToClaims, referenceId, EligibleResources.PaymentReports, id), options);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<ClaimPaymentReportResponse, ClaimErrors>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Retrieve Multiple Claim Payment Report
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_payment_reports_retrieve_multiple
        /// </summary>
        /// <returns>List of reports. ClaimPaymentReports object</returns>
        public  ClaimPaymentReportsResponse GetClaimPaymentReport(RequestOptions options = null)
        {
            response = GetReport(Path.Combine(EligibleResources.PathToClaims, EligibleResources.PaymentReports), options);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<ClaimPaymentReportsResponse, ClaimErrors>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        private  IRestResponse GetReport(string path, RequestOptions options)
        {
            var response = ExecuteObj.Execute(path, SetRequestOptionsObject(options));
            return response;
        }
    }
}
