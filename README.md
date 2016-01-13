Eligible.NET
===================
C# bindings for Eligible APIs (https://eligible.com). 

#### Documentation
Eligible is built for developers needing HIPAA compliant connectivity to health insurance companies.
> **Important:** You can request an account at https://eligible.com/request-access

Refer to https://eligible.com/rest for full documentation on Eligible APIs, their request parameters and expected response formats.

#### Requirements
* [.NET Framework 4.5](http://www.microsoft.com/en-us/download/details.aspx?id=30653)

### NuGet Packages
Eligible.NET library is available on NuGet. Use the below command to get it from NuGet PackageManagerConsole.

	Install-Package Eligible.NET

### Usage
Please include the below namespaces to make calls to the Eligible API. 
```cs
using EligibleService.Core; // For Query
using EligibleService.Model; //For Response
```
-  Set ApiKey and TestMode using Eligible class - global setting
	```cs
	Eligible eligible = Eligible.Instance;
	eligible.ApiKey = "Api Key";
	eligible.IsTest = true;
	```
	[Sample code](#sample-code)
	
- Create a RequestOptions object and pass it to every request
	```cs
	RequestOptions requestOptions = new RequestOptions();
	requestOptions.ApiKey = "Api Key";
	requestOptions.IsTest = true;
	```
	[RequestOptionsExample](#request-options-example)
	
#### Sample code
```cs
using EligibleService.Core;
using EligibleService.Model;
using System;

class Program
{
    static void Main(string[] args)
    {
        Eligible eligible = Eligible.Instance;
        eligible.ApiKey = "API Key";
        eligible.IsTest = false;

        Payers payers = new Payers();
        PayersResponse payersResponse = payers.All();

        foreach (PayerResponse payer in payersResponse.Payers)
        {
            foreach (string PayerName in payer.Names)
            {
                Console.WriteLine(PayerName);
            }
            Console.WriteLine(payer.CreatedAt);
            Console.WriteLine(payer.PayerId);
        }
        
        Console.WriteLine(payersResponse.JsonResponse()); // will return json response
    }
}
```
#### Request Options Example
```cs
using EligibleService.Core;
using System;

class Program
{
    static void Main(string[] args)
    {
        RequestOptions requestOptions = new RequestOptions();
        requestOptions.ApiKey = "API Key";
        requestOptions.IsTest = true;

        Payers payers = new Payers();
        var payerResponse = payers.GetById("payer_id", requestOptions);

        Console.WriteLine(payerResponse.JsonResponse());
    }
}
```
* [Payers](#payers)
	* [Retrieve all payers](#retrieve-all-payers)
	* [Retrieve single payer](#retrieve-single-payer)
	* [Retrieve all payers search options](#retrieve-all-payers-search-options)
	* [Retrieve payers statuses](#retrieve-payers-statuses)
	* [Retrieve specific statuses](#retrieve-specific-statuses)
	* [Retrieve payer statuses](#retrieve-payer-statuses)
* [Claim](#claim)
 * [Submit claim](#claim)
	* [Hash params](#submit-with-hash-params)
	* [ClaimParams Class Object](#submit-with-claimparams-class-object)
	* [JSON input](#submit-with-json)
 * [Retrieve Claim Acknowledgements](#claim-acknowledgements) 
	*  [Acknowledgements with ReferenceID](#claim-acknowledgements)
	*  [Multiple Acknowledgements](#multiple-acknowledgements)
 * [Payment Reports](#payment-reports)
	* [Single Payment Report](#retrieve-single-claim-payment-report)
	* [Specific Payment Report](#retrieve-specific-claim-payment-report)
	* [Multiple Payment Report](#retrieve-multiple-claim-payment-report)
* [Coverage](#coverage)
* [Medicare](#medicare)

	
## Payers 
### Retrieve all payers
```cs
Payers payers = new Payers();

PayersResponse payersResponse = payers.All();
PayersResponse payersResponse = payers.All("payment reports",  "true");
```
Retrieve payers with RequestOptions
```cs
var payersResponse = payers.All("payment reports",  "true", requestOptionsObj);
```
Json Response
```cs
string jsonResponse = payersResponse.JsonResponse();
```
### Retrieve single payer
```cs
Payers payers = new Payers();

PayerResponse payerResponse = payers.GetById("payer_id");
```
Retrieve payers with RequestOptions
```cs
var payerResponse = payers.GetById("62308", requestOptionsObj);
```
Json Response
```cs
string jsonResponse = payerResponse.JsonResponse();
```
### Retrieve all payers search options
```cs
Payers payers = new Payers();

PayersSearchOptionResponse payersSearchOptions = payers.SearchOptions();
```
Retrieve payers with RequestOptions
```cs
var payersSearchOptions = payers.SearchOptions(requestOptionsObj);

```
Json Response
```cs
string jsonResponse = payersSearchOptions.JsonResponse();
```

### Retrieve all payers search options
```cs
Payers payers = new Payers();

PayersSearchOptionResponse payersSearchOptions = payers.SearchOptions();
```
Retrieve payers with RequestOptions
```cs
var payersSearchOptions = payers.SearchOptions(requestOptionsObj);

```
Json Response
```cs
string jsonResponse = payersSearchOptions.JsonResponse();
```
### Retrieve single payer search options
```cs
Payers payers = new Payers();

PayerSearchOptionResponse payerSearchOptions = payers.SearchOptions("payer_id");
```
Retrieve payers with RequestOptions
```cs
var payerSearchOptions = payers.SearchOptions("payer_id", requestOptionsObj);

```
Json Response
```cs
string jsonResponse = payerSearchOptions.JsonResponse();
```
### Retrieve payers statuses 
```cs
Payers payers = new Payers();

StatusResponse payersStatusses = payers.Statusses("276"); // 276 is transaction_type and it is optional param
```
Retrieve payers with RequestOptions
```cs
var payersStatusses = payers.Statusses("276", requestOptionsObj);

```
Json Response
```cs
string jsonResponse = payersStatusses.JsonResponse()
```

### Retrieve specific statuses
```cs
Payers payers = new Payers();

StatusResponse payersStatusses = payers.GetPayersByStatus("available", "276");
```
Retrieve payers with RequestOptions
```cs
var payersStatusses = payers.GetPayersByStatus("available", "276", requestOptionsObj);

```
Json Response
```cs
string jsonResponse = payersStatusses.JsonResponse()
```

### Retrieve payer statuses
```cs
Payers payers = new Payers();

StatusResponse payerStatusses = payers.StatussesByPayer("payer_id", "276");
```
Retrieve payers with RequestOptions
```cs
var payerStatusses = payers.StatussesByPayer("payer_id", "276", requestOptionsObj);

```
Json Response
```cs
string jsonResponse = payerStatusses.JsonResponse()
```
## Claim

### Submit with hash params
```cs
Claim claim = new Claim();

Hashtable claimHashParams = new Hashtable();
claimHashParams.Add("billing_provider", billingProviderHash);
claimHashParams.Add("payer", payer);
claimHashParams.Add("subscriber", suscriberHash);
claimHashParams.Add("dependent", dependentHash);
claimHashParams.Add("claim", claimmDetailsHash);

ClaimResponse claimResponse = claim.Create(claimHashParams);
```
Submit claim with RequestOptions
```cs
var claimResponse = claim.Create(claimHashParams, requestOptionsObj);
```
Json Response
```cs
string jsonResponse = claimResponse.JsonResponse();
```

### Submit with ClaimParams Class Object
```cs
Claim claim = new Claim();

ClaimParams claimParamsObj = new ClaimParams();
claimParamsObj.ScrubEligibility = false;
claimParamsObj.BillingProvider = bp;
claimParamsObj.Payer = new Payer()
{
    Id = "60054",
    Name = "Aetna",
    Address = new Eligible.Model.Address(){}
	// checkout our rest doc or ClaimParams model for complete params list
	
}
ClaimResponse claimResponse = claim.Create(claimParamsObj)
```
Submit claim with RequestOptions
```cs
var claimResponse = claim.Create(claimParamsObj, requestOptionsObj);
```
Json Response
```cs
string jsonResponse = claimResponse.JsonResponse();

```

### Submit with JSON
```cs
Claim claim = new Claim();

ClaimResponse claimResponse = claim.Create("{"scrub_eligibility": "false", "billing_provider": {    "tax_id": "123456789",    "tax_id_type": "EI",    "entity": "false",...})
```
Submit claim with RequestOptions
```cs
var claimResponse = claim.Create(jsonInput, requestOptionsObj);
```
Json Response
```cs
string jsonResponse = claimResponse.JsonResponse();
```

### Claim Acknowledgements
```cs
Claim claim = new Claim();

ClaimAcknowledgementsResponse claimAcknowledgements = claim.GetClaimAcknowledgements("referenceId"); 
```
Retrieve Acknowledgements with  with RequestOptions
```cs
var claimAcknowledgements = claim.GetClaimAcknowledgements("referenceId", requestOptionsObj); 
```
Json Response
```cs
string jsonResponse = claimAcknowledgements.JsonResponse();
```

### Multiple Acknowledgements
```cs
Claim claim = new Claim();

Hashtable claimAckHashParams = new Hashtable();
            claimAckHashParams.Add("internal_id", "12345");
            claimAckHashParams.Add("submission_status", "accepted");
            claimAckHashParams.Add("claim_submitted_date", "2014-02-15");
            
MultipleAcknowledgementsResponse multipleClaimAcknowledgements = claim.GetClaimAcknowledgements(claimAckHashParams);
```
Retrieve Acknowledgements with  with RequestOptions
```cs
var multipleClaimAcknowledgements = claim.GetClaimAcknowledgements(claimAckHashParams, requestOptionsObj);
```
Json Response
```cs
string jsonResponse = multipleClaimAcknowledgements.JsonResponse();
```

### Payment Reports
### Retrieve Single Claim Payment Report
```cs
Claim claim = new Claim();

ClaimPaymentReportResponse claimPaymentReport = claim.GetClaimPaymentReport("referenceId");
```
Payment Reports with RequestOptions
```cs
var claimPaymentReport = claim.GetClaimPaymentReport("referenceId", requestOptionsObj);
```
Json Response
```cs
string jsonResponse = claimPaymentReport.JsonResponse();
```

### Retrieve Specific Claim Payment Report
```cs
Claim claim = new Claim();

ClaimPaymentReportResponse specificClaimPaymentReport = claim.GetClaimPaymentReport("BDA85HY09IJ", "ABX45DGER44");
```
Payment Reports with RequestOptions
```cs
var specificClaimPaymentReport = claim.GetClaimPaymentReport("BDA85HY09IJ", "ABX45DGER44", requestOptionsObj);
```
Json Response
```cs
string jsonResponse = specificClaimPaymentReport.JsonResponse();
```

### Retrieve Multiple Claim Payment Report
```cs
Claim claim = new Claim();

ClaimPaymentReportsResponse multipleClaimPaymentReports = claim.GetClaimPaymentReport();
```
Payment Reports with RequestOptions
```cs
var multipleClaimPaymentReports = claim.GetClaimPaymentReport(requestOptionsObj);
```
Json Response
```cs
string jsonResponse = multipleClaimPaymentReports.JsonResponse();
```

## Coverage
```cs
Coverage coverage = new Coverage();

Hashtable coverageHashParams = new Hashtable();
coverageHashParams.Add("payer_id", "00001");
coverageHashParams.Add("provider_last_name", "Doe");
coverageHashParams.Add("provider_first_name", "John");
coverageHashParams.Add("provider_npi", "0123456789");
coverageHashParams.Add("member_id", "AETNAS8398");
coverageHashParams.Add("member_first_name", "IDA");
coverageHashParams.Add("member_last_name", "FRANKLIN");
coverageHashParams.Add("member_dob", "1701-12-12");
coverageHashParams.Add("service_type", "30");

CoverageResponse coverageResponse = coverage.All(coverageHashParams);
```
Coverage with RequestOptions
```cs
var coverageResponse = coverage.All(coverageHashParams, requestOptionsObj);
```
Json Response
```cs
string jsonResponse = coverageResponse.JsonResponse();
```

## Medicare 
```cs
Coverage coverage = new Coverage();

MedicareResponse medicareResponse = coverage.Medicare(medicareHashParams);
```
Medicare with RequestOptions
```cs
var medicareResponse = coverage.Medicare(medicareHashParams, requestOptionsObj);
```
Json Response
```cs
string jsonResponse = medicareResponse.JsonResponse();
```

