



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
        public async Task ShouldRetrieveVirtualCardTransactionsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputVirtualCardId = randomId;

            ExternalVirtualCardTransactionsResponse randomExternalVirtualCardTransactionsResponse =
                CreateRandomExternalVirtualCardTransactionsResponseResult();

            ExternalVirtualCardTransactionsResponse retrievedVirtualCardsResult =
                randomExternalVirtualCardTransactionsResponse;

            VirtualCardTransactions expectedVirtualCardTransactionsResponse =
               ConvertToVirtualCardResponse(retrievedVirtualCardsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/virtual-cards/{inputVirtualCardId}/transactions")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVirtualCardsResult));

            // when
            VirtualCardTransactions actualResult =
                await this.flutterWaveClient.VirtualCards.GetVirtualCardTransactionsAsync(inputVirtualCardId);

            // then
            actualResult.Should().BeEquivalentTo(expectedVirtualCardTransactionsResponse);
        }
    }
}
