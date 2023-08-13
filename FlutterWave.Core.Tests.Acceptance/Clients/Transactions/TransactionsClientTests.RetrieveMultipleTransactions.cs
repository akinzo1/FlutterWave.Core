



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
        public async Task ShouldRetrieveMultipleTransactionsAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomFrom = randomString;
            string inputFrom = randomFrom;

            string randomString2 = GetRandomString();
            string randomTo = randomString2;
            string inputTo = randomTo;


            ExternalMultipleTransactionResponse randomExternalMultipleTransactionResponse =
                CreateExternalMultipleTransactionResponse();

            ExternalMultipleTransactionResponse retrievedMultipleTransactionsResult =
                randomExternalMultipleTransactionResponse;

            MultipleTransaction expectedMultipleTransactionsResponse =
                ConvertToMultipleTransactionsResponse(retrievedMultipleTransactionsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/transactions")
                    .WithParam("from", inputFrom)
                    .WithParam("to", inputTo)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedMultipleTransactionsResult));

            // when
            MultipleTransaction actualResult =
                await this.flutterWaveClient.Transactions.RetrieveMultipleTransactionAsync(inputFrom, inputTo);

            // then
            actualResult.Should().BeEquivalentTo(expectedMultipleTransactionsResponse);
        }
    }
}
