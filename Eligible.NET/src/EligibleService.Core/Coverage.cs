using EligibleService.Common;
using System.Collections;
using EligibleService.Net;
using EligibleService.Exceptions;
using EligibleService.Model;

namespace EligibleService.Core
{
    /// <summary>
    /// EligibleService.Core.Coverage class handles all Coverage API calls
    /// </summary>
    public class Coverage : BaseCore
    {
        public Coverage() : base() { }

        /// <summary>
        /// Get all Coverages
        /// https://gds.eligibleapi.com/v1.5/coverage/all
        /// </summary>
        /// <param name="requiredParams">Required params in the form of Hashtable. Check document for Required params</param>
        /// <returns>All coverages</returns>
        public CoverageResponse All(Hashtable requiredParams, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.PathToAllCoverages, SetRequestOptionsObject(options), requiredParams);
            var fomatedResponse = RequestProcess.ResponseValidation<CoverageResponse, CoverageErrorDetails>(response);
            fomatedResponse.SetJsonResponse(response.Content);
            return fomatedResponse;
        }

        /// <summary>
        /// Get all Medicare
        /// https://gds.eligibleapi.com/v1.5/coverage/medicare.json"
        /// </summary>
        /// <param name="requiredParams">Required params in the form of Hashtable. Check document for Required params</param>
        /// <returns>All medicare results</returns>
        public MedicareResponse Medicare(Hashtable requiredParams, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.PathToMedicare, SetRequestOptionsObject(options), requiredParams);
            var formattedResponse = RequestProcess.ResponseValidation<MedicareResponse, CoverageErrorDetails>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }
    }
}
