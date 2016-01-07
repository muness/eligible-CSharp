using EligibleService.Core;
using Newtonsoft.Json.Linq;

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
            options = SetRequestOptionsObject(options);

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
                jobject.Add("test", options.IsTest);
            }
            else if (string.IsNullOrEmpty(jobject.Property("test").Value.ToString()))
            {
                jobject.Property("test").Value = options.IsTest;
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

                if (!options.IsTest.HasValue)
                {
                    if (eligible.IsTest.HasValue)
                        options.IsTest = eligible.IsTest;
                    else
                        options.IsTest = false;
                }
            }
            else
            {
                options = new RequestOptions();
                options.ApiKey = eligible.ApiKey;
                options.IsTest = eligible.IsTest;
            }

            return options;
        }

    }
}
