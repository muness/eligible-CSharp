using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Net;
using System.Collections;
using System.IO;

namespace EligibleService.Core
{
    public class Referral : BaseCore
    {
        public string JsonResponse { get; set; }

        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        public Referral() : base(){}

        public dynamic Inquiry(Hashtable requiredParams, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.ReferralInquiry), SetRequestOptionsObject(options),  requiredParams);
            JsonResponse = response.Content;
            return RequestProcess.ResponseValidation<dynamic, CoverageErrorDetails>(response);
        }

        public dynamic Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePdf(EligibleResources.ReferralCreate, jsonParams, SetRequestOptionsObject(options));
            JsonResponse = response.Content;
            return RequestProcess.ResponseValidation<dynamic, ClaimErrors>(response);
        }

    }
}
