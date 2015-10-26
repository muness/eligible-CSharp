using EligibleService.Common;
using EligibleService.Exceptions;
using EligibleService.Net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return RequestProcess.ValidateAndReturnResponse<dynamic, CoverageErrorDetails>(response);
        }

        public dynamic Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePdf(EligibleResources.ReferralCreate, jsonParams, SetRequestOptionsObject(options));
            JsonResponse = response.Content;
            return RequestProcess.ValidateAndReturnResponse<dynamic, ClaimErrors>(response);
        }

    }
}
