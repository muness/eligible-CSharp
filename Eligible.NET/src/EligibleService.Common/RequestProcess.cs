using EligibleService.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Common
{
    public class RequestProcess
    {
        public static TClassResponse ValidateAndReturnResponse<TClassResponse, TClassError>(IRestResponse response)
        {
            string message = response.StatusCode.ToString() + ": " + response.Content;
            if (response.ErrorException != null)
            {
                throw new InvalidRequestException(message, response.ErrorException);
            }
            TClassResponse sourceClass = default(TClassResponse);
            bool parseJson = false;
            string error = string.Empty;
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
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
                error = string.Empty;
                TryParseJson(response, out errorClass, out parseJson, out error);
                if (parseJson)
                    throw new EligibleException(errorClass);
                else
                {
                    message = error + ". " + response.Content;
                    throw new InvalidRequestException(message, response.ErrorException);
                }
            }

            return sourceClass;
        }

        private static void TryParseJson<TClass>(IRestResponse response, out TClass sourceClass, out bool parseJson, out string error)
        {
            TClass sourceClassLocal = default(TClass);
            sourceClass = default(TClass);
            parseJson = false;
            error = "";
            try
            {
                sourceClassLocal = JsonConvert.DeserializeObject<TClass>(response.Content);
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
                sourceClass = sourceClassLocal;
                parseJson = false;
                error = ex.Message;
            }

            sourceClass = sourceClassLocal;
        }

        public static TClassResponse SimpleValidateAndReturnResponse<TClassResponse>(IRestResponse response)
        {
            TClassResponse deserilizedResponse = default(TClassResponse);
            string  message = response.StatusCode.ToString() + ":" + response.Content;
            bool isParsed = false;

            if (response.ErrorException != null)
            {
                throw new InvalidRequestException(message, response.ErrorException);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new AuthenticationException(response.Content, response, response.ErrorException);
            }

            try
            {
                deserilizedResponse = JsonConvert.DeserializeObject<TClassResponse>(response.Content);
                isParsed = true;
            }
            catch (Exception ex)
            {
               message = response.Content + ". " + ex.Message;
            }

            if (deserilizedResponse == null || !isParsed)
            {
                throw new InvalidRequestException(message, response.ErrorException);
            }

            return deserilizedResponse;
        }
    }
}
