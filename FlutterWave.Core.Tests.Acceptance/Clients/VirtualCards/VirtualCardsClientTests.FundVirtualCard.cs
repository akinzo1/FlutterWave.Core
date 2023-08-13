



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
        public async Task ShouldFundVirtualCardAsync()
        {

            // given
            FundVirtualCard randomFundVirtualCard = CreateRandomFundVirtualCardResult();
            FundVirtualCard inputFundVirtualCard = randomFundVirtualCard;
            string inputRandomId = GetRandomString();

            ExternalFundVirtualCardRequest FundVirtualCardRequest =
                ConvertToVirtualCardRequest(inputFundVirtualCard);

            ExternalFundVirtualCardResponse FundVirtualCardResponse =
                            CreateRandomExternalFundVirtualCardResponseResult();

            FundVirtualCard expectedFundVirtualCard = inputFundVirtualCard.DeepClone();
            expectedFundVirtualCard = ConvertToVirtualCardResponse(expectedFundVirtualCard, FundVirtualCardResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/virtual-cards/{inputRandomId}/fund")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        FundVirtualCardRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(FundVirtualCardResponse));

            // when
            FundVirtualCard actualResult =
                await this.flutterWaveClient.VirtualCards.PostFundVirtualCardAsync(inputRandomId, inputFundVirtualCard);

            // then
            actualResult.Should().BeEquivalentTo(expectedFundVirtualCard);
        }
    }
}
