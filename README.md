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
	[Sample code](#Samplecode)
	
- Create a RequestOptions object and pass it to every request
	```cs
	RequestOptions requestOptions = new RequestOptions();
	requestOptions.ApiKey = "Api Key";
	requestOptions.IsTest = true;
	```
	[RequestOptionsExample](#RequestOptionsExample)
	
#### Samplecode
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
#### RequestOptionsExample
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
[Payers](#Payers)
  * [Retrieve all payers](#Retrieve-all-payers)
  * [Retrieve single payer](#Retrieve-single-payer)
  * [Retrieve all payers search options](#Retrieve-all-payers-search-options)
  * [Retrieve payers statuses](#Retrieve-payers-statuses)
  * [Retrieve specific statuses](#Retrieve-specific-statuses)
  * [Retrieve payer statuses](#Retrieve-payer-statuses)
#### Retrieve all payers
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
#### Retrieve single payer
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
#### Retrieve all payers search options
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

#### Retrieve all payers search options
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
#### Retrieve single payer search options
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
#### Retrieve payers statuses 
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

#### Retrieve specific statuses
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

#### Retrieve payer statuses
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