using EligibleService.Common;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;

namespace EligibleService.Core
{
    public class BaseCore : FormatInputWithRequestOptions
    {
        public BaseCore()
        {
            this.executeObj = new RequestExecute();
        }

        private IRequestExecute executeObj;

        public IRequestExecute ExecuteObj
        {
            get { return this.executeObj; }
            set { this.executeObj = value; }
        }

        protected IRestResponse response { get; set; }

        protected Hashtable param { get; set; }

        protected static string JsonSerialize(object inputParams)
        {
            return JsonConvert.SerializeObject(inputParams, Formatting.Indented);
        }
    }
}
