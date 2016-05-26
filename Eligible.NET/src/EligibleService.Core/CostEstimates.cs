using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Net;
using System.Collections;

namespace EligibleService.Core
{
    public class CostEstimates : BaseCore
    {
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
            var formattedResponse = RequestProcess.ResponseValidation<CostEstimatesResponse, EligibleGenericError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            ResetIsEligibleRequest(false);
            return formattedResponse;
        }
    }
}
