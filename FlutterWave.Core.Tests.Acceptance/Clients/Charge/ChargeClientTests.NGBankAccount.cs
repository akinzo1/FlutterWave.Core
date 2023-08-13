



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
        public async Task ShouldPostNGBankAccountsAsync()
        {

            // given
            NGBankAccounts randomNGBankAccounts = CreateRandomNGBankAccountsResult();
            NGBankAccounts inputNGBankAccounts = randomNGBankAccounts;

            ExternalNGBankAccountsRequest NGBankAccountsRequest =
                ConvertToChargeRequest(inputNGBankAccounts);

            ExternalNGBankAccountsResponse NGBankAccountsResponse =
                            CreateRandomExternalNGBankAccountsResponseResult();

            NGBankAccounts expectedNGBankAccounts = inputNGBankAccounts.DeepClone();
            expectedNGBankAccounts = ConvertToChargeResponse(expectedNGBankAccounts, NGBankAccountsResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mono")
                    .WithBody(JsonConvert.SerializeObject(
                        NGBankAccountsRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(NGBankAccountsResponse));

            // when
            NGBankAccounts actualResult =
                await this.flutterWaveClient.Charge.ChargeNGBankAccountAsync(inputNGBankAccounts);

            // then
            actualResult.Should().BeEquivalentTo(expectedNGBankAccounts);
        }
    }
}
