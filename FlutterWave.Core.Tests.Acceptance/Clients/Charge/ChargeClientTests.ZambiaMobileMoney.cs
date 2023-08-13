



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
        public async Task ShouldPostZambiaMobileMoneyAsync()
        {

            // given
            ZambiaMobileMoney randomZambiaMobileMoney = CreateRandomZambiaMobileMoneyResult();
            ZambiaMobileMoney inputZambiaMobileMoney = randomZambiaMobileMoney;

            ExternalZambiaMobileMoneyRequest ZambiaMobileMoneyRequest =
                ConvertToChargeRequest(inputZambiaMobileMoney);

            ExternalZambiaMobileMoneyResponse ZambiaMobileMoneyResponse =
                            CreateRandomExternalZambiaMobileMoneyResponseResult();

            ZambiaMobileMoney expectedZambiaMobileMoney = inputZambiaMobileMoney.DeepClone();
            expectedZambiaMobileMoney = ConvertToChargeResponse(expectedZambiaMobileMoney, ZambiaMobileMoneyResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mobile_money_zambia")
                    .WithBody(JsonConvert.SerializeObject(
                        ZambiaMobileMoneyRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(ZambiaMobileMoneyResponse));

            // when
            ZambiaMobileMoney actualResult =
                await this.flutterWaveClient.Charge.ChargeZambiaMobileMoneyAsync(inputZambiaMobileMoney);

            // then
            actualResult.Should().BeEquivalentTo(expectedZambiaMobileMoney);
        }
    }
}
