



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
        public async Task ShouldPostGooglePayAsync()
        {

            // given
            GooglePay randomGooglePay = CreateRandomGooglePayResult();
            GooglePay inputGooglePay = randomGooglePay;

            ExternalGooglePayRequest GooglePayRequest =
                ConvertToChargeRequest(inputGooglePay);

            ExternalGooglePayResponse GooglePayResponse =
                            CreateRandomExternalGooglePayResponseResult();

            GooglePay expectedGooglePay = inputGooglePay.DeepClone();
            expectedGooglePay = ConvertToChargeResponse(expectedGooglePay, GooglePayResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "googlepay")
                    .WithBody(JsonConvert.SerializeObject(
                        GooglePayRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(GooglePayResponse));

            // when
            GooglePay actualResult =
                await this.flutterWaveClient.Charge.ChargeGooglePayAsync(inputGooglePay);

            // then
            actualResult.Should().BeEquivalentTo(expectedGooglePay);
        }
    }
}
