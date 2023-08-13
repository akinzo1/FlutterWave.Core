



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeClient
{
    public partial class ChargeClientTests
    {
        [Fact]
        public async Task ShouldPostUkEuBankAccountsAsync()
        {

            // given
            UkEuBankAccounts randomUkEuBankAccounts = CreateRandomUkEuBankAccountsResult();
            UkEuBankAccounts inputUkEuBankAccounts = randomUkEuBankAccounts;

            ExternalUkEuBankAccountsRequest UkEuBankAccountsRequest =
                ConvertToChargeRequest(inputUkEuBankAccounts);

            ExternalUkEuBankAccountsResponse UkEuBankAccountsResponse =
                            CreateRandomExternalUkEuBankAccountsResponseResult();

            UkEuBankAccounts expectedUkEuBankAccounts = inputUkEuBankAccounts.DeepClone();
            expectedUkEuBankAccounts = ConvertToChargeResponse(expectedUkEuBankAccounts, UkEuBankAccountsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "account-ach-uk")
                    .WithBody(JsonConvert.SerializeObject(
                        UkEuBankAccountsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UkEuBankAccountsResponse));

            // when
            UkEuBankAccounts actualResult =
                await this.flutterWaveClient.Charge.ChargeUkEuBankAccountsAsync(inputUkEuBankAccounts);

            // then
            actualResult.Should().BeEquivalentTo(expectedUkEuBankAccounts);
        }
    }
}
