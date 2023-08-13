



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
        public async Task ShouldRetrieveTransactionTimelineAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputTransactionId = randomId;

            ExternalTransactionTimelineResponse randomExternalTransactionTimelineResponse =
                CreateExternalTransactionTimelineResponseResult();

            ExternalTransactionTimelineResponse retrievedBalanceByCurrencyResult =
                randomExternalTransactionTimelineResponse;

            TransactionTimeline expectedBanksResponse =
                ConvertToTransactionTimelineResponse(retrievedBalanceByCurrencyResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/transactions/{inputTransactionId}/events")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBalanceByCurrencyResult));

            // when
            TransactionTimeline actualResult =
                await this.flutterWaveClient.Transactions.RetrieveTransactionTimelineAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
