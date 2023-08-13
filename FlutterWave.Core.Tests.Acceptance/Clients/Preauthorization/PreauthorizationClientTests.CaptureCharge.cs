



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
        public async Task ShouldPostCaptureChargeAsync()
        {

            // given
            CaptureCharge randomCaptureCharge = CreateRandomCaptureChargeResult();
            CaptureCharge inputCaptureCharge = randomCaptureCharge;
            string inputRandomId = GetRandomString();

            ExternalCaptureChargeRequest CaptureChargeRequest =
                ConvertToPreauthorizationRequest(inputCaptureCharge);

            ExternalCaptureChargeResponse CaptureChargeResponse =
                            CreateRandomExternalCaptureChargeResponseResult();

            CaptureCharge expectedCaptureCharge = inputCaptureCharge.DeepClone();
            expectedCaptureCharge = ConvertToPreauthorizationResponse(expectedCaptureCharge, CaptureChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges/{inputRandomId}/capture")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CaptureChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CaptureChargeResponse));

            // when
            CaptureCharge actualResult =
                await this.flutterWaveClient.Preauthorization.CaptureChargeAsync(inputRandomId, inputCaptureCharge);

            // then
            actualResult.Should().BeEquivalentTo(expectedCaptureCharge);
        }
    }
}
