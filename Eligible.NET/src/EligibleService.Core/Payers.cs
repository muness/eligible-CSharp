using EligibleService.Common;
using EligibleService.Model;
using System.Collections.Generic;
using EligibleService.Net;
using System.Collections;
using System.IO;
using EligibleService.Model.Payer;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System;

namespace EligibleService.Core
{
    public class Payers : BaseCore
    {
        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        public Payers() : base(){}

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
            var formatResponse = RequestProcess.SimpleValidateAndReturnResponse<Collection<PayerResponse>>(response);
            PayersResponse payers = new PayersResponse();
            payers.Payers = formatResponse;
            payers.SetJsonResponse(response.Content);
            return payers;
        }

        /// <summary>
        ///Get Player By ID. It's used to view a particular payer Ex: Payers.GetById("000010");
        /// API: GET https://gds.eligibleapi.com/v1.5/payers/:payer_id
        /// </summary>
        /// <param name="payerId"></param>
        /// <returns>EligibleService.Model.Payer</returns>
        public PayerResponse GetById(string payerId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToPayerById, payerId), SetRequestOptionsObject(options));
            var formatedResponse = RequestProcess.SimpleValidateAndReturnResponse<PayerResponse>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
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
            var formatedResponse = RequestProcess.SimpleValidateAndReturnResponse<Collection<PayerSearchOptionResponse>>(response);
            payersSearchOptionResponse.SearchOptionsList = formatedResponse;
            payersSearchOptionResponse.SetJsonResponse(response.Content);
            return payersSearchOptionResponse; 
        }

        /// <summary>
        /// It returns the seach options for payer.
        /// https://gds.eligibleapi.com/v1.5/payers/00001/search_options
        /// </summary>
        /// <returns>EligibleService.Model.PayerSearchOption</returns>
        public PayerSearchOptionResponse SearchOptions(string payerId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(EligibleResources.PathToPayerById + payerId + EligibleResources.SearchOptions, SetRequestOptionsObject(options));
            var formatedResponse = RequestProcess.SimpleValidateAndReturnResponse<PayerSearchOptionResponse>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }

        /// <summary>
        /// Retrieve payer status
        /// GET https://gds.eligibleapi.com/v1.1/payers/status.json"
        /// </summary>
        /// <param name="RequestParams">Ex: transaction_type=270</param>
        /// <returns></returns>
        public StatusResponse Statusses([Optional, DefaultParameterValue("270")]string transactionType,RequestOptions options = null)
        {
            param = new Hashtable();
            param.Add("transaction_type", transactionType);
            response = ExecuteObj.Execute(EligibleResources.PathtoPayersStatus, SetRequestOptionsObject(options), param);
            var formatedResponse = RequestProcess.SimpleValidateAndReturnResponse<StatusResponse>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
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
            var formatedResponse = RequestProcess.SimpleValidateAndReturnResponse<StatusResponse>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
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
            var formatedResponse = RequestProcess.SimpleValidateAndReturnResponse<StatusResponse>(response);
            formatedResponse.SetJsonResponse(response.Content);
            return formatedResponse;
        }
    }
}
