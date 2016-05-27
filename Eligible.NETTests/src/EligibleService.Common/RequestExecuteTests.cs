using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System.Net;
using EligibleService.Core;
using System.Collections;
using System.Threading.Tasks;
using Moq;

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
        public void DefaultFingerprintTest()
        {
            FingerprintPassTest();
        }

        [TestMethod()]
        public void SetMatchingFingerprintTest()
        {
            eligible.AddFingerprint("79D62E8A9D59AE687372F8E71345C76D92527FAC");
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
            eligible.WhiteListedDomains.Add("eligible.com");

            var request = new RestRequest();
            var client = new RestClient(new Uri("https://gds.eligibleapi.com"));

            ServicePointManager.ServerCertificateValidationCallback = execute.CertificateValidation;
            
            var response = client.Execute(request);
            Assert.AreEqual("The underlying connection was closed: Could not establish trust relationship for the SSL/TLS secure channel.", response.ErrorMessage);
        }

        [TestMethod()]
        public void NonEligibleApiCallCertPinningTest()
        {
            var request = new RestRequest();

            Parallel.Invoke
            (
                () =>
                {

                    var client = new RestClient(new Uri("https://gds.eligibleapi.com/v1.5"));
                    ServicePointManager.ServerCertificateValidationCallback = execute.CertificateValidation;
                    var response = client.Execute(request);
                    Assert.AreEqual(null, response.ErrorMessage);

                },
                () =>
                {
                    request = new RestRequest();
                    var client = new RestClient(new Uri("https://api.github.com/"));
                    ServicePointManager.ServerCertificateValidationCallback = execute.CertificateValidation;
                    var response = client.Execute(request);
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                }
            );

        }

        [TestMethod()]
        public void LogMessageWhenSetterCalledTest()
        {
            eligible.AddFingerprint("Modifying fingerprint");
            Assert.AreEqual("Modifying the certificate fingerprint is not advised. This should only be done if instructed by eligible.com support. Please update to the latest version of the eligible library for certificate fingerprint updates.", Logging.GetLastMessage());
         }

        [TestMethod()]
        public void NoLogMessageWhenSetterNotCalledTest()
        {
            new Logging();
            Assert.AreEqual(string.Empty, Logging.GetLastMessage());
        }
    }
}
