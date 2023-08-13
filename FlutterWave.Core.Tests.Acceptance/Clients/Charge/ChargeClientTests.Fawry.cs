



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
        public async Task ShouldPostFawryAsync()
        {

            // given
            Fawry randomFawry = CreateRandomFawryResult();
            Fawry inputFawry = randomFawry;

            ExternalFawryRequest FawryRequest =
                ConvertToChargeRequest(inputFawry);

            ExternalFawryResponse FawryResponse =
                            CreateRandomExternalFawryResponseResult();

            Fawry expectedFawry = inputFawry.DeepClone();
            expectedFawry = ConvertToChargeResponse(expectedFawry, FawryResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "fawry_pay")
                    .WithBody(JsonConvert.SerializeObject(
                        FawryRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(FawryResponse));

            // when
            Fawry actualResult =
                await this.flutterWaveClient.Charge.ChargeFawryAsync(inputFawry);

            // then
            actualResult.Should().BeEquivalentTo(expectedFawry);
        }
    }
}
