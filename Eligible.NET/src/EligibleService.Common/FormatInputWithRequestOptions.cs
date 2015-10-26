using EligibleService.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Common
{
    public class FormatInputWithRequestOptions
    {
        public static string FormatJson(string jsonParams, RequestOptions options)
        {
            JObject jobject = JObject.Parse(jsonParams);
            Eligible eligible = Eligible.Instance;

            return AddingOptionsToJson(options, jobject);
        }
        private static string AddingOptionsToJson(RequestOptions options, JObject jobject)
        {
            if ((jobject.Property("api_key") == null))
            {
                jobject.Add("api_key", options.ApiKey);
            }
            else if (string.IsNullOrEmpty(jobject.Property("api_key").Value.ToString()))
            {
                jobject.Property("api_key").Value = options.ApiKey;
            }

            if ((jobject.Property("test") == null))
            {
                jobject.Add("test", options.TestMode);
            }
            else if (string.IsNullOrEmpty(jobject.Property("test").Value.ToString()))
            {
                jobject.Property("test").Value = options.TestMode;
            }

            return jobject.ToString();
        }

        public static RequestOptions SetRequestOptionsObject(RequestOptions options)
        {
            Eligible eligible = Eligible.Instance;

            if (options != null)
            {
                if (string.IsNullOrEmpty(options.ApiKey))
                    options.ApiKey = eligible.ApiKey;
                if (string.IsNullOrEmpty(options.ApiVersion))
                    options.ApiVersion = eligible.ApiVersion;
                if (!options.TestMode.HasValue)
                {
                    if (eligible.TestMode.HasValue)
                        options.TestMode = eligible.TestMode;
                    else
                        options.TestMode = false;
                }
            }
            else
            {
                options = new RequestOptions();
                options.ApiKey = eligible.ApiKey;
                options.TestMode = eligible.TestMode;
                options.ApiVersion = eligible.ApiVersion;
            }
            return options;
        }

    }
}
