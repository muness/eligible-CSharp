using EligibleService.Common;
using EligibleService.Model;
using EligibleService.Net;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;

namespace EligibleService.Core
{
    public class Payers : BaseCore
    {
        public Payers() : base() 
        { }

        /// <summary>
        /// Get all the payers
        /// https://gds.eligibleapi.com/v1.5/payers.json
        /// </summary>
        /// <returns>List of EligibleService.Model.Payer</returns>
        public PayersResponse All([Optional, DefaultParameterValue("")]string endpoint, [Optional, DefaultParameterValue("")]string enrollmentRequired, RequestOptions options = null)
        {
            param = new Hashtable();
            param.Add("endpoint", endpoint);
            param.Add("enrollment_required", enrollmentRequired);
            response = ExecuteObj.Execute(EligibleResources.PathToPayers, SetRequestOptionsObject(options), param);
            var formatResponse = RequestProcess.SimpleResponseValidation<Collection<PayerResponse>>(response);
            PayersResponse payers = new PayersResponse();
            payers.Payers = formatResponse;
            payers.SetJsonResponse(response.Content);
            return payers;
        }

        /// <summary>
        /// Get Player By ID. It's used to view a particular payer Ex: Payers.GetById("000010");
        /// API: GET https://gds.eligibleapi.com/v1.5/payers/:payer_id
        /// </summary>
        /// <param name="payerId"></param>
        /// <returns>single payer information</returns>
        public PayerResponse GetById(string payerId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToPayerById, payerId), SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.SimpleResponseValidation<PayerResponse>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// It returns the list of seach options supported by each payer.
        /// API: https://gds.eligibleapi.com/v1.5/payers/search_options
        /// </summary>
        /// <returns>List of EligibleService.Model.PayerSearchOption</returns>
        public PayersSearchOptionResponse SearchOptions(RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.PathToPayerSearchOptions, SetRequestOptionsObject(options));
            PayersSearchOptionResponse payersSearchOptionResponse = new PayersSearchOptionResponse();
            var formattedResponse = RequestProcess.SimpleResponseValidation<Collection<PayerSearchOptionResponse>>(response);
            payersSearchOptionResponse.SearchOptionsList = formattedResponse;
            payersSearchOptionResponse.SetJsonResponse(response.Content);
            return payersSearchOptionResponse; 
        }

        /// <summary>
        /// It returns the seach options for payer.
        /// https://gds.eligibleapi.com/v1.5/payers/00001/search_options
        /// </summary>
        /// <returns>single payer search options</returns>
        public PayerSearchOptionResponse SearchOptions(string payerId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.PathToPayerById + payerId + EligibleResources.SearchOptions, SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.SimpleResponseValidation<PayerSearchOptionResponse>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Retrieve payer status
        /// GET https://gds.eligibleapi.com/v1.1/payers/status.json"
        /// </summary>
        /// <param name="RequestParams">Ex: transaction_type=270</param>
        /// <returns></returns>
        public StatusResponse Statusses([Optional, DefaultParameterValue("270")]string transactionType, RequestOptions options = null)
        {
            param = new Hashtable();
            param.Add("transaction_type", transactionType);
            response = ExecuteObj.Execute(EligibleResources.PathtoPayersStatus, SetRequestOptionsObject(options), param);
            var formattedResponse = RequestProcess.SimpleResponseValidation<StatusResponse>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Retrieve payer status by payerID
        /// GET https://gds.eligibleapi.com/v1.1/payers/{payer_id}/status.json
        /// </summary>
        /// <param name="RequestParams">Ex: transaction_type=270</param>
        /// <returns></returns>
        public StatusResponse StatussesByPayer(string payerId, [Optional, DefaultParameterValue("270")]string transactionType, RequestOptions options = null)
        {
            param = new Hashtable();
            param.Add("transaction_type", transactionType);
            response = ExecuteObj.Execute(EligibleResources.PathToPayerById + payerId + EligibleResources.PayerStatus, SetRequestOptionsObject(options), param);
            var formattedResponse = RequestProcess.SimpleResponseValidation<StatusResponse>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// Retrieve payer by Status
        /// https://gds.eligibleapi.com/v1.1/payers/status/unavailable.json
        /// </summary>
        /// <param name="RequestParams">Ex: transaction_type=270</param>
        /// <returns></returns>
        public StatusResponse GetPayersByStatus(string status, [Optional, DefaultParameterValue("270")]string transactionType, RequestOptions options = null)
        {
            param = new Hashtable();
            param.Add("transaction_type", transactionType);
            response = ExecuteObj.Execute(EligibleResources.PathtoPayersStatus + "/" + status, SetRequestOptionsObject(options), param);
            var formattedResponse = RequestProcess.SimpleResponseValidation<StatusResponse>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }
    }
}
