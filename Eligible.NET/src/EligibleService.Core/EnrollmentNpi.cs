using EligibleService.Common;
using EligibleService.Core.EnrollmentNpis;
using EligibleService.Model;
using EligibleService.Model.EnrollmentNpis;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using EligibleService.Net;

namespace EligibleService.Core
{
    public class Enrollment : BaseCore
    {
        public EnrollmentParams JsonObj { get; set; }
        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        public Enrollment() : base(){}

        /// <summary>
        /// Create Enrollment. It's a POST request and the parameters should be in JSON format in the body.
        /// https://gds.eligibleapi.com/rest#create-enrollment
        /// </summary>
        /// <param name="jsonParams">string contains required params in json format</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(EligibleResources.EnrollmentNpis, jsonParams, SetRequestOptionsObject(options));
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<EnrollmentNpisResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Create Enrollment. It's a POST request and the parameters should be in JSON format in the body.
        /// https://gds.eligibleapi.com/rest#create-enrollment
        /// </summary>
        /// <param name="enrollmentHashParams">Hashtable contains required params</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Create(Hashtable enrollmentHashParams, RequestOptions options = null)
        {
            return Create(JsonConvert.SerializeObject(enrollmentHashParams), options);
        }

        /// <summary>
        /// Create Enrollment. It's a POST request and the parameters should be in JSON format in the body.
        /// https://gds.eligibleapi.com/rest#create-enrollment
        /// </summary>
        /// <param name="enrollmentParams">object contains required paramss in EnrollmentParams class format</param>
        /// <returns></returns>
        public EnrollmentNpisResponse Create(EnrollmentParams enrollmentParams, RequestOptions options = null)
        {
            return Create(JsonConvert.SerializeObject(enrollmentParams), options);
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
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<EnrollmentNpisResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
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
            return Update(enrollmentNpiId, JsonConvert.SerializeObject(enrollmentParams, Formatting.Indented), options);
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
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<EnrollmentNpisResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Its used to list enrollments. By default enrollments are sorted by updated_at descending order.
        /// https://gds.eligibleapi.com/rest#list-enrollment
        /// </summary>
        /// <returns></returns>
        public EnrollmentNpisResponses GetAll( RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.EnrollmentNpis, SetRequestOptionsObject(options));
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<EnrollmentNpisResponses, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
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
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<ReceivedPdfResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Download the Received pdf to your local machine
        /// https://gds.eligibleapi.com/rest#download-received-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="pathToDownload"></param>
        public string DownloadReceivedPdf(string enrollmentNpiId, string pathToDownload, RequestOptions options)
        {
            ExecuteObj.ExecuteDownload(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.ReceivedPdf, EligibleResources.Download), EligibleResources.ReceivedPdf + "_" + enrollmentNpiId, pathToDownload, SetRequestOptionsObject(options));
            return "Request completed";
        }

        private OriginalSignaturePdfResponse PdfProcess(string enrollmentNpiId, Method httpMethod, string signaturePdfFilePath, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePdf(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.OriginalSignaturePdf), signaturePdfFilePath, SetRequestOptionsObject(options), httpMethod);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<OriginalSignaturePdfResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
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
            return PdfProcess(enrollmentNpiId, Method.GET, "", options);
        }

        /// <summary>
        /// Delete Original Signature Pdf 
        /// https://gds.eligibleapi.com/rest#delete-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <returns></returns>
        public OriginalSignaturePdfDeleteResponse DeleteOriginalSignaturePdf(string enrollmentNpiId, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePdf(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.OriginalSignaturePdf), "", SetRequestOptionsObject(options), Method.DELETE);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<OriginalSignaturePdfDeleteResponse, EligibleError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Download Original signature pdf
        /// https://gds.eligibleapi.com/rest#download-original-signature-pdf
        /// </summary>
        /// <param name="enrollmentNpiId"></param>
        /// <param name="pathToDownload"></param>
        public string DownloadOriginalSignaturePdf(string enrollmentNpiId, string pathToDownload, RequestOptions options = null)
        {
            ExecuteObj.ExecuteDownload(Path.Combine(EligibleResources.EnrollmentNpis, enrollmentNpiId, EligibleResources.OriginalSignaturePdf, EligibleResources.Download), EligibleResources.OriginalSignaturePdf + "_" + enrollmentNpiId, pathToDownload, SetRequestOptionsObject(options));
            return "Request completed";
        }
    }
}
