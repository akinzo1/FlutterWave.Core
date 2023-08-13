



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
        public async Task ShouldPostUSSDAsync()
        {

            // given
            USSD randomUSSD = CreateRandomUSSDResult();
            USSD inputUSSD = randomUSSD;

            ExternalUSSDRequest USSDRequest =
                ConvertToChargeRequest(inputUSSD);

            ExternalUSSDResponse USSDResponse =
                            CreateRandomExternalUSSDResponseResult();

            USSD expectedUSSD = inputUSSD.DeepClone();
            expectedUSSD = ConvertToChargeResponse(expectedUSSD, USSDResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "ussd")
                    .WithBody(JsonConvert.SerializeObject(
                        USSDRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(USSDResponse));

            // when
            USSD actualResult =
                await this.flutterWaveClient.Charge.ChargeUSSDAsync(inputUSSD);

            // then
            actualResult.Should().BeEquivalentTo(expectedUSSD);
        }
    }
}
