using EligibleService.Common;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;

namespace EligibleService.Core
{
    public class BaseCore : FormatInputWithRequestOptions
    {
        protected IRequestExecute executeObj;
        protected IRestResponse response { get; set; }
        protected Hashtable param { get; set; }

        public BaseCore()
        {
            executeObj = new RequestExecute();
        }

        protected static string JsonSerialize(object inputParams)
        {
            return JsonConvert.SerializeObject(inputParams, Formatting.Indented);
        }
    }
}
