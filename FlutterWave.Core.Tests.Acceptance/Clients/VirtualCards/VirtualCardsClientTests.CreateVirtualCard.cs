



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualCardsClient
{
    public partial class VirtualCardsClientTests
    {
        [Fact]
        public async Task ShouldCreateVirtualCardAsync()
        {

            // given
            CreateVirtualCard randomCreateVirtualCard = CreateRandomCreateVirtualCardResult();
            CreateVirtualCard inputCreateVirtualCard = randomCreateVirtualCard;

            ExternalCreateVirtualCardRequest CreateVirtualCardRequest =
                ConvertToVirtualCardRequest(inputCreateVirtualCard);

            ExternalCreateVirtualCardResponse CreateVirtualCardResponse =
                            CreateRandomExternalCreateVirtualCardResponseResult();

            CreateVirtualCard expectedCreateVirtualCard = inputCreateVirtualCard.DeepClone();
            expectedCreateVirtualCard = ConvertToVirtualCardResponse(expectedCreateVirtualCard, CreateVirtualCardResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/virtual-cards")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateVirtualCardRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateVirtualCardResponse));

            // when
            CreateVirtualCard actualResult =
                await this.flutterWaveClient.VirtualCards.CreateVirtualCardAsync(inputCreateVirtualCard);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateVirtualCard);
        }
    }
}
