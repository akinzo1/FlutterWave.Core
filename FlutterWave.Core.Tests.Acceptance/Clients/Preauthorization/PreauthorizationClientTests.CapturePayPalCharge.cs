



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PreauthorizationClient
{
    public partial class PreauthorizationClientTests
    {
        [Fact]
        public async Task ShouldCapturePayPalChargeAsync()
        {

            // given
            CapturePayPalCharge randomCapturePayPalCharge = CreateRandomCapturePayPalChargeResult();
            CapturePayPalCharge inputCapturePayPalCharge = randomCapturePayPalCharge;

            ExternalCapturePayPalChargeRequest CapturePayPalChargeRequest =
                ConvertToPreauthorizationRequest(inputCapturePayPalCharge);

            ExternalCapturePayPalChargeResponse CapturePayPalChargeResponse =
                            CreateRandomExternalCapturePayPalChargeResponseResult();

            CapturePayPalCharge expectedCapturePayPalCharge = inputCapturePayPalCharge.DeepClone();
            expectedCapturePayPalCharge = ConvertToPreauthorizationResponse(expectedCapturePayPalCharge, CapturePayPalChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges/paypal-capture")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CapturePayPalChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CapturePayPalChargeResponse));

            // when
            CapturePayPalCharge actualResult =
                await this.flutterWaveClient.Preauthorization.CapturePayPalChargeAsync(inputCapturePayPalCharge);

            // then
            actualResult.Should().BeEquivalentTo(expectedCapturePayPalCharge);
        }
    }
}
