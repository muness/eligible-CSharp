using EligibleService.Exceptions;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using System;
using System.Linq;

namespace EligibleService.Common
{
    public class RequestProcess
    {
        public static TClassResponse ResponseValidation<TClassResponse, TClassError>(IRestResponse response)
        {
            string message = response.StatusCode.ToString() + ": " + response.Content;

            if (response.ErrorException != null)
            {
                LogError<IRestResponse>(response);
                throw new InvalidRequestException(message, response.ErrorException);
            }

            TClassResponse sourceClass = default(TClassResponse);
            bool parseJson = false;
            string error = string.Empty;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LogError<IRestResponse>(response);
                throw new AuthenticationException(response.Content, response, response.ErrorException);
            }
            else
            {
                TryParseJson(response, out sourceClass, out parseJson, out error);
            }

            if (!parseJson)
            {
                TClassError errorClass;
                parseJson = false;
                string eligibleError = string.Empty;
                TryParseJson(response, out errorClass, out parseJson, out eligibleError);

                if (error != string.Empty)
                    eligibleError = eligibleError + ", " + error;

                if (parseJson)
                {
                    LogError<IRestResponse>(response);
                    throw new EligibleException(eligibleError, errorClass);
                }
                else
                {
                    LogError<IRestResponse>(response);
                    message = eligibleError + response.Content;
                    throw new InvalidRequestException(message, response.ErrorException);
                }
            }

            return sourceClass;
        }

        public static TClassResponse SimpleResponseValidation<TClassResponse>(IRestResponse response)
        {
            TClassResponse deserializedResponse = default(TClassResponse);
            string message = response.StatusCode.ToString() + ":" + response.Content;
            bool isParsed = false;

            if (response.ErrorException != null)
            {
                LogError<IRestResponse>(response);
                throw new InvalidRequestException(message, response.ErrorException);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LogError<IRestResponse>(response);
                throw new AuthenticationException(response.Content, response, response.ErrorException);
            }

            try
            {
                deserializedResponse = JsonConvert.DeserializeObject<TClassResponse>(response.Content);
                isParsed = true;
            }
            catch (Exception ex)
            {
                message = response.Content + ". " + ex.Message;
                LogError<Exception>(ex);
            }

            if (deserializedResponse == null || !isParsed)
            {
                LogError<string>(message);
                throw new InvalidRequestException(message, response.ErrorException);
            }

            return deserializedResponse;
        }

        private static void TryParseJson<TClass>(IRestResponse response, out TClass sourceClass, out bool parseJson, out string error)
        {
            TClass sourceClassLocal = default(TClass);
            sourceClass = default(TClass);
            parseJson = false;
            error = string.Empty;
            try
            {
                sourceClassLocal = JsonConvert.DeserializeObject<TClass>(response.Content, GetJsonSerializerSettingsObject());
                if (sourceClassLocal != null)
                {
                    int count = sourceClassLocal.GetType().GetProperties()
                              .Select(prop => prop.GetValue(sourceClassLocal, null))
                              .Where(val => val != null)
                              .Select(val => val.ToString())
                              .Where(str => str.Length > 0).ToList().Count;
                    if (count > sourceClassLocal.GetType().GetProperties().Count() / 2)
                    {
                        sourceClass = sourceClassLocal;
                        parseJson = true;
                    }
                }
                else
                    parseJson = false;
            }
            catch (Exception ex)
            {
                parseJson = false;
                error = ex.Message;
                LogError<Exception>(ex);
            }
            finally
            {
                sourceClass = sourceClassLocal;
            }
        }

        private static void LogError<dynamic>(dynamic error)
        {
            Logger logger = LogManager.GetLogger("");
            logger.Error<dynamic>(error);
        }

        private static JsonSerializerSettings GetJsonSerializerSettingsObject()
        {
            JsonSerializerSettings JSSettings = new JsonSerializerSettings()
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
            };

            return JSSettings;
        }
    }
}
