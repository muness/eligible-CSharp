using EligibleService.Model;
using EligibleService.Model.Medicare;
using System;
using System.Collections.ObjectModel;

namespace EligibleService.Core.Tests.Helpers
{
    public class MedicareExpectedResults
    {

        public static MedicareResponse GetExpectedMedicate()
        {
            #region Contacts
            Collection<Contact> contacts = new Collection<Contact>();
            contacts.Add(new Contact(){
                ContactType = "telephone",
                ContactValue = "AAABBBCCCC"
            });
            contacts.Add(new Contact(){
                ContactType = "url",
                ContactValue = "www.website.com"
            });
            #endregion

            #region address
            Address address = new Address()
            {
                    StreetLine1 = "ADDRESSLINE1",
                    StreetLine2 = "ADDRESSLINE2",
                    City = "CITY",
                    State = "ST",
                    Zip = "920543314"
            };
            #endregion

            #region Requested service types
            Collection<MedicareService> medicareServices = new Collection<MedicareService>();
            medicareServices.Add(new MedicareService()
            {
                Type = "30",
                TypeLabel = "Health Benefit Plan Coverage",
                PlanType = "MA",
                Active = true,
                StartDate = "2005-04-01",
                EndDate = null,
                Deductible = 1184,
                DeductibleRemaining = 1184,
                CoinsurancePercent = null,
                Copayment = null,
                InfoValidTill = "2013-12-31"
            });
            medicareServices.Add(new MedicareService()
            {
                Type = "30",
                TypeLabel = "Health Benefit Plan Coverage",
                PlanType = "MB",
                Active = true,
                StartDate = "2005-04-01",
                EndDate = null,
                Deductible = 147,
                DeductibleRemaining = 0,
                CoinsurancePercent = 20,
                Copayment = null,
                InfoValidTill = "2013-12-31"
            });
            medicareServices.Add(new MedicareService()
            {
                Type = "30",
                TypeLabel = "Health Benefit Plan Coverage",
                PlanType = "MC",
                Active = true,
                StartDate = "2009-01-01",
                EndDate = null,
                Deductible = null,
                DeductibleRemaining = null,
                CoinsurancePercent = null,
                Copayment = null,
                InfoValidTill = "2013-12-31"
            });
            medicareServices.Add(new MedicareService()
            {
                Type = "30",
                TypeLabel = "Health Benefit Plan Coverage",
                PlanType = "PR",
                Active = true,
                StartDate = "2011-06-01",
                EndDate = null,
                Deductible = null,
                DeductibleRemaining = null,
                CoinsurancePercent = null,
                Copayment = null,
                InfoValidTill = "2013-12-31"
            });

            #endregion

            #region requested_procedure_codes
            Collection<ProcedureCodes> procedureCodes = new Collection<ProcedureCodes>();
            procedureCodes.Add(new ProcedureCodes()
            {
                ProcedureCode = "G0106",
                ProcedureLabel = "Colorectal Cancer Screening (COLO)",
                PlanType = "MB",
                Active = true,
                Deductible = 0,
                DeductibleRemaining = null,
                CoinsurancePercent = 20,
                Copayment = null,
                InfoValidTill = "2013-12-31",
                NextEligibleDate = new EligibleDate(){
                    Professional = "2012-07-01",
                    Technical = "2012-06-01"

                }
            });
            #endregion

            return new MedicareResponse()
            {
                CreatedAt = Convert.ToDateTime("2013-07-17T18:11:01Z"),
                EligibleId = "87RU2GTQ882ILC",
                LastName = "LNAME",
                FirstName = "FNAME",
                MemberId = "123456789A",
                GroupId = "070607801700001",
                GroupName = "SOME GROUP COMPANIES",
                Dob = "1940-04-01",
                Gender = "F",
                Address = address,
                PayerName = "CMS",
                PayerId = null,
                PlanNumber = "0706078",
                EligibiltyDates = new DatesPeriod()
                {
                    Start = "2012-02-01",
                    End = "2013-03-31"
                },
                InactivityDates = new DatesPeriod()
                {
                    Start = "2012-03-01",
                    End = "2012-05-03"
                },
                PlanTypes = new PlanType()
                {
                    MA = "Medicare Part A (Hospital)",
                    MB = "Medicare Part B (Professional Services)",
                    MC = "Medicare Part C (Advantage)",
                    MD = "Medicare Part D (Prescription drugs)",
                    PR = "Primary insurance (Medicare Secondary, Other Insurance is Primary)"
                },
                PlanDetails = new PlanDetails(){
                    MA = new HospitalAndProfessionalDetails()
                    {
                        Active = true,
                        StartDate = "2005-04-01",
                        EndDate = null,
                        Deductible = 1184,
                        DeductibleRemaining = 1184,
                        CoinsurancePercent = null,
                        Copayment = null,
                        InfoValidTill = "2013-12-31"
                    },
                    MB = new HospitalAndProfessionalDetails()
                    {
                        Active = true,
                        StartDate = "2005-04-01",
                        EndDate = null,
                        Deductible = 147,
                        DeductibleRemaining = 0,
                        CoinsurancePercent = 20,
                        Copayment = null,
                        InfoValidTill = "2013-12-31"
                    },
                    MC = new MCDetails()
                    {
                        Active = true,
                        PayerName = "ORGNAME",
                        InsuranceType = "IN",
                        InsuranceTypeLabel = "Indemnity",
                        McoBillOptionCode = "C",
                        McoBillOptionLabel = "MCO should process all claims",
                        Locked = true,
                        PolicyNumber = "H0000 999",
                        EffectiveDate = "2009-01-01",
                        TerminationDate = null,
                        Contacts = contacts,
                        Address = new Address()
                        {
                            StreetLine1 = "ADDRESSLINE1",
                            StreetLine2 = "ADDRESSLINE2",
                            City = "CITY",
                            State = "ST",
                            Zip = "ZIPCODE"
                        },
                    },
                    MD = new BasicDetails()
                    {
                        Active = true,
                        PayerName = "ORGNAME",
                        PolicyNumber = "S0000 999",
                        EffectiveDate = "2012-01-01",
                        TerminationDate = null,
                        Contacts = contacts,
                        Address = new Address()
                        {
                            StreetLine1 = "ADDRESSLINE1",
                            StreetLine2 = "ADDRESSLINE2",
                            City = "CITY",
                            State = "ST",
                            Zip = "123456"
                        },
                    },
                    PR = new BasicDetails()
                    {
                        Active = true,
                        PayerName = "ORGNAME",
                        PolicyNumber = "POLICYNUMBER",
                        EffectiveDate = "2011-06-01",
                        TerminationDate = "2012-06-01",
                        Contacts = contacts,
                        Address = new Address()
                        {
                            StreetLine1 = "ADDRESSLINE1",
                            StreetLine2 = "ADDRESSLINE2",
                            City = "CITY",
                            State = "ST",
                            Zip = "ZIPCODE"
                        },
                    }
                },
                RequestedServiceTypes = medicareServices,
                RequestedProcedureCodes = procedureCodes
            };
        }
        
    }
}
