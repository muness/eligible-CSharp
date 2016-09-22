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
        public static TClassResponse ResponseValidation<TClassResponse, TClassError>(IRestResponse response, bool returnOnly = false)
        {
            string message = response.Content;

            if (response.ErrorException != null)
            {
                LogError<IRestResponse>(response);
                throw new InvalidRequestException(message, response.ErrorException);
            }

            TClassResponse sourceClass = default(TClassResponse);
            TClassError errorClass;
            bool parseJson = false;
            string error = string.Empty;

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LogError<IRestResponse>(response);
                throw new AuthenticationException(message, response, response.ErrorException);
            }
            else if(returnOnly)
            {
                parseJson = false;
                TryParseJson(response, out errorClass, out parseJson);

                if (!parseJson)
                {
                    parseJson = false;
                    sourceClass = JsonConvert.DeserializeObject<TClassResponse>(response.Content, GetJsonSerializerSettingsObject());
                    if (sourceClass != null)
                        return sourceClass;
                }
                else
                {
                    LogError<IRestResponse>(response);
                    throw new EligibleException(message, errorClass);
                }
            }
            else
            {
                TryParseJson(response, out sourceClass, out parseJson);
            }

            if (!parseJson)
            {
                parseJson = false;
                string eligibleError = string.Empty;
                TryParseJson(response, out errorClass, out parseJson);

                if (error != string.Empty)
                    eligibleError = eligibleError + ", " + error;

                if (parseJson)
                {
                    LogError<IRestResponse>(response);
                    throw new EligibleException(message, errorClass);
                }
                else
                {
                    LogError<IRestResponse>(response);
                    throw new InvalidRequestException(message, response.ErrorException);
                }
            }

            return sourceClass;
        }

        public static TClassResponse SimpleResponseValidation<TClassResponse>(IRestResponse response)
        {
            TClassResponse deserializedResponse = default(TClassResponse);
            string message = response.Content;
            bool isParsed = false;

            if (response.ErrorException != null)
            {
                LogError<IRestResponse>(response);
                throw new InvalidRequestException(message, response.ErrorException);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LogError<IRestResponse>(response);
                throw new AuthenticationException(message, response, response.ErrorException);
            }

            try
            {
                deserializedResponse = JsonConvert.DeserializeObject<TClassResponse>(response.Content);
                isParsed = true;
            }
            catch (Exception ex)
            {
                LogError<Exception>(ex);
            }

            if (deserializedResponse == null || !isParsed)
            {
                LogError<string>(message);
                throw new InvalidRequestException(message, response.ErrorException);
            }

            return deserializedResponse;
        }

        private static void TryParseJson<TClass>(IRestResponse response, out TClass sourceClass, out bool parseJson)
        {
            TClass sourceClassLocal = default(TClass);
            sourceClass = default(TClass);
            parseJson = false;
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
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            return JSSettings;
        }
    }
}
