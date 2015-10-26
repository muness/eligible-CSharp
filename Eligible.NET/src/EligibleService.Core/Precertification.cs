using EligibleService.Claim.Precert;
using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Model.Claim;
using EligibleService.Model.Precertification;
using EligibleService.Net;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;

namespace EligibleService.Core
{
    public class Precertification : BaseCore
    {
        public PrecertParams JsonObj { get; set; }


        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        /// <summary>
        /// Precertification Inquiry
        ///https://gds.eligibleapi.com/rest#precert
        /// </summary>
        /// <param name="requiredParams"></param>
        /// <returns></returns>
        public PrecertificationInquiryResponse Inquiry(Hashtable requiredParams, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.Precert, EligibleResources.Inquiry),SetRequestOptionsObject(options), requiredParams);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<PrecertificationInquiryResponse, CoverageErrorDetails>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        //public static dynamic Create(Hashtable claimParams)
        //{
        //    return Create(JsonConvert.SerializeObject(claimParams, Formatting.Indented));
        //}

        //public static dynamic Create(string jsonParams)
        //{
        //    string json = AddCommonParams(jsonParams);
        //    response = ExecuteObj.Execute(EligibleResources.PathToClaims, json);
        //    JsonResponse = response.Content;
        //    return RequestProcess.ValidateAndReturnResponse<dynamic, ClaimErrors>(response);
        //}

        //private static string AddCommonParams(string jsonParams)
        //{
        //    JsonObj = JsonConvert.DeserializeObject<PrecertParams>(jsonParams);
        //    Access = EligibleAccess.GetAccess();
        //    JsonObj.ApiKey = Access.ApiKey;
        //    JsonObj.Test = Access.TestEnabled;
        //    return JsonConvert.SerializeObject(JsonObj);
        //}
    }
}
