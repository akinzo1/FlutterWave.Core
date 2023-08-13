



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
        public async Task ShouldPostApplePayAsync()
        {

            // given
            ApplePay randomApplePay = CreateRandomApplePayResult();
            ApplePay inputApplePay = randomApplePay;

            ExternalApplePayRequest ApplePayRequest =
                ConvertToChargeRequest(inputApplePay);

            ExternalApplePayResponse ApplePayResponse =
                            CreateRandomExternalApplePayResponseResult();

            ApplePay expectedApplePay = inputApplePay.DeepClone();
            expectedApplePay = ConvertToChargeResponse(expectedApplePay, ApplePayResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "applepay")
                    .WithBody(JsonConvert.SerializeObject(
                        ApplePayRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(ApplePayResponse));

            // when
            ApplePay actualResult =
                await this.flutterWaveClient.Charge.ChargeApplePayAsync(inputApplePay);

            // then
            actualResult.Should().BeEquivalentTo(expectedApplePay);
        }
    }
}
