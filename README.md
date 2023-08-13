# FlutterWave.Core

![FlutterWave.Core](https://raw.githubusercontent.com//SlimAhmad/FlutterWave.Core/blob/main/FlutterWave.Core/flutterwavelogo.jpg)


[![.NET](https://github.com/hassanhabib/OpenAI.NET/actions/workflows/dotnet.yml/badge.svg)](https://github.com/hassanhabib/OpenAI.NET/actions/workflows/dotnet.yml)
[![Nuget](https://img.shields.io/nuget/v/Standard.AI.OpenAI?logo=nuget)](https://www.nuget.org/packages/Standard.AI.OpenAI)
![Nuget](https://img.shields.io/nuget/dt/Standard.AI.OpenAI?color=blue&label=Downloads)
[![The Standard - COMPLIANT](https://img.shields.io/badge/The_Standard-COMPLIANT-2ea44f)](https://github.com/hassanhabib/The-Standard)
[![The Standard Community](https://img.shields.io/discord/934130100008538142?color=%237289da&label=The%20Standard%20Community&logo=Discord)](https://discord.gg/vdPZ7hS52X)

## Introduction
FlutterWave.Core is a Standard-Compliant .NET library built on top of FlutterWave API RESTful endpoints to enable software engineers to develop FinTech solutions in .NET.

## The following endpoints 
Please review the following documents:
- [The Standard](https://github.com/hassanhabib/The-Standard)
- [C# Coding Standard](https://github.com/hassanhabib/CSharpCodingStandard)
- [The Team Standard](https://github.com/hassanhabib/The-Standard-Team)

## Standard-Compliance
This library was built according to The Standard. The library follows engineering principles, patterns and tooling as recommended by The Standard.

This library is also a community effort which involved many nights of pair-programming, test-driven development and in-depth exploration research and design discussions.

## How to use this library?
In order to use this library there are prerequisites that you must complete before you can write your first C#.NET program. These steps are as follows:

### FlutterWave Account
You must create an flutterWave account with the following link:
[Click here](https://flutterwave.com/signup)

### Nuget Package 
Install the FlutterWave.Core library in your project.
Use the method best suited for your development preference listed at the Nuget Link above or below.

[![Nuget](https://img.shields.io/nuget/v/Standard.AI.OpenAI?logo=nuget)](https://www.nuget.org/packages/Standard.AI.OpenAI)

### API Keys
Once you've created a FlutterWave account. Now, go ahead and get an API key from the following link:
[Click here](https://platform.openai.com/account/api-keys)

### Hello, World!
Once you've completed the aforementioned steps, let's write our very first program with Standard.AI.OpenAI as follows:

### Completions
The following example demonstrate how you can write your first direct card charge program.

PCI Compliance is required for direct charge.
[Check documentation](https://platform.openai.com/account/api-keys)

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
            CardCharge responseAIModels =
                await this.flutterWaveClient.Charge.ChargeCardAsync(
                request, Environment.GetEnvironmentVariable("EncryptionKey"));

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
```

### Chat Completions
The following example demonstrate how you can write your first Chat Completions program.

#### Program.cs
```csharp
using System;
using System.Threading.Tasks;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.ChatCompletions;

namespace ExampleOpenAIDotNet
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var openAIConfigurations = new OpenAIConfigurations
            {
                ApiKey = "YOUR_API_KEY_HERE",
                OrganizationId = "YOUR_OPTIONAL_ORG_ID_HERE"
            };

            var openAIClient = new OpenAIClient(openAIConfigurations);

            var chatCompletion = new ChatCompletion
            {
                Request = new ChatCompletionRequest
                {
                    Model = "gpt-3.5-turbo",
                    Messages = new ChatCompletionMessage[]
                    {
                        new ChatCompletionMessage
                        {
                            Content = "What is c#?",
                            Role = "user",
                        }
                    },
                }
            };

            ChatCompletion resultChatCompletion =
                await openAIClient.ChatCompletions.SendChatCompletionAsync(
                    chatCompletion);

            Array.ForEach(
                resultChatCompletion.Response.Choices,
                choice => Console.WriteLine(
                    value: $"{choice.Message.Role}: {choice.Message.Content}"));
        }
    }
}
```

### Fine-Tunes
The following example demonstrate how you can write your first Fine-tunes program.

#### Program.cs
```csharp
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Standard.AI.OpenAI.Clients.OpenAIs;
using Standard.AI.OpenAI.Models.Configurations;
using Standard.AI.OpenAI.Models.Services.Foundations.AIFiles;
using Standard.AI.OpenAI.Models.Services.Foundations.FineTunes;

namespace Examples.Standard.AI.OpenAI.Clients.FineTunes
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var openAIConfigurations = new OpenAIConfigurations
            {
                ApiKey = "YOUR_API_KEY_HERE",
                ApiUrl = "https://api.openai.com"
            };

            IOpenAIClient openAIClient =
                new OpenAIClient(openAIConfigurations);

            MemoryStream memoryStream = CreateRandomStream();

            var aiFile = new AIFile
            {
                Request = new AIFileRequest
                {
                    Name = "Test",
                    Content = memoryStream,
                    Purpose = "fine-tune"
                }
            };

            AIFile file = await openAIClient.AIFiles
                .UploadFileAsync(aiFile);

            var fineTune = new FineTune();
            fineTune.Request = new FineTuneRequest();

            fineTune.Request.FileId =
                file.Response.Id;

            FineTune fineTuneResult =
                await openAIClient.FineTuneClient
                    .SubmitFineTuneAsync(fineTune);

            Console.WriteLine(fineTuneResult);
        }

        private static MemoryStream CreateRandomStream()
        {
            string content = "{\"prompt\": \"<prompt text>\", \"completion\": \"<ideal generated text>\"}";

            return new MemoryStream(Encoding.UTF8.GetBytes(content));
        }
    }
}
```

#### Exceptions

Standard.AI.OpenAI may throw following exceptions:

| Exception Name | When it will be thrown |
| --- | --- |
| `ChatCompletionClientValidationException` | This exception is thrown when a validation error occurs while using the chat completion client. For example, if required data is missing or invalid. |
| `ChatCompletionClientDependencyException` | This exception is thrown when a dependency error occurs while using the chat completion client. For example, if a required dependency is unavailable or incompatible. |
| `ChatCompletionClientServiceException` | This exception is thrown when a service error occurs while using the chat completion client. For example, if there is a problem with the server or any other service failure. |
| `FineTuneClientValidationException` | This exception is thrown when a validation error occurs while using the fine-tunes client. For example, if required data is missing or invalid. |
| `FineTuneClientDependencyException` | This exception is thrown when a dependency error occurs while using the fine-tunes client. For example, if a required dependency is unavailable or incompatible. |
| `FineTuneClientDependencyException` | This exception is thrown when a service error occurs while using the fine-tunes client. For example, if there is a problem with the server or any other service failure. |


## How to Contribute
If you want to contribute to this project please review the following documents:
- [The Standard](https://github.com/hassanhabib/The-Standard)
- [C# Coding Standard](https://github.com/hassanhabib/CSharpCodingStandard)
- [The Team Standard](https://github.com/hassanhabib/The-Standard-Team)

If you have a question make sure you either open an issue or join our [The Standard Community](https://discord.com/invite/vdPZ7hS52X) discord server.

## Live-Sessions
Our live-sessions are scheduled on [The Standard Calendar](https://tinyurl.com/the-standard-calendar) make sure you adjust the time to your city/timezone to be able to join us.

We broadcast on multiple platforms:

[YouTube](https://www.youtube.com/@HassanHabib)

[LinkedIn](https://www.linkedin.com/in/hassanrezkhabib/)

[Twitch](https://www.twitch.tv/binhabib)

[Twitter](https://twitter.com/HassanRezkHabib)

[Facebook](https://www.facebook.com/hassan.rezk.habib)

### Past-Sessions
Here's our live sessions to show you how this library was developed from scratch:

[Standard.AI.OpenAI YouTube Playlist](https://www.youtube.com/watch?v=JQnTpGV-7YA&list=PLan3SCnsISTTl_MnGP6B78Nfu9Ix8G4mU)