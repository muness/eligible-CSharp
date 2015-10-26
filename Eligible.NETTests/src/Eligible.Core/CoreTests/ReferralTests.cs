using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using EligibleService.Core.Tests;
using EligibleService.NETTests;

namespace EligibleService.Core.CoreTests
{
    [TestClass]
    public class ReferralTests
    {
        Referral referral;
        [TestInitialize]
        public void Setup()
        {
            referral = new Referral();
            BaseTestClass.SetConfiguration();
        }
        [TestMethod]
        [ExpectedException(typeof(EligibleService.Exceptions.EligibleException))]
        public void ReferralInquiryTest()
        {
            Hashtable ReferralParams = new Hashtable();
            var response = referral.Inquiry(ReferralParams);
        }

        [TestMethod]
        [ExpectedException(typeof(EligibleService.Exceptions.InvalidRequestException))]
        public void ReferralCreateTest()
        {
            var response = referral.Create("test empty json");
        }

    }
}
