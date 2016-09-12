using EligibleService.Model;
using EligibleService.Model.Payer;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Core.Tests.Helpers
{
    public class PayerExpectedResults
    {
        public static PayerResponse GetExpectedPayer()
        {
            Collection<string> names = new Collection<string>();
            names.Add("CareIndia");

            return new PayerResponse()
            {
                PayerId = "00001",
                Names = names,
                CreatedAt = Convert.ToDateTime("2014-07-20T07:17:25Z"),
                UpdatedAt = Convert.ToDateTime("2015-06-12T13:19:53Z"),
                SupportedEndpoints = BuildEndPoints(),
                EligibleId = "33VV6363ERH68"
            };
        }

        public static Collection<Endpoint> BuildEndPoints()
        {
            Collection<string> enrolments = new Collection<string>();
            enrolments.Add("");
            Collection<Endpoint> endPoints = new Collection<Endpoint>();
            endPoints.Add(new Endpoint()
            {
                EndPoint = "professional claims",
                PassThroughFee = 0,
                AverageEnrollmentProcessTime = null,
                SignatureRequired = false,
                BlueInkRequired = false,
                Status = "available",
                StatusDetails = null,
                OriginalSignaturePdf = null,
                Message = null,
                StatusUpdatedAt = Convert.ToDateTime("2014-07-03T03:50:05+00:00"),
                EnrollmentMandatoryFields = new Collection<string>()

            });
            endPoints.Add(new Endpoint()
            {
                EndPoint = "institutional claims",
                PassThroughFee = 0,
                AverageEnrollmentProcessTime = null,
                SignatureRequired = false,
                BlueInkRequired = false,
                Status = "available",
                StatusDetails = "Payer is working fine",
                OriginalSignaturePdf = null,
                Message = null,
                StatusUpdatedAt = Convert.ToDateTime("2015-06-12T13:19:53+00:00"),
                EnrollmentMandatoryFields = new Collection<string>()

            });

            return endPoints;
        }
    }
}
