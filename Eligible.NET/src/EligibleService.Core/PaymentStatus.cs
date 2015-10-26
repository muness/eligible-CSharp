using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Model.PaymentStatus;
using EligibleService.Net;
using RestSharp;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace EligibleService.Core
{
    public class PaymentStatus : BaseCore
    {
        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

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
            var fomatedResponse =  RequestProcess.ValidateAndReturnResponse<PayementStatusResponse, CoverageErrorDetails>(response);
            fomatedResponse.SetJsonResponse(response.Content);
            return fomatedResponse;
        }

    }
}
