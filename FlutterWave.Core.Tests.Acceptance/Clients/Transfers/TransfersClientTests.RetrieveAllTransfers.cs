



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
        public async Task ShouldRetrieveAllTransfersAsync()
        {
            // given

            ExternalAllTransfersResponse randomExternalAllTransfersResponse =
                CreateExternalAllTransfersResponseResult();

            ExternalAllTransfersResponse retrievedStatementResult =
                randomExternalAllTransfersResponse;

            AllTransfers expectedTransfersResponse =
                ConvertToTransfersResponse(retrievedStatementResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/transfers")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedStatementResult));

            // when
            AllTransfers actualResult =
                await this.flutterWaveClient.Transfers.RetrieveAllTransfersAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedTransfersResponse);
        }
    }
}
