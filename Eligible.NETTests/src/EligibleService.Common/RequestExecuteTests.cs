using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using EligibleService.Core;
namespace EligibleService.Common.Tests
{
    [TestClass()]
    public class RequestExecuteTests
    {
        public Eligible eligible { get; set; }
        RequestExecute execute;

        [TestInitialize]
        public void Setup()
        {
            eligible = Eligible.Instance;
            execute = new RequestExecute();
        }

        [TestMethod()]
        public void ServerCertificateValidationCallbackTest()
        {
            FingerprintPassTest();
        }

        [TestMethod()]
        public void SetMatchingFingerprintTest()
        {
            eligible.Fingerprint = "79D62E8A9D59AE687372F8E71345C76D92527FAC";
            FingerprintPassTest();

        }

        private void FingerprintPassTest()
        {
            var request = new RestRequest();
            var client = new RestClient(new Uri("https://gds.eligibleapi.com/v1.5"));

            ServicePointManager.ServerCertificateValidationCallback = execute.CertificateValidation;

            var response = client.Execute(request);
            Assert.AreEqual(null, response.ErrorMessage);
        }

        [TestMethod()]
        public void SetWrongFingerprintTest()
        {
            eligible.Fingerprint = "wrong fingerprint";

            var request = new RestRequest();
            var client = new RestClient(new Uri("https://gds.eligibleapi.com/"));

            ServicePointManager.ServerCertificateValidationCallback = execute.CertificateValidation;
            try
            {
                client.Execute(request);
            }
            catch(Exception ex)
            {
                Assert.AreEqual("The underlying connection was closed: Could not establish trust relationship for the SSL/TLS secure channel.", ex.Message);
            }
        }
    }
}
