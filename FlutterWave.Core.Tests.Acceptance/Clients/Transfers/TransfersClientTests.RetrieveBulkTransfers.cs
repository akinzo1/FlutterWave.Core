



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
        public async Task ShouldRetrieveBulkTransfersAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomBatchId = randomString;
            string inputBatchId = randomBatchId;

            ExternalFetchBulkTransferResponse randomExternalFetchBulkTransferResponse =
                CreateExternalFetchBulkTransferResponseResult();

            ExternalFetchBulkTransferResponse retrievedBulkTransfersResult =
                randomExternalFetchBulkTransferResponse;

            FetchBulkTransfers expectedBulkTransfersResponse =
                ConvertToTransfersResponse(retrievedBulkTransfersResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/transfers")
                    .WithParam(inputBatchId)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBulkTransfersResult));

            // when
            FetchBulkTransfers actualResult =
                await this.flutterWaveClient.Transfers.RetrieveBulkTransferAsync(inputBatchId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBulkTransfersResponse);
        }
    }
}
