using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EligibleService.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using EligibleService.Core;
using EligibleService.Core.CoreTests;
namespace EligibleService.Common.Tests
{
    [TestClass()]
    public class RequestExecuteTests
    {
        public RequestOptions options { get; set; }
        public Eligible eligible { get; set; }

        [TestInitialize]
        public void Setup()
        {
            options = new RequestOptions();
            string value = System.Configuration.ConfigurationManager.AppSettings["apikey"];
            options.ApiKey = (String.IsNullOrEmpty(value)) ? Environment.GetEnvironmentVariable("apikey") : value;
            options.IsTest = true;
        }

        [TestMethod()]
        public void ServerCertificateValidationCallbackTest()
        {
            RequestExecute execute = new RequestExecute();

            var response = execute.Execute("", options, null);
            
            Assert.AreEqual(null, response.ErrorMessage);
        }

        [TestMethod()]
        public void SettingFingerprintTHroughEligibleClassTest()
        {
            eligible = Eligible.Instance;
            eligible.Fingerprint = "79D62E8A9D59AE687372F8E71345C76D92527FAC";

            RequestExecute execute = new RequestExecute();

            var response = execute.Execute("", options, null);

            Assert.AreEqual(null, response.ErrorMessage);
        }

        [TestMethod()]
        public void SettingFingerprintThroughAppSettingTest()
        {
            eligible = Eligible.Instance;
            eligible.Fingerprint = null;

            System.Configuration.ConfigurationManager.AppSettings["fingerprint"] = "79D62E8A9D59AE687372F8E71345C76D92527FAC";
            RequestExecute execute = new RequestExecute();
            var response = execute.Execute("", options, null);

            Assert.AreEqual(null, response.ErrorMessage);
        }
    }
}
