



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TransfersClient
{
    public partial class TransfersClientTests
    {
        [Fact]
        public async Task ShouldPostBulkTransferAsync()
        {

            // given
            BulkCreateTransfers randomBulkCreateTransfers = CreateRandomBulkCreateTransfers();
            BulkCreateTransfers inputBulkCreateTransfers = randomBulkCreateTransfers;

            ExternalCreateBulkTransferRequest BulkCreateTransfersRequest =
                ConvertCreateBulkTransfersRequest(inputBulkCreateTransfers);

            ExternalCreateBulkTransferResponse BulkCreateTransfersResponse =
                            CreateExternalCreateBulkTransferResponseResult();

            BulkCreateTransfers expectedBulkCreateTransfers = inputBulkCreateTransfers.DeepClone();
            expectedBulkCreateTransfers = ConvertToTransfersResponse(inputBulkCreateTransfers, BulkCreateTransfersResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/bulk-transfers")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        BulkCreateTransfersRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(BulkCreateTransfersResponse));

            // when
            BulkCreateTransfers actualResult =
                await this.flutterWaveClient.Transfers.CreateBulkTransferAsync(inputBulkCreateTransfers);

            // then
            actualResult.Should().BeEquivalentTo(expectedBulkCreateTransfers);
        }
    }
}
