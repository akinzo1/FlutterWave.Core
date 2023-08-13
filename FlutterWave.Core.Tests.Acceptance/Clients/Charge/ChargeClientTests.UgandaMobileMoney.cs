



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
        public async Task ShouldPostUgandaMobileMoneyAsync()
        {

            // given
            UgandaMobileMoney randomUgandaMobileMoney = CreateRandomUgandaMobileMoneyResult();
            UgandaMobileMoney inputUgandaMobileMoney = randomUgandaMobileMoney;

            ExternalUgandaMobileMoneyRequest UgandaMobileMoneyRequest =
                ConvertToChargeRequest(inputUgandaMobileMoney);

            ExternalUgandaMobileMoneyResponse UgandaMobileMoneyResponse =
                            CreateRandomExternalUgandaMobileMoneyResponseResult();

            UgandaMobileMoney expectedUgandaMobileMoney = inputUgandaMobileMoney.DeepClone();
            expectedUgandaMobileMoney = ConvertToChargeResponse(expectedUgandaMobileMoney, UgandaMobileMoneyResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mobile_money_uganda")
                    .WithBody(JsonConvert.SerializeObject(
                        UgandaMobileMoneyRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UgandaMobileMoneyResponse));

            // when
            UgandaMobileMoney actualResult =
                await this.flutterWaveClient.Charge.ChargeUgandaMobileMoneyAsync(inputUgandaMobileMoney);

            // then
            actualResult.Should().BeEquivalentTo(expectedUgandaMobileMoney);
        }
    }
}
