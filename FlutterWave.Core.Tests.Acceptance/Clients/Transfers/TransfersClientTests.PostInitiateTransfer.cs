



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
        public async Task ShouldPostInitiateTransfersAsync()
        {

            // given
            InitiateTransfers randomInitiateTransfers = CreateRandomInitiateTransfers();
            InitiateTransfers inputInitiateTransfers = randomInitiateTransfers;

            ExternalInitiateTransferRequest InitiateTransfersRequest =
                ConvertInitiateTransfersRequest(inputInitiateTransfers);

            ExternalInitiateTransferResponse InitiateTransfersResponse =
                            CreateExternalInitiateTransferResponseResult();

            InitiateTransfers expectedInitiateTransfers = inputInitiateTransfers.DeepClone();
            expectedInitiateTransfers = ConvertToTransfersResponse(expectedInitiateTransfers, InitiateTransfersResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/transfers")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        InitiateTransfersRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(InitiateTransfersResponse));

            // when
            InitiateTransfers actualResult =
                await this.flutterWaveClient.Transfers.InitiateTransferAsync(inputInitiateTransfers);

            // then
            actualResult.Should().BeEquivalentTo(expectedInitiateTransfers);
        }
    }
}
