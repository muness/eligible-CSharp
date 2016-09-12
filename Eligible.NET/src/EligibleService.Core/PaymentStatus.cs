using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Net;
using RestSharp;
using System.Collections;

namespace EligibleService.Core
{
    public class PaymentStatus : BaseCore
    {
        public PaymentStatus() : base() { }

        /// <summary>
        /// Get Payment Status for claims
        /// https://gds.eligibleapi.com/rest#retrieve-payment-status
        /// </summary>
        /// <param name="requiredParams"></param>
        /// <returns></returns>
        public PayementStatusResponse Get(Hashtable requiredParams, RequestOptions options = null)
        {
            IRestResponse response = ExecuteObj.Execute(EligibleResources.PaymentStatus, SetRequestOptionsObject(options), requiredParams);
            var fomatedResponse = RequestProcess.ResponseValidation<PayementStatusResponse, PaymentStatusError>(response);
            fomatedResponse.SetJsonResponse(response.Content);
            return fomatedResponse;
        }
    }
}
