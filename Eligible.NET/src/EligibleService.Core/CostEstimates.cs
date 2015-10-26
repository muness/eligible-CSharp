using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Model.CostEstimates;
using EligibleService.Net;
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace EligibleService.Core
{

    public class CostEstimates : BaseCore
    {

        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        public CostEstimates() : base() { }
        /// <summary>
        /// Cost Estimates
        /// https://gds.eligibleapi.com/rest#cost-estimates
        /// </summary>
        /// <param name="requiredParams">Check document for required params</param>
        /// <returns>Cost estimation</returns>

        public CostEstimatesResponse Get(Hashtable requiredParams,  RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.CostEstimates, SetRequestOptionsObject(options), requiredParams);
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<CostEstimatesResponse, CoverageErrorDetails>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }
    }
}
