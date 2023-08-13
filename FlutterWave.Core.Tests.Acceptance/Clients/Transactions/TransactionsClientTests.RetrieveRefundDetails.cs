



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TransactionsClient
{
    public partial class TransactionsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveRefundDetailsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomTransactionId = randomString;
            string inputTransactionId = randomTransactionId;

            ExternalFetchRefundDetailsResponse randomExternalFetchRefundDetailsResponse =
                CreateExternalFetchRefundDetailsResponseResult();

            ExternalFetchRefundDetailsResponse retrievedRefundDetailsResult =
                randomExternalFetchRefundDetailsResponse;

            RefundDetails expectedBanksResponse =
                ConvertToRefundDetailsResponse(retrievedRefundDetailsResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/refunds/{inputTransactionId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedRefundDetailsResult));

            // when
            RefundDetails actualResult =
                await this.flutterWaveClient.Transactions.RetrieveRefundDetailsAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
