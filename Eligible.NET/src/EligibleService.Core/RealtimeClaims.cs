using EligibleService.Claim.RealtimeClaimParams;
using EligibleService.Claim.RealtimeClaims;
using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Model;
using EligibleService.Net;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.InteropServices;

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
        /// Claim submition with ClaimParam object
        /// https://gds.eligibleapi.com/rest#claim_and_reports_create_a_claim
        /// </summary>
        /// <param name="claimParams">Please refer Eligible REST doc for claim parameter details</param>
        /// <returns></returns>
        public RealtimeClaimsResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(Path.Combine(EligibleResources.PathToClaims, EligibleResources.Realtime), jsonParams, SetRequestOptionsObject(options));
            var formatedResponse = RequestProcess.ValidateAndReturnResponse<RealtimeClaimsResponse, RealtimeClaimError>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }
    }
}
