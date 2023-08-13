



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
        public async Task ShouldBlockUnblockVirtualCardAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputVirtualCardId = randomId;

            string randomString2 = GetRandomString();
            string randomId2 = randomString2;
            string inputStatusAction = randomId2;

            ExternalBlockUnblockVirtualCardResponse randomExternalBlockUnblockVirtualCardResponse =
                CreateRandomExternalBlockUnblockVirtualCardResponseResult();

            ExternalBlockUnblockVirtualCardResponse retrievedVirtualCardsResult =
                randomExternalBlockUnblockVirtualCardResponse;

            BlockUnblockVirtualCard expectedBlockUnblockVirtualCardResponse =
               ConvertToVirtualCardResponse(retrievedVirtualCardsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPut()
                    .WithPath($"/v3/virtual-cards/{inputVirtualCardId}/status/{inputStatusAction}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVirtualCardsResult));

            // when
            BlockUnblockVirtualCard actualResult =
                await this.flutterWaveClient.VirtualCards.PostBlockUnblockVirtualCardAsync(inputVirtualCardId, inputStatusAction);

            // then
            actualResult.Should().BeEquivalentTo(expectedBlockUnblockVirtualCardResponse);
        }
    }
}
