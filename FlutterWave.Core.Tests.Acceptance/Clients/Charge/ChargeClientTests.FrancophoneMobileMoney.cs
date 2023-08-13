



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
        public async Task ShouldPostFrancophoneMobileMoneyAsync()
        {

            // given
            FrancophoneMobileMoney randomFrancophoneMobileMoney = CreateRandomFrancophoneMobileMoneyResult();
            FrancophoneMobileMoney inputFrancophoneMobileMoney = randomFrancophoneMobileMoney;

            ExternalFrancophoneMobileMoneyRequest FrancophoneMobileMoneyRequest =
                ConvertToChargeRequest(inputFrancophoneMobileMoney);

            ExternalFrancophoneMobileMoneyResponse FrancophoneMobileMoneyResponse =
                            CreateRandomExternalFrancophoneMobileMoneyResponseResult();

            FrancophoneMobileMoney expectedFrancophoneMobileMoney = inputFrancophoneMobileMoney.DeepClone();
            expectedFrancophoneMobileMoney = ConvertToChargeResponse(expectedFrancophoneMobileMoney, FrancophoneMobileMoneyResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mobile_money_franco")
                    .WithBody(JsonConvert.SerializeObject(
                        FrancophoneMobileMoneyRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(FrancophoneMobileMoneyResponse));

            // when
            FrancophoneMobileMoney actualResult =
                await this.flutterWaveClient.Charge.ChargeFrancophoneMobileMoneyAsync(inputFrancophoneMobileMoney);

            // then
            actualResult.Should().BeEquivalentTo(expectedFrancophoneMobileMoney);
        }
    }
}
