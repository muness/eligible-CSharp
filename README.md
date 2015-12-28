#Eligible.NET
C# Library for Eligible APIs
### Description
EligibleNET  for .NET provides simple access to Eligible APIs.

#### Requirements
* [.NET Framework 4.5](http://www.microsoft.com/en-us/download/details.aspx?id=30653)

#### NuGet Packages
Eligible.NET library is available on nuget. Use the below command to get it from Nuget PackageManagerConsole.

	Install-Package Eligible.Net
	
### Documentation
Refer to https://eligible.com/rest for full documentation on Eligible APIs, their request parameters
and expected response formats.
	
### Configure
You can request an account at https://eligible.com/request-access

Please include below namespace to make calls to the Eligible Api. 
```cs
using EligibleService.Core; // For Query
using EligibleService.Model; //For Response
```
Below lines of code stores your ApiKey, TestMode and ApiVersion once and use it in entire application. 
```cs
Eligible eligible = Eligible.Instance;
eligible.ApiKey = "Api Key";
eligible.ApiVersion = "v1.5";
eligible.IsTest = true;
```
	(OR)
create RequestOptions object and pass it to every request
```cs
RequestOptions requestOptions = new RequestOptions();
requestOptions.ApiKey = "Api Key";
requestOptions.ApiVersion = "v1.5";
requestOptions.IsTest = true;

ClaimResponse response = claim.Create(input, requestOptions); // requestOptions is optional parameter
```
We have not mentioned all the parameters required to pass along with Api calls here. Please check our [website](https://eligible.com/rest) for complete parameters.

#### Sample Usage
```cs
using Eligible.Core;
using System;

class Program
{
	static void Main(string[] args)
	{
		Eligible eligible = Eligible.Instance;
		eligible.ApiKey = "Api Key";
		eligible.ApiVersion = "v1.5";
		eligible.IsTest = false;

		Payers payers = new Payers();
		PayersResponse payersResponse = payers.All();
		/* 
		RequestOptions requestOptions = new RequestOptions();
		requestOptions.ApiKey = "Some other Api key"
		requestOptions.IsTest = true;
		PayersResponse payersResponse = payers.All(requestOptions); // requesoptions for specific request
		*/
		foreach(Eligible.Model.PayerResponse payer in payersResponse.Payers)
		{
			foreach(string PayerName in payer.Names)
			{
				Console.WriteLine(PayerName);
			}
			Console.WriteLine(payer.CreatedAt);
			Console.WriteLine(payer.PayerId);
		}
		
		//JsonResponse can get from the output of method call.
		Console.WriteLine(payersResponse.JsonResponse()); // will return json response
	}
}
```

###Testing
Add an Environmental Variable with name 'apikey' and save your api key to run the test cases.


## All EligibleApi Calls
### Payers
please refer https://eligible.com/rest#payers for Payers information
```cs
Payers payers = new Payers();
PayersResponse payersResponse = payers.All(); //List of all payers
PayersResponse payersResponse = payers.All("payment reports", true); // params => endpoint = "payment reports", enrollment_required = "true"

PayerResponse payerResponse = payers.GetById("10101"); // Get single payer with payer_id

PayersSearchOptionResponse payersSearchOptions = payers.SearchOptions(); 
payersSearchOptionResponse.SearchOptionsList; // Get all payers search options

PayerSearchOptionResponse payerSearchOptions = payers.SearchOptions("10101"); // Get SearchOptions for single payer

StatusResponse payersStatusses = payers.Statusses("276"); // 276 is transaction_type, default value is 270
StatusResponse payersStatusses = payers.GetPayersByStatus("available", "276"); //Get payers by their status(ex: unavailable, available...)

StatusResponse payerStatusses = payers.StatussesByPayer("00002", "276"); // Get single payer Statusses
```

### Claim
Use any of the below 3 ways to create a Claim.

###### 1. Create claim with Hash params
please refer https://eligible.com/rest#claims_and_reports for complete param information
```cs
Claim claim = new Claim();

Hashtable claimHashParams = new Hashtable();
claimHashParams.Add("billing_provider", billingProvider);
claimHashParams.Add("payer", payer);
claimHashParams.Add("subscriber", suscriber);
claimHashParams.Add("dependent", dependent);
claimHashParams.Add("claim", claimm);

ClaimResponse claimResponse = claim.Create(claimHashParams);
if (claimResponse.Success)
	Console.WriteLine("Claim submitted successfully");

```
###### 2.Create claim with our ClaimParams Class.Include using Eligible.Model.Claim;to get this work

```cs
ClaimParams claimParamsObj = new ClaimParams();
claimParamsObj.ScrubEligibility = false;
claimParamsObj.BillingProvider = bp;
claimParamsObj.Payer = new Payer()
{
    Id = "60054",
    Name = "Aetna",
    Address = new Eligible.Model.Address()
	{
		.	.	.
		.	.	.
}
ClaimResponse claimResponse = claim.Create(claimParamsObj)

```
###### 3. Create claim with json ######
```cs 
ClaimResponse claimResponse = claim.Create("{"scrub_eligibility": "false", "billing_provider": {    "tax_id": "123456789",    "tax_id_type": "EI",    "entity": "false",...})
```
##### Other methods in Claim
```cs
// Acknowledgements
ClaimAcknowledgementsResponse claimAcknowledgements = claim.GetClaimAcknowledgements("referenceId"); // Params => 01001100 is reference_id.

MultipleAcknowledgementsResponse multipleClaimAcknowledgements = claim.GetClaimAcknowledgements(claimAckHashParams); // params => claimAckParam is a Hash of params. Check our document for list of params.

// Claim payment reports
ClaimPaymentReportResponse claimPaymentReport = claim.GetClaimPaymentReport("referenceId"); Params => BDA85HY09IJ is reference_id

ClaimPaymentReportResponse specificClaimPaymentReport = claim.GetClaimPaymentReport("BDA85HY09IJ", "ABX45DGER44"); // Params => BDA85HY09IJ is reference_id and ABX45DGER44 is Id. 

ClaimPaymentReportsResponse multipleClaimPaymentReports = claim.GetClaimPaymentReport();
```

### Coverage
please refer https://eligible.com/rest#coverage for full param information
```cs 
Coverage coverage = new Coverage();
Hashtable coverageParams = new Hashtable();
coverageParams.Add("payer_id", "00030");
coverageParams.Add("provider_first_name", "John");
coverageParams.Add("provider_npi", "0123456789");
coverageParams.Add("member_id", "ZZZ12345556666");
// some params skipped. 

CoverageResponse coverageResponse = coverage.All(coverageHashParams); 
```
### Medicare
please refer https://eligible.com/rest#retrieve-medicare for Medicare params information
```cs
Coverage coverage = new Coverage();

MedicareResponse medicare = coverage.Medicare(medicareHashParams);
```

### Customer 
please refer https://eligible.com/rest#customers for customer params information
```cs
Customer customer = new Customer();
```
```cs
// Create customer
CustomerResponse response = customer.Create("ABC", "ABC site"); // params => ABC is company_name, ABc site is company_site
CustomerResponse response = customer.Create("{customer: { 'name': 'XYZ company', 'site_name': 'XYZ site name' } }"); // create customer with json
CustomerResponse response = customer.Create(customerHashParams);
CustomerResponse response = customer.Create(customerParams); // customerParams is an object of CustomerParams. Usage is similar to Claim creation using ClaimParams.

// Update customer
CustomerResponse response = customer.Update("customerId", "ABC", "ABC site"); // params => ABC is company_name, ABc site is company_site
CustomerResponse response = customer.Update("customerId", "{customer: { 'name': 'XYZ company', 'site_name': 'XYZ site name' } }"); // create customer with json
CustomerResponse response = customer.Update("customerId", customerHashParams);
CustomerResponse response = customer.Update("customerId", customerParams); // customerParams is an object of CustomerParams. Usage is similar to Claim creation using ClaimParams.

// Retrieve Customer
CustomerResponse response = customer.GetByCustomerId("customerId");

CustomersResponse customers = customer.GetAll(); //List of all customers. 
CustomersResponse customers = customer.GetAll("3");  // parameter "3" is page number and it is optional
```

### Cost Estimates 
please refer https://eligible.com/rest#cost-estimates for CostEstimates params information
```cs
CostEstimates costEstimates = new CostEstimates();

CostEstimatesResponse costEstimatesResponse = costEstimates.Get(costEstimatesHashParams); 
```

### Payment Status 
please refer https://eligible.com/rest#payment-status for Payment Status params information
```cs
PaymentStatus paymentStatus = new PaymentStatus();

PayementStatusResponse paymentStatus = paymentStatus.Get(paymentStatusHashParams);
```

### Enrollments
please refer https://eligible.com/rest#enrollments for Enrollments params information
```cs
Enrollment enrollment = new Enrollment();
```
```cs
//Create Enrollment
EnrollmentNpisResponse enrollmentResponse = enrollment.Create(enrollmentHashParams);
EnrollmentNpisResponse enrollmentResponse = enrollment.Create(enrollmentParams); // Use EnrollmentParams class to send required params
EnrollmentNpisResponse enrollmentResponse = enrollment.Create(jsonParams); // Build params in json form.

//Update Enrollment
EnrollmentNpisResponse enrollmentResponse = enrollment.Update("enrollment_npi_id", enrollmentHashParams);
EnrollmentNpisResponse enrollmentResponse = enrollment.Update("enrollment_npi_id", enrollmentParams);
EnrollmentNpisResponse enrollmentResponse = enrollment.Update("enrollment_npi_id", jsonParams);

//Retrieve Enrollment
EnrollmentNpisResponse enrollmentResponse = enrollment.GetByEnrollmentNpiId("enrollment_npi_id");


EnrollmentNpisResponses enrollments = enrollment.GetAll();

//Received PDF
ReceivedPdfResponse recievedPdf = enrollment.GetReceivedPdf("enrollment_npi_id");

string response = enrollment.DownloadReceivedPdf("enrollment_npi_id", "location to download the pdf(ex: C:\\pdfs\\");

//Original Signature PDF
OriginalSignaturePdfResponse response = enrollment.CreateOriginalSignaturePdf("enrollment_npi_id", "signature pdf to upload. ex : C:\\PDF\\received_pdf_123.pdf");
OriginalSignaturePdfResponse response = enrollment.UpdateOriginalSignaturePdf("enrollment_npi_id", "Updated signature pdf path to upload. ex : C:\\PDF\\received_pdf_123.pdf");
OriginalSignaturePdfResponse response = enrollment.GetOriginalSignaturePdf("123");

OriginalSignaturePdfDeleteResponse deleteSignaturePdf = enrollment.DeleteOriginalSignaturePdf("123");

string response = enrollment.DownloadOriginalSignaturePdf("enrollment_npi_id", "location to download the pdf(ex: C:\\pdfs\\");

```

### Precertification 
please refer https://eligible.com/rest#precert for Precertification params information
```cs
Precertification precertification = new Precertification();
PrecertificationInquiryResponse preCertifications = precertification.Inquiry(hashParams);
```

###Exception Handling###
Namespace to Include: Eligible.Exceptions

	1) AuthenticationException
	2) InvalidRequestException
	3) EligibleException
	
```cs	
try
{
	var payers = Coverage.Medicare(param);
}
catch(Eligible.Exceptions.EligibleException ex)
{
	var erro = ex.EligibleError;
}
catch(Eligible.Exceptions.AuthenticationException ex)
{
	var erro = ex.Message;
}
catch(Eligible.Exceptions.InvalidRequestException ex)
{
	var erro = ex.Message;
}
```