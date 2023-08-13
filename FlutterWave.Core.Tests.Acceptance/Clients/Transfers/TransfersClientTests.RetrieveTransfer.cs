



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
        public async Task ShouldRetrieveFetchTransfersByBinAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputTransactionId = randomId;

            ExternalFetchTransferResponse randomExternalFetchTransferResponse =
                CreateExternalFetchTransferResponseResult();

            ExternalFetchTransferResponse retrievedFetchTransfersResult =
                randomExternalFetchTransferResponse;

            FetchTransfers expectedBanksResponse =
                ConvertToTransfersResponse(retrievedFetchTransfersResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/transfers/{inputTransactionId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedFetchTransfersResult));

            // when
            FetchTransfers actualResult =
                await this.flutterWaveClient.Transfers.RetrieveTransferAsync(inputTransactionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
