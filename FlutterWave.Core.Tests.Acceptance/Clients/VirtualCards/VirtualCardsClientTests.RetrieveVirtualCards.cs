



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualCardsClient
{
    public partial class VirtualCardsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualCardsAsync()
        {
            // given


            ExternalFetchVirtualCardsResponse randomExternalFetchVirtualCardsResponse =
                CreateRandomExternalFetchVirtualCardsResponseResult();

            ExternalFetchVirtualCardsResponse retrievedVirtualCardsResult =
                randomExternalFetchVirtualCardsResponse;

            FetchVirtualCards expectedFetchVirtualCardsResponse =
               ConvertToVirtualCardResponse(retrievedVirtualCardsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/virtual-cards")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVirtualCardsResult));

            // when
            FetchVirtualCards actualResult =
                await this.flutterWaveClient.VirtualCards.RetrieveVirtualCardsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchVirtualCardsResponse);
        }
    }
}
