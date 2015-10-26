using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Common
{
    public class EligibleError
    {
        public string Type { get; set; }
        public string Content { get; set; }
        public byte[] Details { get; set; }

    }

    public class CommonErrorBuilder
    {
        public static EligibleError BuildError(IRestResponse response)
        {
            EligibleError eligibleError = new EligibleError();
            eligibleError.Content = response.Content;
            eligibleError.Type = response.StatusCode.ToString();
            eligibleError.Details = response.RawBytes;

            return eligibleError;
        }
    }
}
