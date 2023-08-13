



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using static PayloadEncryptor;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PreauthorizationClient
{
    public partial class PreauthorizationClientTests
    {
        [Fact]
        public async Task ShouldCreateChargeAsync()
        {

            // given
            CreateCharge randomCreateCharge = CreateRandomCreateChargeResult();
            CreateCharge inputCreateCharge = randomCreateCharge;

            ExternalCreateChargeRequest createChargeRequest =
                ConvertToPreauthorizationRequest(inputCreateCharge);

            ExternalCreateChargeResponse CreateChargeResponse =
              CreateRandomExternalCreateChargeResponseResult();

            string inputEncryptionKey = GetRandomLengthyString();

            var inputEncryptedData = Encrypt(inputEncryptionKey, JsonConvert.SerializeObject(createChargeRequest));

            ExternalEncryptedChargeRequest encryptedChargeRequest =
                ConvertToEncryptedRequest(inputEncryptedData);

            CreateCharge expectedCreateCharge = inputCreateCharge.DeepClone();
            expectedCreateCharge = ConvertToPreauthorizationResponse(expectedCreateCharge, CreateChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithParam("type", "card")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        encryptedChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateChargeResponse));

            // when
            CreateCharge actualResult =
                await this.flutterWaveClient.Preauthorization.CreateChargeAsync(inputCreateCharge, inputEncryptionKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateCharge);
        }
    }
}
