



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
        public async Task ShouldPostPayPalAsync()
        {

            // given
            PayPal randomPayPal = CreateRandomPayPalResult();
            PayPal inputPayPal = randomPayPal;

            ExternalPayPalRequest PayPalRequest =
                ConvertToChargeRequest(inputPayPal);

            ExternalPayPalResponse PayPalResponse =
                            CreateRandomExternalPayPalResponseResult();

            PayPal expectedPayPal = inputPayPal.DeepClone();
            expectedPayPal = ConvertToChargeResponse(expectedPayPal, PayPalResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "paypal")
                    .WithBody(JsonConvert.SerializeObject(
                        PayPalRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(PayPalResponse));

            // when
            PayPal actualResult =
                await this.flutterWaveClient.Charge.ChargePayPalAsync(inputPayPal);

            // then
            actualResult.Should().BeEquivalentTo(expectedPayPal);
        }
    }
}
