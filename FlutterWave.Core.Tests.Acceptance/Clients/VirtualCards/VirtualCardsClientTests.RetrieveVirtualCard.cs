



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
        public async Task ShouldRetrieveVirtualCardAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputVirtualCardId = randomId;

            ExternalFetchVirtualCardResponse randomExternalFetchVirtualCardResponse =
                CreateRandomExternalFetchVirtualCardResponseResult();

            ExternalFetchVirtualCardResponse retrievedVirtualCardsResult =
                randomExternalFetchVirtualCardResponse;

            FetchVirtualCard expectedFetchVirtualCardResponse =
               ConvertToVirtualCardResponse(retrievedVirtualCardsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/virtual-cards/{inputVirtualCardId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVirtualCardsResult));

            // when
            FetchVirtualCard actualResult =
                await this.flutterWaveClient.VirtualCards.RetrieveVirtualCardAsync(inputVirtualCardId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchVirtualCardResponse);
        }
    }
}
