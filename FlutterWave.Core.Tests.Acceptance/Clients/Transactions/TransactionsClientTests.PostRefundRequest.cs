



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
        public async Task ShouldCreateTransactionRefundAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomTransactionNumber = randomNumber;
            int inputTransactionId = randomTransactionNumber;

            ExternalCreateRefundResponse randomExternalCreateRefundResponse =
                CreateExternalCreateRefundResponseResult();

            ExternalCreateRefundResponse retrievedBalanceByCurrencyResult =
                randomExternalCreateRefundResponse;

            CreateRefund expectedBanksResponse =
                ConvertToCreateRefundResponse(retrievedBalanceByCurrencyResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/transactions/{inputTransactionId}/refund")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBalanceByCurrencyResult));

            // when
            CreateRefund actualResult =
                await this.flutterWaveClient.Transactions.CreateRefundRequestAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
