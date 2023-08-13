



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
        public async Task ShouldPostRwandaMobileMoneyAsync()
        {

            // given
            RwandaMobileMoney randomRwandaMobileMoney = CreateRandomRwandaMobileMoneyResult();
            RwandaMobileMoney inputRwandaMobileMoney = randomRwandaMobileMoney;

            ExternalRwandaMobileMoneyRequest RwandaMobileMoneyRequest =
                ConvertToChargeRequest(inputRwandaMobileMoney);

            ExternalRwandaMobileMoneyResponse RwandaMobileMoneyResponse =
                            CreateRandomExternalRwandaMobileMoneyResponseResult();

            RwandaMobileMoney expectedRwandaMobileMoney = inputRwandaMobileMoney.DeepClone();
            expectedRwandaMobileMoney = ConvertToChargeResponse(expectedRwandaMobileMoney, RwandaMobileMoneyResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mobile_money_rwanda")
                    .WithBody(JsonConvert.SerializeObject(
                        RwandaMobileMoneyRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(RwandaMobileMoneyResponse));

            // when
            RwandaMobileMoney actualResult =
                await this.flutterWaveClient.Charge.ChargeRwandaMobileMoneyAsync(inputRwandaMobileMoney);

            // then
            actualResult.Should().BeEquivalentTo(expectedRwandaMobileMoney);
        }
    }
}
