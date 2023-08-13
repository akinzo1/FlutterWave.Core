



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TransfersClient
{
    public partial class TransfersClientTests
    {
        [Fact]
        public async Task ShouldRetrieveRetryTransfersAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputTransactionId = randomId;

            ExternalRetryTransferResponse randomExternalRetryTransferResponse =
               CreateExternalRetryTransferResponseResult();

            ExternalRetryTransferResponse retrievedRetryTransfersResult =
                randomExternalRetryTransferResponse;

            RetryTransfers expectedBanksResponse =
                ConvertToTransfersResponse(retrievedRetryTransfersResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPost()
                    .WithPath($"/v3/transfers/{inputTransactionId}/retries")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedRetryTransfersResult));

            // when
            RetryTransfers actualResult =
                await this.flutterWaveClient.Transfers.RetryTransfersAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
