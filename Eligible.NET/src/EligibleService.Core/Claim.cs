using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Model.Claim;
using EligibleService.Net;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.IO;

namespace EligibleService.Core
{
    public class Claim : BaseCore
    {
        public Claim() : base() { }

        /// <summary>
        /// Claim submission with ClaimParam object
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public ClaimResponse Create(ClaimParams claimParams, RequestOptions options = null)
        {
            return this.Create(JsonSerialize(claimParams), options);
        }

        /// <summary>
        /// Claim submission with Hashtable params
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public ClaimResponse Create(Hashtable claimParams, RequestOptions options = null)
        {
            return this.Create(JsonSerialize(claimParams), options);
        }

        /// <summary>
        /// Claim submission with Json formatted string of  params
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public ClaimResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(EligibleResources.PathToClaims, jsonParams, SetRequestOptionsObject(options));
            ClaimResponse formattedResponse = RequestProcess.ResponseValidation<ClaimResponse, EligibleGenericError>(response);
            
            if (formattedResponse.Success == false)
                throw new EligibleException("Claim creation failed. Please check EligibleError for more details", formattedResponse);
            else
            {
                formattedResponse.SetJsonResponse(response.Content);
                return formattedResponse;
            }
        }

        /// <summary>
        /// Retrieve Single Claim Acknowledgements
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_acknowledgements_retrieve_single
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns>It returns all acknowledgements of a claim in sorted order by creation time.</returns>
        public ClaimAcknowledgementsResponse GetClaimAcknowledgements(string referenceId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToClaims, referenceId, EligibleResources.ClaimAcknowledgementsPath), SetRequestOptionsObject(options));
            ClaimAcknowledgementsResponse formattedResponse = RequestProcess.ResponseValidation<ClaimAcknowledgementsResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Get Claim multiple Acknowledgements
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_acknowledgements_retrieve_multiple
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        public MultipleAcknowledgementsResponse GetClaimAcknowledgements(Hashtable requiredParams = null, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToClaims, EligibleResources.ClaimAcknowledgementsPath), SetRequestOptionsObject(options), requiredParams);
            var formattedResponse = RequestProcess.ResponseValidation<MultipleAcknowledgementsResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Retrieve Single Claim Payment Report
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_payment_reports_retrieve_single
        /// </summary>
        /// <param name="referenceId">Reference Id to get the Claim report</param>
        /// <returns>It return payment report for the claim</returns>
        public ClaimPaymentReportResponse GetClaimPaymentReport(string referenceId, RequestOptions options = null)
        {
            response = this.GetReport(Path.Combine(EligibleResources.PathToClaims, referenceId, EligibleResources.PaymentReports), options);
            var formattedResponse = RequestProcess.ResponseValidation<ClaimPaymentReportResponse, EligibleGenericError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Retrieve Specific Claim Payment Report
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_payment_reports_retrieve_specific
        /// </summary>
        /// <param name="referenceId">Reference id to to get the claim report</param>
        /// <param name="id">Specific claim id</param>
        /// <returns>ClaimPaymentReport object. Returns the specified payment report for the claim.</returns>
        public ClaimPaymentReportResponse GetClaimPaymentReport(string referenceId, string id, RequestOptions options = null)
        {
            response = this.GetReport(Path.Combine(EligibleResources.PathToClaims, referenceId, EligibleResources.PaymentReports, id), options);
            var formattedResponse = RequestProcess.ResponseValidation<ClaimPaymentReportResponse, EligibleGenericError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Retrieve Multiple Claim Payment Report
        /// https://gds.eligibleapi.com/rest#claim_and_reports_claim_payment_reports_retrieve_multiple
        /// </summary>
        /// <returns>List of reports. ClaimPaymentReports object</returns>
        public ClaimPaymentReportsResponse GetClaimPaymentReport(RequestOptions options = null)
        {
            response = this.GetReport(Path.Combine(EligibleResources.PathToClaims, EligibleResources.PaymentReports), options);
            var formattedResponse = RequestProcess.ResponseValidation<ClaimPaymentReportsResponse, EligibleGenericError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        private IRestResponse GetReport(string path, RequestOptions options)
        {
            var response = this.ExecuteObj.Execute(path, SetRequestOptionsObject(options));
            return response;
        }
    }
}
