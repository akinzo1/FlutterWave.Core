



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
        public async Task ShouldRetrieveAllTransferFeesAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomAmount = randomNumber;
            int inputAmount = randomAmount;

            ExternalTransferFeesResponse randomExternalTransferFeesResponse =
                CreateExternalTransferFeesResponseResult();

            ExternalTransferFeesResponse retrievedStatementResult =
                randomExternalTransferFeesResponse;

            TransferFees expectedStatementResponse =
                ConvertToTransfersResponse(retrievedStatementResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/transfers/fee")
                       .WithParam("amount", inputAmount.ToString())
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedStatementResult));

            // when
            TransferFees actualResult =
                await this.flutterWaveClient.Transfers.RetrieveAllTransferFeesAsync(inputAmount);

            // then
            actualResult.Should().BeEquivalentTo(expectedStatementResponse);
        }
    }
}
