



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
        public async Task ShouldRetrieveTransferRetryAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputTransactionId = randomId;

            ExternalFetchTransferRetryResponse randomExternalFetchTransferRetryResponse =
                CreateExternalFetchTransferRetryResponseResult();

            ExternalFetchTransferRetryResponse retrievedTransferRetryResult =
                randomExternalFetchTransferRetryResponse;

            FetchRetryTransfers expectedBanksResponse =
                ConvertToTransfersResponse(retrievedTransferRetryResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/transfers/{inputTransactionId}/retries")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedTransferRetryResult));

            // when
            FetchRetryTransfers actualResult =
                await this.flutterWaveClient.Transfers.TransferRetryAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
