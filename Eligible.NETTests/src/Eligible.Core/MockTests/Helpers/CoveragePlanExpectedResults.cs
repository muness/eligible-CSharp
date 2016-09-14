using EligibleService.Model;
using EligibleService.Model.Coverage;
using System.Collections.ObjectModel;

namespace EligibleService.Core.Tests.Helpers
{
    public class CoveragePlanExpectedResults
    {
        public static Plan GetExpectedCoveragePlan()
        {
            
            Plan plan = new Plan()
            {
                Type = "1",
                CoverageStatus = "1",
                CoverageStatusLabel = "Active Coverage",
                CoverageBasis = new Collection<CoverageBasis>(),
                PlanNumber = "1234567",
                PlanName = "Test",
                PlanType = "PS",
                PlanTypeLabel = "Point of Service (POS)",
                GroupName = "Special group INC.",
                Dates = GetPlanDates(),
                Comments = new Collection<string>(),
                Exclusions = GetExclusions(),
                Financials = GetFinancials(),
                
            };

            return plan;
        }  

        public static Exclusions GetExclusions()
        {
            Exclusions exclusion = new Exclusions();
            exclusion.Noncovered = new Collection<NonCovered>();

            NonCovered nonCovered = new NonCovered();
            nonCovered.AuthorizationRequired = null;
            nonCovered.Type = "86";
            nonCovered.TypeLabel = "Emergency Services";
            nonCovered.TimePeriod = null;
            nonCovered.TimePeriodLabel = null;
            nonCovered.Level = "Test Only";
            nonCovered.Network = "IN";
            nonCovered.Pos = null;
            nonCovered.PosLabel = null;
            Collection<string> comments = new Collection<string>();
            comments.Add("test comment");
            nonCovered.Comments = comments;
            exclusion.Noncovered.Add(nonCovered);

            nonCovered.AuthorizationRequired = true;
            exclusion.Noncovered.Add(nonCovered);

            exclusion.PreexistingCondition = GetPreExistingCondition();
            return exclusion;
        }

        public static PreexistingCondition GetPreExistingCondition()
        {
            return new PreexistingCondition()
            {
                WaitingPeriod = new Collection<WaitingPeriod>()
            };
        }

        public static Financials GetFinancials()
        {
            Financials financials = new Financials()
            {
                Deductible = GetFinancial(),
                CostContainment = GetFinancial(),
                SpendDown = GetFinancial(),
                StopLoss = GetStopLoss()
            };
            
            return financials;
        }

        public static StopLossFinancial GetStopLoss()
        {
            StopLossFinancial financial = new StopLossFinancial();
            StopLossFinancialFlows remaindings = new StopLossFinancialFlows();
            Collection<StopLossFinancialFlow> inNetwork = new Collection<StopLossFinancialFlow>();
            inNetwork.Add(new StopLossFinancialFlow()
            {
                Amount = "4238.35",
                Level = "FAMILY",
                InsuranceType = null,
                InsuranceTypeLabel = null,
                Pos = null,
                PosLabel = null,
                AuthorizationRequired = null,
                Description = null,
                ContactDetails = new Collection<ContactDetail>(),
                Dates = new Collection<Dates>(),
                Comments = new Collection<string>(){
                        "INT MED AND RX"
                    },
            });

            Collection<StopLossFinancialFlow> outNetwork = new Collection<StopLossFinancialFlow>();
            remaindings.InNetwork = inNetwork;
            remaindings.OutNetwork = outNetwork;

            StopLossFinancialFlows spent = new StopLossFinancialFlows();
            spent.InNetwork = inNetwork;
            spent.OutNetwork = outNetwork;


            StopLossFinancialFlowTotals totals = new StopLossFinancialFlowTotals();
            Collection<StopLossFinancialFlowTotal> inNetwork1 = new Collection<StopLossFinancialFlowTotal>();
            Collection<Dates> dates = new Collection<Dates>();
            dates.Add(new Dates()
            {
                DateType = "eligibilty",
                DateValue = "2013-07-01"
            });
            inNetwork1.Add(new StopLossFinancialFlowTotal()
            {
                Amount = "4350",
                Level = "FAMILY",
                InsuranceType = null,
                InsuranceTypeLabel = null,
                Pos = null,
                PosLabel = null,
                AuthorizationRequired = null,
                Description = null,
                ContactDetails = new Collection<ContactDetail>(),
                Dates = dates,
                Comments = new Collection<string>(){
                        "INT MED AND RX,DED INCLUDED IN OOP,Visit or Evaluation by Chiropractor,Manipulation by Chiropractor,Emergency use of Emergency Room,Outpatient Surgery Facility,Outpatient Medical Ancillary,Ambulatory Medical Ancillary,Medical Ancillary,Inpatient Xray and Lab",
                        "Room and Board,Intensive Care Room and Board,Non Emergency use of Emergency Room,Emergency Room Physician,Urgent Care,Non Urgent Services at an Urgent Care Facility,GYN Visit,Specialist Visit or Evaluation,Primary Care Visit or Evaluation,Physician Xray and Lab",
                        "Xray and Lab,Outpatient Xray and Lab"
                        },
            });

            totals.InNetwork = inNetwork1;
            totals.OutNetwork = new Collection<StopLossFinancialFlowTotal>();

            financial.Remainings = remaindings;
            financial.Spent = spent;
            financial.Totals = totals;

            return financial;
        }

        public static Financial GetFinancial()
        {
            Financial financial = new Financial();
            FinancialFlowsRemainings remaindings = new FinancialFlowsRemainings();
            Collection<FinancialFlowRemainings> inNetwork = new Collection<FinancialFlowRemainings>();
            inNetwork.Add(new FinancialFlowRemainings()
                {
                    Amount = "4238.35",
                    Level = "FAMILY",
                    InsuranceType = null,
                    InsuranceTypeLabel = null,
                    Pos = null,
                    PosLabel = null,
                    AuthorizationRequired = null,
                    Description = null,
                    ContactDetails = new Collection<ContactDetail>(),
                    Dates = new Collection<Dates>(),
                    Comments = new Collection<string>(){
                        "INT MED AND RX"
                    },
                });

            Collection<FinancialFlowRemainings> outNetwork = new Collection<FinancialFlowRemainings>();
            remaindings.InNetwork = inNetwork;
            remaindings.OutNetwork = outNetwork;

            FinancialFlows spent = new FinancialFlows();
            spent.InNetwork = new Collection<FinancialFlow>();
            spent.OutNetwork = new Collection<FinancialFlow>();

            
            FinancialFlows totals = new FinancialFlows();
            Collection<FinancialFlow> inNetwork1 = new Collection<FinancialFlow>();
            Collection<Dates> dates = new Collection<Dates>();
            dates.Add(new Dates()
            {
                DateType = "eligibilty",
                DateValue = "2013-07-01"
            });
            inNetwork1.Add(new FinancialFlow()
            {
                Amount = "4350",
                TimePeriod = "25",
                TimePeriodLabel = "contract",
                Level = "FAMILY",
                InsuranceType = null,
                InsuranceTypeLabel = null,
                Pos = null,
                PosLabel = null,
                AuthorizationRequired = null,
                Description = null,
                ContactDetails = new Collection<ContactDetail>(),
                Dates = dates,
                Comments = new Collection<string>(){
                        "INT MED AND RX,DED INCLUDED IN OOP,Visit or Evaluation by Chiropractor,Manipulation by Chiropractor,Emergency use of Emergency Room,Outpatient Surgery Facility,Outpatient Medical Ancillary,Ambulatory Medical Ancillary,Medical Ancillary,Inpatient Xray and Lab",
                        "Room and Board,Intensive Care Room and Board,Non Emergency use of Emergency Room,Emergency Room Physician,Urgent Care,Non Urgent Services at an Urgent Care Facility,GYN Visit,Specialist Visit or Evaluation,Primary Care Visit or Evaluation,Physician Xray and Lab",
                        "Xray and Lab,Outpatient Xray and Lab"
                        },
            });

            totals.InNetwork = inNetwork1;
            totals.OutNetwork = new Collection<FinancialFlow>();

            financial.Remainings = remaindings;
            financial.Spent = spent;
            financial.Totals = totals;

            return financial;
            
        }

        public static FinancialFlowsPercents GetCoinsurance()
        {
            FinancialFlowsPercents coInsurence = new FinancialFlowsPercents();
            CoinsurancePercents finacialFLows = new CoinsurancePercents();
            finacialFLows.InNetwork = new Collection<CoinsurancePercent>();
            finacialFLows.OutNetwork = new Collection<CoinsurancePercent>();
            coInsurence.Percents = finacialFLows;
            return coInsurence;
        }

        public static FinancialFlowsAmounts GetCoPayment()
        {
            FinancialFlowsAmounts copayment = new FinancialFlowsAmounts();
            FinancialFlows finacialFLows = new FinancialFlows();
            finacialFLows.InNetwork = new Collection<FinancialFlow>();
            finacialFLows.OutNetwork = new Collection<FinancialFlow>();
            copayment.Amounts = finacialFLows;
            return copayment;
        }

        public static Collection<FinancialFlow> GetNetworkValues()
        {
            Collection<FinancialFlow>  network = new Collection<FinancialFlow>();
            
            network.Add(new FinancialFlow()
            {
                Amount = "4350",
                TimePeriod = "25",
                TimePeriodLabel = "contract",
                Level = "INDIVIDUAL",
                InsuranceType = "SELF",
                InsuranceTypeLabel = "SELFLABEL",
                Pos = "POS",
                PosLabel = "POSLABEL",
                AuthorizationRequired = null,
                Description = "Test",
                ContactDetails = GetContactDetails(),
                Dates = GetDates(),
                Comments = new Collection<string>(){
                        "INT MED AND RX,DED INCLUDED IN OOP,Visit or Evaluation by Chiropractor,Manipulation by Chiropractor,Emergency use of Emergency Room,Outpatient Surgery Facility,Outpatient Medical Ancillary,Ambulatory Medical Ancillary,Medical Ancillary,Inpatient Xray and Lab",
                                "Room and Board,Intensive Care Room and Board,Non Emergency use of Emergency Room,Emergency Room Physician,Urgent Care,Non Urgent Services at an Urgent Care Facility,GYN Visit,Specialist Visit or Evaluation,Primary Care Visit or Evaluation,Physician Xray and Lab",
                                "Xray and Lab,Outpatient Xray and Lab"
                        },
            });

            return network;
        }

        #region Contact info build
        public static Collection<ContactDetail> GetContactDetails()
        {
            Collection<ContactDetail> contactDetails = new Collection<ContactDetail>();
            contactDetails.Add(new ContactDetail()
            {
                EntityCode = "PR",
                EntityCodeLabel = "Payer",
                IdentificationCode = null,
                IdentificationType = null,
                Contacts = GetCcontacts(),
                Address = new Address()
                {
                    StreetLine1 = "PO Box 1234",
                    StreetLine2 = null,
                    City = "Lexington",
                    State = "KY",
                    Zip = "1234"
                },
            });
            return contactDetails;
        }
        
        public static Collection<Contact> GetCcontacts()
        {
            Collection<Contact> contacts = new Collection<Contact>();
            contacts.Add(new Contact()
            {
                ContactType = "TESTTYPE",
                ContactValue = "123456789"
            });
            return contacts;
        }
        #endregion

        #region Dates
        public static Collection<PlanDates> GetPlanDates()
        {
            Collection<PlanDates> dates = new Collection<PlanDates>();
            dates.Add(new PlanDates()
            {
                DateType = null,
                DateValue = null,
                DateSource = null
            });
            dates.Add(new PlanDates()
            {
                DateType = null,
                DateValue = null,
                DateSource = null
            });
            dates.Add(new PlanDates()
            {
                DateType = null,
                DateValue = null,
                DateSource = null
            });

            return dates;
        }

        public static Collection<Dates> GetDates()
        {
            Collection<Dates> dates = new Collection<Dates>();
            dates.Add(new Dates()
            {
                DateType = null,
                DateValue = null
            });
            dates.Add(new Dates()
            {
                DateType = null,
                DateValue = null
            });
            dates.Add(new Dates()
            {
                DateType = null,
                DateValue = null
            });

            return dates;
        }
        #endregion
    }
}
