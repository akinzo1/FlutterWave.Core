



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
        public async Task ShouldPostGhanaMobileMoneyAsync()
        {

            // given
            GhanaMobileMoney randomGhanaMobileMoney = CreateRandomGhanaMobileMoneyResult();
            GhanaMobileMoney inputGhanaMobileMoney = randomGhanaMobileMoney;

            ExternalGhanaMobileMoneyRequest GhanaMobileMoneyRequest =
                ConvertToChargeRequest(inputGhanaMobileMoney);

            ExternalGhanaMobileMoneyResponse GhanaMobileMoneyResponse =
                            CreateRandomExternalGhanaMobileMoneyResponseResult();

            GhanaMobileMoney expectedGhanaMobileMoney = inputGhanaMobileMoney.DeepClone();
            expectedGhanaMobileMoney = ConvertToChargeResponse(expectedGhanaMobileMoney, GhanaMobileMoneyResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mobile_money_ghana")
                    .WithBody(JsonConvert.SerializeObject(
                        GhanaMobileMoneyRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(GhanaMobileMoneyResponse));

            // when
            GhanaMobileMoney actualResult =
                await this.flutterWaveClient.Charge.ChargeGhanaMobileMoneyAsync(inputGhanaMobileMoney);

            // then
            actualResult.Should().BeEquivalentTo(expectedGhanaMobileMoney);
        }
    }
}
