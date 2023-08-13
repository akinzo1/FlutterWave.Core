



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
        public async Task ShouldPostVerifyTransactionAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputTransactionId = randomId;

            ExternalVerifyTransactionResponse randomExternalVerifyTransactionResponse =
                CreateExternalVerifyTransactionResponseResult();

            ExternalVerifyTransactionResponse retrievedVerifyTransactionResult =
                randomExternalVerifyTransactionResponse;

            VerifyTransaction expectedBanksResponse =
                ConvertToVerifyTransactionResponse(retrievedVerifyTransactionResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/transactions/{inputTransactionId}/verify")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVerifyTransactionResult));

            // when
            VerifyTransaction actualResult =
                await this.flutterWaveClient.Transactions.VerifyTransactionAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
