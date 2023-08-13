



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalBalance;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.MiscellaneousClient
{
    public partial class MiscellaneousClientTests
    {
        [Fact]
        public async Task ShouldRetrieveMiscellaneousByReferenceAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCurrrency = randomString;
            string inputCurrency = randomCurrrency;

            ExternalBalanceByCurrencyResponse randomExternalBalanceByCurrencyResponse =
                CreateExternalBalanceByCurrencyResponseResult();

            ExternalBalanceByCurrencyResponse retrievedBalanceByCurrencyResult =
                randomExternalBalanceByCurrencyResponse;

            BalanceByCurrency expectedBanksResponse =
                ConvertToMiscellaneousResponse(retrievedBalanceByCurrencyResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/balances/{inputCurrency}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBalanceByCurrencyResult));

            // when
            BalanceByCurrency actualResult =
                await this.flutterWaveClient.Miscellaneous.BalanceByCurrencyAsync(inputCurrency);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
