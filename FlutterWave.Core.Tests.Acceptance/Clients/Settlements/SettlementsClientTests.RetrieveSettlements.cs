



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
        public async Task ShouldRetrieveAllSettlementsAsync()
        {
            // given

            ExternalSettlementsResponse randomExternalSettlementsResponse =
                CreateExternalSettlementsResponseResult();

            ExternalSettlementsResponse retrievedSettlementsResult =
                randomExternalSettlementsResponse;

            AllSettlements expectedStatementResponse =
                ConvertToSettlementsResponse(retrievedSettlementsResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/settlements")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedSettlementsResult));

            // when
            AllSettlements actualResult =
                await this.flutterWaveClient.Settlements.RetrieveAllSettlementsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedStatementResponse);
        }
    }
}
