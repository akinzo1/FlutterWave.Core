



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
        public async Task ShouldPostValidateChargeAsync()
        {

            // given
            ValidateCharge randomValidateCharge = CreateRandomValidateChargeResult();
            ValidateCharge inputValidateCharge = randomValidateCharge;

            ExternalValidateChargeRequest ValidateChargeRequest =
                ConvertToChargeRequest(inputValidateCharge);

            ExternalValidateChargeResponse ValidateChargeResponse =
                            CreateRandomExternalValidateChargeResponseResult();

            ValidateCharge expectedValidateCharge = inputValidateCharge.DeepClone();
            expectedValidateCharge = ConvertToChargeResponse(expectedValidateCharge, ValidateChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/validate-charge")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        ValidateChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(ValidateChargeResponse));

            // when
            ValidateCharge actualResult =
                await this.flutterWaveClient.Charge.ValidateChargeAsync(inputValidateCharge);

            // then
            actualResult.Should().BeEquivalentTo(expectedValidateCharge);
        }
    }
}
