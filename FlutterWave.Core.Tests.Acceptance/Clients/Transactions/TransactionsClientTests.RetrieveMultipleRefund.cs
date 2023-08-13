



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
        public async Task ShouldRetrieveMultipleRefundAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomFrom = randomString;
            string inputFrom = randomFrom;

            string randomString2 = GetRandomString();
            string randomTo = randomString2;
            string inputTo = randomTo;

            ExternalFetchMultipleTransactionsResponse randomExternalFetchMultipleRefundTransactionResponse =
                CreateExternalFetchMultipleRefundTransactionResponse();

            ExternalFetchMultipleTransactionsResponse retrievedMultipleTransactionRefundsResult =
                randomExternalFetchMultipleRefundTransactionResponse;

            MultipleRefundTransaction expectedBanksResponse =
                ConvertToMultipleRefundsResponse(retrievedMultipleTransactionRefundsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/refunds")
                    .WithParam("from", inputFrom)
                    .WithParam("to", inputTo)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedMultipleTransactionRefundsResult));

            // when
            MultipleRefundTransaction actualResult =
                await this.flutterWaveClient.Transactions.RetrieveMultipleRefundsAsync(inputFrom, inputTo);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
