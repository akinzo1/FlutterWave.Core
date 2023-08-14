# FlutterWave.Core

![FlutterWave.Core](https://raw.githubusercontent.com/SlimAhmad/FlutterWave.Core/main/FlutterWave.Core/flutterwave.jpg)


[![.NET](https://github.com/hassanhabib/OpenAI.NET/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/OpenAI.NET/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Standard.AI.OpenAI?logo=nuget)](https://www.nuget.org/packages/Standard.AI.OpenAI)
![Nuget](https://img.shields.io/nuget/dt/Standard.AI.OpenAI?color=blue&label=Downloads)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)

## Introduction
FlutterWave.Core is a Standard-Compliant .NET library built on top of FlutterWave API RESTful endpoints to enable software engineers to develop FinTech solutions in .NET.

## This library implements the following section
Please review the following documents:
- [Charge](https://developer.flutterwave.com/reference/endpoints/charge)
- [Validate Charge](https://developer.flutterwave.com/reference/endpoints/validate-charge)
- [Tokenization](https://developer.flutterwave.com/reference/endpoints/tokenized-charge)
- [Preauthorization](https://developer.flutterwave.com/reference/endpoints/preauthorization)
- [Transactions](https://developer.flutterwave.com/reference/endpoints/transactions)
- [Transfers](https://developer.flutterwave.com/reference/endpoints/transfers)
- [Virtual Cards](https://developer.flutterwave.com/reference/endpoints/virtual-cards)
- [Virtual Accounts](https://developer.flutterwave.com/reference/endpoints/virtual-account-numbers)
- [Collection Subaccounts](https://developer.flutterwave.com/reference/endpoints/collection-subaccount)
- [Payout Subaacounts](https://developer.flutterwave.com/reference/endpoints/payout-subaccounts)
- [Subscriptions](https://developer.flutterwave.com/reference/endpoints/subscriptions)
- [Payment Plans](https://developer.flutterwave.com/reference/endpoints/payment-plans)
- [Bill Payments](https://developer.flutterwave.com/reference/endpoints/bills)
- [Banks](https://developer.flutterwave.com/reference/endpoints/banks)
- [Settlements](https://developer.flutterwave.com/reference/endpoints/settlements)
- [OTP](https://developer.flutterwave.com/reference/endpoints/otp)
- [Charge Backs](https://developer.flutterwave.com/reference/endpoints/charge-backs)
- [Misc](https://developer.flutterwave.com/reference/endpoints/misc)

## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.

This library is also a community effort which involved many nights of pair-programming, test-driven development and in-depth exploration research and design discussions.

## How to use this library?
In order to use this library there are prerequisites that you must complete before you can write your first C#.NET program. These steps are as follows:

### FlutterWave Account
You must create an flutterWave account with the following link:
[Click here](https://dashboard.flutterwave.com/login)

### Nuget Package 
Install the FlutterWave.Core library in your project.
Use the method best suited for your development preference listed at the Nuget Link above or below.

[![Nuget](https://img.shields.io/nuget/v/Standard.AI.OpenAI?logo=nuget)](https://www.nuget.org/packages/Standard.AI.OpenAI)

### API Keys
Once you've created a FlutterWave account. Now, go ahead and get an API key from the following link:
[Click here](https://app.flutterwave.com/dashboard/settings/apis/live)

### Hello, World!
Once you've completed the aforementioned steps, let's write our very first program with Standard.AI.OpenAI as follows:

### Completions
The following example demonstrate how you can write your first direct card charge program.

PCI Compliance is required for direct charge.
[Check documentation](https://developer.flutterwave.com/docs/direct-charge/card/)

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using FlutterWave.Core;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace ExampleFlutterWaveNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);

            // given
            var request = new CardCharge
            {
                Request = new CardChargeRequest
                {
                    CardNumber = "5531886652142950",
                    Cvv = "564",
                    ExpiryMonth = 09,
                    ExpiryYear = 32,
                    Currency = "NGN",
                    Amount = 100,
                    FullName = "Yolande Aglaé Colbert",
                    Email = "user@example.com",
                    TxRef = "MC-3243e",
                    RedirectUrl = "https://www,flutterwave.ng",
                    Authorization = new CardChargeRequest.AuthorizationData
                    {
                        Address = "3563 Huntertown Rd, Allison park, PA",
                        Pin = 3310,
                        City = "San Francisco",
                        Country = "US",
                        State = "California",
                        Mode = "pin",
                        ZipCode = "94105"

                    },
                    Preauthorize = true,
                    Meta = new CardChargeRequest.CardMeta
                    {
                        FlightId = "",
                        SideNote = ""
                    },
                    PaymentPlan = "",
                    DeviceFingerprint = "",
                    ClientIp = "127.0.0.1"

                }
            };

           

            // . when
            CardCharge responseFlutterWaveModels =
                await this.flutterWaveClient.Charge.ChargeCardAsync(
                request, Environment.GetEnvironmentVariable("EncryptionKey"));

          
        }
    }
}
```

### ACH Charge
The following implementation shows how to accept payments directly from customers in the US and South Africa. 

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using FlutterWave.Core;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace ExampleFlutterWaveNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);

           // given
            var request = new ACHPayments
            {
                Request = new ACHPaymentsRequest
                {
                    TxRef = "MC-1585230ew9v5050e8",
                    Amount = 100,
                    Currency = "USD",
                    Country = "US",
                    Email = "user@example.com",
                    PhoneNumber = "0902620185",
                    FullName = "Yolande Aglaé Colbert",
                    ClientIp = "154.123.220.1",
                    RedirectUrl = "https://www.flutterwave.com/us/",
                    DeviceFingerprint = "62wd23423rq324323qew1",

                    Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                    {
                        FlightID = "123949494DC",
                    },


                }
            };

            // . when
            ACHPayments responseFlutterWaveModels =
                await this.flutterWaveClient.Charge.ChargeACHPaymentsAsync(request);
        }
    }
}
```

### NGBank Account Charge
The following implementation shows how to initiate a direct bank charge.
#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using FlutterWave.Core;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace ExampleFlutterWaveNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var apiConfigurations = new ApiConfigurations
            {
                
                ApiKey = Environment.GetEnvironmentVariable("ApiKey"),

            };

            this.flutterWaveClient = new FlutterWaveClient(apiConfigurations);

            // given
            var request = new NGBankAccounts
            {
                Request = new NGBankAccountsRequest
                {
                    TxRef = "MC-1585230ew9v5050e8",
                    Amount = 100,
                    AccountBank = "044",
                    AccountNumber = "0690000032",
                    Currency = "NGN",
                    Email = "user@example.com",
                    PhoneNumber = "0902620185",
                    FullName = "Yolande Aglaé Colbert"
                }
            };

            // . when
            NGBankAccounts responseFlutterWaveModels =
                await this.flutterWaveClient.Charge.ChargeNGBankAccountAsync(request);
        }
    }
}
```


#### Exceptions

FlutterWave.Core may throw following exceptions:

| Exception Name | When it will be thrown |
| --- | --- |
| `BankClientValidationException` | This exception is thrown when a validation error occurs while using the bank client. For example, if required data is missing or invalid. |
| `BankClientDependencyException` | This exception is thrown when a dependency error occurs while using the bank client. For example, if a required dependency is unavailable or incompatible. |
| `BankClientServiceException` | This exception is thrown when a service error occurs while using the bank client. For example, if there is a problem with the server or any other service failure. |
| `BillPaymentsClientValidationException` | This exception is thrown when a validation error occurs while using the bill payments client. For example, if required data is missing or invalid. |
| `BillPaymentsClientDependencyException` | This exception is thrown when a dependency error occurs while using the bill payments client. For example, if a required dependency is unavailable or incompatible. |
| `BIllPaymentsClientDependencyException` | This exception is thrown when a service error occurs while using the bill payments client. For example, if there is a problem with the server or any other service failure. |


## How to Contribute
If you want to contribute to this project please review the following documents:
- [The Standard](https://github.com/hassanhabib/The-Standard)
- [C# Coding Standard](https://github.com/hassanhabib/CSharpCodingStandard)
- [The Team Standard](https://github.com/hassanhabib/The-Standard-Team)

If you have a question make sure you either open an issue or join our [Ahmad Salim](slimahmad6@gmail.com) discord server.

