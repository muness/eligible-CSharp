using EligibleService.Common;
using EligibleService.Model;
using EligibleService.Model.Customer;
using EligibleService.Net;
using Newtonsoft.Json;
using RestSharp;
using System.Collections;
using System.IO;

namespace EligibleService.Core
{
    public class Customer : BaseCore
    {
        public CustomerParams JsonObj { get; set; }

        public IRequestExecute ExecuteObj
        {
            get { return executeObj; }
            set { executeObj = value; }
        }

        public Customer() : base() { }
        /// <summary>
        /// It's a POST request to create Customer
        /// https://gds.eligibleapi.com/rest#create_customers
        /// </summary>
        /// <param name="customerHashParams">Required parameters in the form of Hashtable</param>
        /// <returns></returns>
        public CustomerResponse Create(Hashtable customerHashParams, RequestOptions options = null)
        {
            return Create(JsonConvert.SerializeObject(customerHashParams, Formatting.Indented), options);
        }

        /// <summary>
        /// It's a POST request to create Customer
        /// https://gds.eligibleapi.com/rest#create_customers
        /// </summary>
        /// <param name="CustomerParams">Required parameters in the form of CustomerParams object</param>
        /// <returns></returns>
        public CustomerResponse Create(CustomerParams customerParams, RequestOptions options = null)
        {
            return Create(JsonConvert.SerializeObject(customerParams, Formatting.Indented), options);
        }

        /// <summary>
        /// It's a POST request to create Customer
        /// https://gds.eligibleapi.com/rest#create_customers
        /// </summary>
        /// <param name="jsonParams">Required parameters in the form of json</param>
        /// <returns></returns>
        public CustomerResponse Create(string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(EligibleResources.PathToCustomers, jsonParams, SetRequestOptionsObject(options), Method.POST);
            var formattedResponse =  RequestProcess.ResponseValidation<CustomerResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// It's a POST request to create Customer
        /// https://gds.eligibleapi.com/rest#create_customers
        /// </summary>
        /// <param name="companyName"></param>
        /// <param name="siteName"></param>
        /// <returns></returns>
        public CustomerResponse Create(string companyName, string siteName, RequestOptions options = null)
        {
            CustomerParams custParams = BuildCustomerParams(companyName, siteName, options);
            return Create(JsonConvert.SerializeObject(custParams), options);
        }

        private CustomerParams BuildCustomerParams(string companyName, string siteName, RequestOptions options)
        {
            CustomerParams custParams = new CustomerParams();
            options = SetRequestOptionsObject(options);
            custParams.Customer = new CustomerTag()
            {
                Name = companyName,
                SiteName = siteName
            };
            return custParams;
        }

        /// <summary>
        /// It's a PUT request to Update Customer
        /// https://gds.eligibleapi.com/rest#update_customers
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="companyName"></param>
        /// <param name="siteName"></param>
        /// <returns></returns>
        public CustomerResponse Update(string customerId, string companyName, string siteName, RequestOptions options = null)
        {
            CustomerParams custParams = BuildCustomerParams(companyName, siteName, options);
            return Update(customerId, JsonConvert.SerializeObject(custParams));
        }

        /// <summary>
        /// It's a PUT request to Update Customer
        /// https://gds.eligibleapi.com/rest#update_customers
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="jsonParams">Required params in the form of json</param>
        /// <returns></returns>
        public CustomerResponse Update(string customerId, string jsonParams, RequestOptions options = null)
        {
            response = ExecuteObj.ExecutePostPut(Path.Combine(EligibleResources.PathToCustomers, customerId), jsonParams, SetRequestOptionsObject(options), Method.PUT);
            var formattedResponse = RequestProcess.ResponseValidation<CustomerResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// It's a PUT request to Update Customer
        /// https://gds.eligibleapi.com/rest#update_customers
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="jsonParams">Required params in the form of Hashtable</param>
        /// <returns></returns>
        public CustomerResponse Update(string customerId, Hashtable customerParams, RequestOptions options = null)
        {
            return Update(customerId, JsonConvert.SerializeObject(customerParams, Formatting.Indented),options);
        }

        /// <summary>
        /// It's a PUT request to Update Customer
        /// https://gds.eligibleapi.com/rest#update_customers
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="jsonParams">Required params in the form of CustomerParams object</param>
        /// <returns></returns>
        public CustomerResponse Update(string customerId, CustomerParams customerParams, RequestOptions options = null)
        {
            return Update(customerId, JsonConvert.SerializeObject(customerParams, Formatting.Indented), options);
        }

        /// <summary>
        /// View a Customer
        /// https://gds.eligibleapi.com/rest#show_customers
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public CustomerResponse GetByCustomerId(string customerId, RequestOptions options = null)
        {
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToCustomers, customerId), SetRequestOptionsObject(options));
            var formattedResponse = RequestProcess.ResponseValidation<CustomerResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }

        /// <summary>
        /// List Customers
        /// https://gds.eligibleapi.com/rest#list_customers
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public CustomersResponse GetAll(string page = "", RequestOptions options = null)
        {
            param = new Hashtable();
            param.Add("page", page);
            response = ExecuteObj.Execute(Path.Combine(EligibleResources.PathToCustomers), SetRequestOptionsObject(options), param);
            var formattedResponse = RequestProcess.ResponseValidation<CustomersResponse, EligibleError>(response);
            formattedResponse.SetJsonResponse(response.Content);
            return formattedResponse;
        }
    }
}
