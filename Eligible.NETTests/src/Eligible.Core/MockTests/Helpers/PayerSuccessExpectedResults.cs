using EligibleService.Model;
using EligibleService.Model.Payer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EligibleService.Core.Tests.Helpers
{
    public class PayerSuccessExpectedResults
    {
        public static StatusResponse GetExpectePayersStatusses()
        {
            StatusResponse status = new StatusResponse();
            Collection<PayerStatus> statuses = new Collection<PayerStatus>();

            statuses.Add(new PayerStatus()
                {
                    PayerId = "00001",
                    PayerName = "Connecticut General",
                    TransactionType = "270",
                    Status = "available",
                    Details = "Payer is working fine.",
                    UpdatedAt = "05-08-2015 20:21",
                    Message = null
                });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00002",
                PayerName = "Southwest Health Plan",
                TransactionType = "270",
                Status = "intermittent_failures",
                Details = "Payer is experiencing transient failures.",
                UpdatedAt = "28-10-2015 16:51",
                Message = null
            });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00003",
                PayerName = "Health Plans",
                TransactionType = "270",
                Status = "available",
                Details = "Payer is working fine.",
                UpdatedAt = "05-08-2015 23:23",
                Message = null
            });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00004",
                PayerName = "Cal Medicaid",
                TransactionType = "270",
                Status = "available",
                Details = "Payer is working fine.",
                UpdatedAt = "06-08-2015 00:25",
                Message = null
            });

            status.Statuses = statuses;

            return status;
        }

        public static StatusResponse GetExpectePayersStatussesById()
        {
            StatusResponse status = new StatusResponse();
            Collection<PayerStatus> statuses = new Collection<PayerStatus>();

            statuses.Add(new PayerStatus()
            {
                PayerId = "00002",
                PayerName = "Test1 | Test of New Jersey| Test2 of New Jersey NY",
                TransactionType = "270",
                Status = "intermittent_failures",
                Details = "Payer is experiencing transient failures.",
                UpdatedAt = "28-10-2015 16:51",
                Message = null
            });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00002",
                PayerName = "NYC",
                TransactionType = "276",
                Status = "available",
                Details = "Payer is working fine.",
                UpdatedAt = "05-06-2014 21:11",
                Message = null
            });

            status.Statuses = statuses;

            return status;
        }

        public static StatusResponse GetExpectePayersStatussesByStatus()
        {
            StatusResponse status = new StatusResponse();
            Collection<PayerStatus> statuses = new Collection<PayerStatus>();

            statuses.Add(new PayerStatus()
            {
                PayerId = "00028",
                PayerName = "Test1 Medicaid",
                TransactionType = "270",
                Status = "unavailable",
                Details = "Payer is experiencing high number of failures.",
                UpdatedAt = "06-08-2015 04:57",
                Message = null
            });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00032",
                PayerName = "Pop Healthcare | Pop Health Plan",
                TransactionType = "270",
                Status = "unavailable",
                Details = "Payer is experiencing high number of failures.",
                UpdatedAt = "06-08-2015 00:23",
                Message = null
            });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00038",
                PayerName = "Something Medicaid",
                TransactionType = "270",
                Status = "unavailable",
                Details = "Payer is experiencing high number of failures.",
                UpdatedAt = "04-11-2015 17:20",
                Message = null
            });

            statuses.Add(new PayerStatus()
            {
                PayerId = "00052",
                PayerName = "Nevada medicaid",
                TransactionType = "270",
                Status = "unavailable",
                Details = "Payer is experiencing high number of failures.",
                UpdatedAt = "20-06-2014 18:10",
                Message = null
            });

            status.Statuses = statuses;

            return status;
        }
    }
}
