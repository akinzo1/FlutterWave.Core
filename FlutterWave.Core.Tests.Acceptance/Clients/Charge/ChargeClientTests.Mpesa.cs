



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
        public async Task ShouldPostMpesaAsync()
        {

            // given
            Mpesa randomMpesa = CreateRandomMpesaResult();
            Mpesa inputMpesa = randomMpesa;

            ExternalMpesaRequest MpesaRequest =
                ConvertToChargeRequest(inputMpesa);

            ExternalMpesaResponse MpesaResponse =
                            CreateRandomExternalMpesaResponseResult();

            Mpesa expectedMpesa = inputMpesa.DeepClone();
            expectedMpesa = ConvertToChargeResponse(expectedMpesa, MpesaResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "mpesa")
                    .WithBody(JsonConvert.SerializeObject(
                        MpesaRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(MpesaResponse));

            // when
            Mpesa actualResult =
                await this.flutterWaveClient.Charge.ChargeMpesaAsync(inputMpesa);

            // then
            actualResult.Should().BeEquivalentTo(expectedMpesa);
        }
    }
}
