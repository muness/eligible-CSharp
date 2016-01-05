using EligibleService.Claim.RealtimeClaimParams;
using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Net;
using System.IO;

namespace EligibleService.Core
{

    public class RealtimeClaims : BaseCore
    {

        public RealtimeClaimsParams JsonObj { get; set; }

        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }
        public RealtimeClaimError EligibleError { get; set; }

        /// <summary>
        /// Claim submission with ClaimParam object
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public RealtimeClaimsResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(Path.Combine(EligibleResources.PathToClaims, EligibleResources.Realtime), jsonParams, SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.ResponseValidation<RealtimeClaimsResponse, RealtimeClaimError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }
    }
}
