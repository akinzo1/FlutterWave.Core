



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSettlements;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.SettlementsClient
{
    public partial class SettlementsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveSettlementByIdAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomBin = randomString;
            string inputSettlementId = randomBin;

            ExternalSettlementResponse randomExternalSettlementResponse =
                CreateExternalSettlementResponseResult();

            ExternalSettlementResponse retrieveSettlementResult =
                randomExternalSettlementResponse;

            Settlement expectedBanksResponse =
                ConvertToSettlementResponse(retrieveSettlementResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/settlements/{inputSettlementId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrieveSettlementResult));

            // when
            Settlement actualResult =
                await this.flutterWaveClient.Settlements.FetchSettlementByIdAsync(inputSettlementId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
