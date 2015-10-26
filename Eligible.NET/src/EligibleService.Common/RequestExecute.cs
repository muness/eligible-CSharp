using EligibleService.Core;
using EligibleService.Exceptions;
using EligibleService.Net;
using RestSharp;
using System;
using System.Collections;
using System.IO;
using System.Net;

namespace EligibleService.Common
{
    public class RequestExecute : IRequestExecute
    {  
        /// <summary>
        /// Generic method to process all requests
        /// </summary>
        /// <typeparam name="T">JsonDecript Model</typeparam>
        /// <param name="apiResource">Path to fetch data</param>
        /// <param name="filters">Parameters to filter the result</param>
        /// <returns>Desrialized JSON output</returns>
      
        IRestResponse IRequestExecute.Execute(string apiResource,RequestOptions options, Hashtable filters)
        {
            Eligible access = Eligible.Instance;
            var request = new RestRequest();
            var client = new RestClient(new Uri(EligibleResources.BaseUrl));

            request.AddParameter("api_key", options.ApiKey);
            request.AddParameter("test", options.TestMode);
            if (filters != null)
            {
                foreach (DictionaryEntry filter in filters)
                {
                    request.AddParameter(filter.Key.ToString(), filter.Value);
                }
            }

            request.Resource = "/" + options.ApiVersion + apiResource;

            var response = client.Execute(request);

            //ThrowExceptions(response);

            return response;
        }

        public IRestResponse ExecutePostPut(string apiResource, string json, RequestOptions options, Method httpMethod)
        {
            json = FormatInputWithRequestOptions.FormatJson(json, options);
            var request = new RestRequest(httpMethod);
            var client = new RestClient(new Uri(EligibleResources.BaseUrl));

            request.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
            request.Resource = "/" + options.ApiVersion + apiResource;

            var response = client.Execute(request);

            //ThrowExceptions(response);

            return response;
        }

        public IRestResponse ExecutePdf(string apiResource, string pdfPath, RequestOptions options, Method httpMethod)
        {
            var request = new RestRequest(httpMethod);
            var client = new RestClient(new Uri(EligibleResources.BaseUrl));

            request.AddParameter("api_key", options.ApiKey);
            request.AddParameter("test", options.TestMode);

            if (string.IsNullOrEmpty(pdfPath.Trim()))
                request.AddParameter("file", pdfPath);

            request.Resource = "/" + options.ApiVersion + apiResource;

            return client.Execute(request);
        }

        public void ExecuteDownload(string apiResource, string npiId, string pathToDownload, RequestOptions options)
        {
            Eligible access = Eligible.Instance;

            using (var client = new WebClient())
            {
                client.DownloadFile(Path.Combine(EligibleResources.BaseUrl + access.ApiVersion + apiResource + "?api_key=" + access.ApiKey + "&test=" + access.TestMode), pathToDownload + npiId + ".pdf");
            }
        }

    }

    public interface IRequestExecute
    {
        void ExecuteDownload(string apiResource, string npiId, string pathToDownload, RequestOptions options);
        IRestResponse ExecutePdf(string apiResource, string pdfPath, RequestOptions options, Method httpMethod = Method.POST);
        IRestResponse Execute(string apiResource, RequestOptions options, Hashtable filters = null);
        IRestResponse ExecutePostPut(string apiResource, string json, RequestOptions options, Method httpMethod = Method.POST);
    }
}
