



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.MiscellaneousClient
{
    public partial class MiscellaneousClientTests
    {
        [Fact]
        public async Task ShouldPostBankAccountVerificationAsync()
        {

            // given
            BankAccountVerification randomBankAccountVerification = CreateRandomBankAccountVerification();
            BankAccountVerification inputBankAccountVerification = randomBankAccountVerification;

            ExternalBankAccountVerificationRequest BankAccountVerificationRequest =
                ConvertToBankAccountVerificationRequest(inputBankAccountVerification);

            ExternalBankAccountVerificationResponse BankAccountVerificationResponse =
                            CreateExternalBankAccountVerificationResponseResult();

            BankAccountVerification expectedBankAccountVerification = inputBankAccountVerification.DeepClone();
            expectedBankAccountVerification = ConvertToMiscellaneousResponse(expectedBankAccountVerification, BankAccountVerificationResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/accounts/resolve")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        BankAccountVerificationRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(BankAccountVerificationResponse));

            // when
            BankAccountVerification actualResult =
                await this.flutterWaveClient.Miscellaneous.BankAccountVerificationAsync(inputBankAccountVerification);

            // then
            actualResult.Should().BeEquivalentTo(expectedBankAccountVerification);
        }
    }
}
