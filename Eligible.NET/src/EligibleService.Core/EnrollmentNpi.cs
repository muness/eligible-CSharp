﻿using EligibleService.Common;
using EligibleService.Core.EnrollmentNpis;
using EligibleService.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.IO;
using EligibleService.Net;

namespace EligibleService.Core
{
    public class Enrollment : BaseCore
    {
        public Enrollment() : base() { }

        /// <summary>
        /// Create Enrollment. It's a POST request and the parameters should be in JSON format in the body.
        /// https://gds.eligibleapi.com/rest#create-enrollment
        /// </summary>
        /// <param name="jsonParams">string contains required params in json format</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(EligibleResources.EnrollmentNpis, jsonParams, SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.ResponseValidation<EnrollmentNpisResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Create Enrollment. It's a POST request and the parameters should be in JSON format in the body.
        /// https://gds.eligibleapi.com/rest#create-enrollment
        /// </summary>
        /// <param name="enrollmentHashParams">Hashtable contains required params</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Create(Hashtable enrollmentHashParams, RequestOptions options = null)
        {
            return this.Create(JsonSerialize(enrollmentHashParams), options);
        }

        /// <summary>
        /// Create Enrollment. It's a POST request and the parameters should be in JSON format in the body.
        /// https://gds.eligibleapi.com/rest#create-enrollment
        /// </summary>
        /// <param name="enrollmentParams">object contains required params in EnrollmentParams class format</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Create(EnrollmentParams enrollmentParams, RequestOptions options = null)
        {
            return this.Create(JsonSerialize(enrollmentParams), options);
        }

        /// <summary>
        /// It's a PUT request to update a Enrollment
        /// https://gds.eligibleapi.com/rest#update-enrollment
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="jsonParams">Required parameters in the form of json</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Update(string enrollmentNpiId, string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId), jsonParams, SetRequestOptionsObject(options), Method.PUT);
            var formattedResponse = RequestProcess.ResponseValidation<EnrollmentNpisResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// It's a PUT request to update a Enrollment
        /// https://gds.eligibleapi.com/rest#update-enrollment
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="jsonParams">Required parameters in the form of Hashtable</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Update(string enrollmentNpiId, Hashtable enrollmentParams, RequestOptions options = null)
        {
            return Update(enrollmentNpiId, JsonSerialize(enrollmentParams), options);
        }

        /// <summary>
        /// It's a PUT request to update a Enrollment
        /// https://gds.eligibleapi.com/rest#update-enrollment
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="jsonParams">Required parameters in the form of EnrollmentParams object</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Update(string enrollmentNpiId, EnrollmentParams enrollmentParams, RequestOptions options = null)
        {
            return Update(enrollmentNpiId, JsonConvert.SerializeObject(enrollmentParams, Formatting.Indented), options);
        }

        /// <summary>
        /// Get enrollment with enrollment_npi_id
        /// GET https://gds.eligibleapi.com/rest#retrieve-enrollment
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <returns></returns>
        public EnrollmentNpisResponse GetByEnrollmentNpiId(string enrollmentNpiId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId), SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.ResponseValidation<EnrollmentNpisResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Its used to list enrollments. By default enrollments are sorted by updated_at descending order.
        /// https://gds.eligibleapi.com/rest#list-enrollment
        /// </summary>
        /// <returns></returns>
        public EnrollmentNpisResponses GetAll(RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.EnrollmentNpis, SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.ResponseValidation<EnrollmentNpisResponses, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Get the link to download the Received pdf
        /// https://gds.eligibleapi.com/rest#received-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <returns></returns>
        public ReceivedPdfResponse GetReceivedPdf(string enrollmentNpiId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.ReceivedPdf), SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.ResponseValidation<ReceivedPdfResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Download the Received pdf to your local machine
        /// https://gds.eligibleapi.com/rest#download-received-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="pathToDownload"></param>
        public string DownloadReceivedPdf(string enrollmentNpiId, string pathToDownload, RequestOptions options = null)
        {
            ExecuteObj.ExecuteDownload(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.ReceivedPdf, EligibleResources.Download), EligibleResources.ReceivedPdf + "_" + enrollmentNpiId, pathToDownload, SetRequestOptionsObject(options));
            return "Request completed";
        }

        /// <summary>
        /// Create Original Signature Pdf
        /// POST https://gds.eligibleapi.com/rest#create-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="signaturePdfFilePath"></param>
        /// <returns></returns>
        public OriginalSignaturePdfResponse CreateOriginalSignaturePdf(string enrollmentNpiId, string signaturePdfFilePath = "", RequestOptions options = null)
        {
            return PdfProcess(enrollmentNpiId, Method.POST, signaturePdfFilePath, options);
        }

        /// <summary>
        /// Update Original Signature Pdf
        /// https://gds.eligibleapi.com/rest#update-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="signaturePdfFilePath"></param>
        /// <returns></returns>
        public OriginalSignaturePdfResponse UpdateOriginalSignaturePdf(string enrollmentNpiId, string signaturePdfFilePath, RequestOptions options = null)
        {
            return PdfProcess(enrollmentNpiId, Method.PUT, signaturePdfFilePath, options);
        }

        /// <summary>
        /// Get Original Signature Pdf with enrollment_npi_id
        /// https://gds.eligibleapi.com/rest#view-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <returns></returns>
        public OriginalSignaturePdfResponse GetOriginalSignaturePdf(string enrollmentNpiId, RequestOptions options = null)
        {
            return PdfProcess(enrollmentNpiId, Method.GET, string.Empty, options);
        }

        /// <summary>
        /// Delete Original Signature Pdf 
        /// https://gds.eligibleapi.com/rest#delete-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <returns></returns>
        public OriginalSignaturePdfDeleteResponse DeleteOriginalSignaturePdf(string enrollmentNpiId, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePdf(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.OriginalSignaturePdf), string.Empty, SetRequestOptionsObject(options), Method.DELETE);
            var formattedResponse = RequestProcess.ResponseValidation<OriginalSignaturePdfDeleteResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Download Original signature pdf
        /// https://gds.eligibleapi.com/rest#download-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="pathToDownload"></param>
        public bool DownloadOriginalSignaturePdf(string enrollmentNpiId, string pathToDownload, RequestOptions options = null)
        {
            ExecuteObj.ExecuteDownload(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.OriginalSignaturePdf, EligibleResources.Download), EligibleResources.OriginalSignaturePdf + "_" + enrollmentNpiId, pathToDownload, SetRequestOptionsObject(options));
            return true;
        }

        private OriginalSignaturePdfResponse PdfProcess(string enrollmentNpiId, Method httpMethod, string signaturePdfFilePath, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePdf(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.OriginalSignaturePdf), signaturePdfFilePath, SetRequestOptionsObject(options), httpMethod);
            var formattedResponse = RequestProcess.ResponseValidation<OriginalSignaturePdfResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }
    }
}
