



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
        public async Task ShouldRetrieveTransactionFeesAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomCurrency = randomString;
            string inputCurrency = randomCurrency;

            int randomNumber = GetRandomNumber();
            int randomAmount = randomNumber;
            int inputAmount = randomAmount;

            ExternalFetchTransactionFeesResponse randomExternalFetchTransactionFeesResponse =
                CreateExternalFetchTransactionFeesResponseResult();

            ExternalFetchTransactionFeesResponse retrievedTransactionFeesResult =
                randomExternalFetchTransactionFeesResponse;

            TransactionFees expectedTransactionFeesResponse =
                ConvertToTransactionFeesResponse(retrievedTransactionFeesResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/transactions/fee")
                    .WithParam("from", inputAmount.ToString())
                    .WithParam("to", inputCurrency)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedTransactionFeesResult));

            // when
            TransactionFees actualResult =
                await this.flutterWaveClient.Transactions.RetrieveTransactionFeesAsync(inputAmount, inputCurrency);

            // then
            actualResult.Should().BeEquivalentTo(expectedTransactionFeesResponse);
        }
    }
}
