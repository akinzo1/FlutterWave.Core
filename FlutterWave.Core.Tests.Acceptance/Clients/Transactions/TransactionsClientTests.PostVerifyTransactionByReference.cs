



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
        public async Task ShouldPostVerifyTransactionByReferenceAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomReference = randomString;
            string inputTransactionReference = randomReference;

            ExternalVerifyTransactionResponse randomExternalVerifyTransactionResponse =
                CreateExternalVerifyTransactionResponseResult();

            ExternalVerifyTransactionResponse retrievedVerifyTransactionResult =
                randomExternalVerifyTransactionResponse;

            VerifyTransaction expectedBanksResponse =
                ConvertToVerifyTransactionResponse(retrievedVerifyTransactionResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/transactions/{inputTransactionReference}/verify")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVerifyTransactionResult));

            // when
            VerifyTransaction actualResult =
                await this.flutterWaveClient.Transactions.VerifyTransactionAsync(inputTransactionReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
