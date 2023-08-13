



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeClient
{
    public partial class ChargeClientTests
    {
        [Fact]
        public async Task ShouldPostTanzaniaMobileMoneyAsync()
        {

            // given
            TanzaniaMobileMoney randomTanzaniaMobileMoney = CreateRandomTanzaniaMobileMoneyResult();
            TanzaniaMobileMoney inputTanzaniaMobileMoney = randomTanzaniaMobileMoney;

            ExternalTanzaniaMobileMoneyRequest TanzaniaMobileMoneyRequest =
                ConvertToChargeRequest(inputTanzaniaMobileMoney);

            ExternalTanzaniaMobileMoneyResponse TanzaniaMobileMoneyResponse =
                            CreateRandomExternalTanzaniaMobileMoneyResponseResult();

            TanzaniaMobileMoney expectedTanzaniaMobileMoney = inputTanzaniaMobileMoney.DeepClone();
            expectedTanzaniaMobileMoney = ConvertToChargeResponse(expectedTanzaniaMobileMoney, TanzaniaMobileMoneyResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mobile_money_tanzania")
                    .WithBody(JsonConvert.SerializeObject(
                        TanzaniaMobileMoneyRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(TanzaniaMobileMoneyResponse));

            // when
            TanzaniaMobileMoney actualResult =
                await this.flutterWaveClient.Charge.ChargeTanzaniaMobileMoneyAsync(inputTanzaniaMobileMoney);

            // then
            actualResult.Should().BeEquivalentTo(expectedTanzaniaMobileMoney);
        }
    }
}
