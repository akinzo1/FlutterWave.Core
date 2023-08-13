



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
        public async Task ShouldRetrieveMscellaneoussByReferenceAsync()
        {
            // given


            ExternalAllBalanceCurrenciesResponse randomExternalAllBalanceCurrenciesResponse =
                CreateExternalAllBalanceCurrenciesResponseResult();

            ExternalAllBalanceCurrenciesResponse retrievedBalanceCurrenciesResult =
                randomExternalAllBalanceCurrenciesResponse;

            BalanceByCurrencies expectedBalanceCurrenciesResponse =
                ConvertToMiscellaneousResponse(retrievedBalanceCurrenciesResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/balances")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBalanceCurrenciesResult));

            // when
            BalanceByCurrencies actualResult =
                await this.flutterWaveClient.Miscellaneous.BalanceCurrenciesAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedBalanceCurrenciesResponse);
        }
    }
}
