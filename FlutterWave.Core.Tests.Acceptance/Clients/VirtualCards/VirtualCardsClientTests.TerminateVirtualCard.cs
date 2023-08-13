



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
        public async Task ShouldTerminateVirtualCardAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputVirtualCardId = randomId;

            ExternalTerminateVirtualCardResponse randomExternalTerminateVirtualCardResponse =
                CreateRandomExternalTerminateVirtualCardResponseResult();

            ExternalTerminateVirtualCardResponse retrievedVirtualCardsResult =
                randomExternalTerminateVirtualCardResponse;

            TerminateVirtualCard expectedTerminateVirtualCardResponse =
               ConvertToVirtualCardResponse(retrievedVirtualCardsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPut()
                    .WithPath($"/v3/virtual-cards/{inputVirtualCardId}/terminate")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVirtualCardsResult));

            // when
            TerminateVirtualCard actualResult =
                await this.flutterWaveClient.VirtualCards.TerminateVirtualCardAsync(inputVirtualCardId);

            // then
            actualResult.Should().BeEquivalentTo(expectedTerminateVirtualCardResponse);
        }
    }
}
