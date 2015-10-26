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
    public class SearchOptionsExpectedResults
    {
        public static Collection<PayerSearchOptionResponse> GetExpectedSearchOption()
        {
            Collection<Collection<string>> searchOptions = new Collection<Collection<string>>();
            Collection<PayerSearchOptionResponse> payerSearchOptions = new Collection<PayerSearchOptionResponse>();

            payerSearchOptions.Add(new PayerSearchOptionResponse()
            {
                PayerId = "00028",
                SearchOptions = searchOptions,
            });

            #region SearchOptions 1
            Collection<string> searchOption = new Collection<string>();
            searchOption.Add("member_id");      
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_dob");
            searchOption.Add("member_ssn");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_first_name");
            searchOption.Add("member_first_name");
            searchOption.Add("member_ssn");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_first_name");
            searchOption.Add("member_last_name");
            searchOption.Add("member_dob");
            searchOption.Add("member_gender");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_id");
            searchOption.Add("member_first_name");
            searchOption.Add("member_last_name");
            searchOption.Add("member_dob");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("chop_member_id");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_first_name");
            searchOption.Add("member_last_name");
            searchOption.Add("member_dob");
            searchOption.Add("chop_member_id");
            searchOptions.Add(searchOption);
            #endregion

            payerSearchOptions.Add(new PayerSearchOptionResponse()
            {
                PayerId = "00074",
                SearchOptions = searchOptions,
            });

            #region SearchOptions 2
            searchOptions = new Collection<Collection<string>>();
            searchOption = new Collection<string>();
            searchOption.Add("member_id");
            searchOption.Add("member_ssn");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_id");
            searchOption.Add("member_first_name");
            searchOption.Add("member_last_name");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_id");
            searchOption.Add("member_dob");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_first_name");
            searchOption.Add("member_last_name");
            searchOption.Add("member_ssn");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_dob");
            searchOption.Add("member_ssn");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_first_name");
            searchOption.Add("member_last_name");
            searchOption.Add("member_dob");
            searchOptions.Add(searchOption);

            searchOption = new Collection<string>();
            searchOption.Add("member_id");
            searchOption.Add("member_last_name");
            searchOption.Add("member_first_name");
            searchOption.Add("member_dob");
            searchOptions.Add(searchOption);
            #endregion

            return payerSearchOptions;
        }
    }
}
