using EligibleService.Core;
using EligibleService.Exceptions;
using EligibleService.Net;
using RestSharp;
using System;
using System.Collections;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using NLog;

namespace EligibleService.Common
{
    public interface IRequestExecute
    {
        void ExecuteDownload(string apiResource, string npi, string pathToDownload, RequestOptions options);
        
        IRestResponse ExecutePdf(string apiResource, string pdfPath, RequestOptions options, Method httpMethod = Method.POST);
        
        IRestResponse Execute(string apiResource, RequestOptions options, Hashtable filters = null);
        
        IRestResponse ExecutePostPut(string apiResource, string json, RequestOptions options, Method httpMethod = Method.POST);
    }

    public class RequestExecute : IRequestExecute
    {
       /// <summary>
       /// Generic method to process all requests
       /// </summary>
       /// <param name="apiResource">/Coverage/all</param>
       /// <param name="options">request options</param>
       /// <param name="filters"></param>
       /// <returns></returns>
        public IRestResponse Execute(string apiResource, RequestOptions options, Hashtable filters)
        {
            ServicePointManager.ServerCertificateValidationCallback = this.CertificateValidation;

            var request = new RestRequest();
            var client = new RestClient(new Uri(EligibleResources.BaseUrl));

            request.AddParameter("api_key", options.ApiKey);
            request.AddParameter("test", options.IsTest);
            if (filters != null)
            {
                foreach (DictionaryEntry filter in filters)
                {
                    request.AddParameter(filter.Key.ToString(), filter.Value);
                }
            }

            this.SetHeaders(request, options);

            SetResource(apiResource, request);

            return client.Execute(request);
        }

        public IRestResponse ExecutePostPut(string apiResource, string json, RequestOptions options, Method httpMethod)
        {
            ServicePointManager.ServerCertificateValidationCallback = this.CertificateValidation;

            json = FormatInputWithRequestOptions.FormatJson(json, options);
            var request = new RestRequest(httpMethod);
            var client = new RestClient(new Uri(EligibleResources.BaseUrl));

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);

            this.SetHeaders(request, options);

            SetResource(apiResource, request);

            return client.Execute(request);
        }

        public IRestResponse ExecutePdf(string apiResource, string pdfPath, RequestOptions options, Method httpMethod)
        {
            ServicePointManager.ServerCertificateValidationCallback = this.CertificateValidation;

            var request = new RestRequest(httpMethod);
            var client = new RestClient(new Uri(EligibleResources.BaseUrl));

            request.AddParameter("api_key", options.ApiKey);
            request.AddParameter("test", options.IsTest);

            if (string.IsNullOrEmpty(pdfPath.Trim()))
                request.AddParameter("file", pdfPath);

            this.SetHeaders(request, options);

            SetResource(apiResource, request);

            return client.Execute(request);
        }

        public void ExecuteDownload(string apiResource, string npiId, string pathToDownload, RequestOptions options)
        {
            ServicePointManager.ServerCertificateValidationCallback = this.CertificateValidation;

            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(Path.Combine(EligibleResources.BaseUrl + EligibleResources.SupportedApiVersion + apiResource + "?api_key=" + options.ApiKey + "&test=" + options.IsTest), pathToDownload + npiId + ".pdf");
                }
                catch (Exception ex)
                {
                    throw new InvalidRequestException(ex.Message);
                }
            }
        }

        public bool CertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            Eligible eligble = Eligible.Instance;

            ArrayList fingerprint = eligble.Fingerprints();

            if (certificate == null || chain == null)
                return false;

            if (errors != SslPolicyErrors.None)
                return false;

            if (!certificate.Subject.Contains(EligibleResources.WhiteListedDomain.Trim()))
                return true;

            return fingerprint.Contains(certificate.GetCertHashString());
        }

        private void SetHeaders(RestRequest request, RequestOptions options)
        {
            request.AddHeader("Accept", "application/json");
            request.AddHeader("User-Agent", string.Format("eligible.net/{0}", EligibleResources.LibraryVersion));
            Hashtable propertyMap = new Hashtable();
            propertyMap.Add("bindings.version", EligibleResources.LibraryVersion);
            propertyMap.Add("lang", "C#");
            propertyMap.Add("publisher", "Eligible");
            request.AddHeader("X-Eligible-Client-User-Agent", JsonConvert.SerializeObject(propertyMap));
            request.AddHeader("Eligible-Version", EligibleResources.SupportedApiVersion);
        }

        private static void SetResource(string apiResource, RestRequest request)
        {
            request.Resource = "/" + EligibleResources.SupportedApiVersion + apiResource;
        }
    }
}
