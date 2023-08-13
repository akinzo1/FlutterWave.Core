



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using static PayloadEncryptor;
namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeClient
{
    public partial class ChargeClientTests
    {
        [Fact]
        public async Task ShouldPostCardChargeAsync()
        {

            // given
            CardCharge randomCardCharge = CreateRandomCardChargeResult();
            CardCharge inputCardCharge = randomCardCharge;

            ExternalCardChargeRequest cardChargeRequest =
                ConvertToChargeRequest(inputCardCharge);

            ExternalCardChargeResponse cardChargeResponse =
                 CreateRandomExternalCardChargeResponseResult();

            string inputEncryptionKey = GetRandomLengthyString();

            var inputEncryptedData = Encrypt(inputEncryptionKey, JsonConvert.SerializeObject(cardChargeRequest));

            ExternalEncryptedChargeRequest encryptedChargeRequest =
                ConvertToEncryptedRequest(inputEncryptedData);

            CardCharge expectedCardCharge = inputCardCharge.DeepClone();
            expectedCardCharge = ConvertToChargeResponse(expectedCardCharge, cardChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithParam("type", "card")
                    .WithBody(JsonConvert.SerializeObject(
                        encryptedChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(cardChargeResponse));

            // when
            CardCharge actualResult =
                await this.flutterWaveClient.Charge.ChargeCardAsync(inputCardCharge, inputEncryptionKey);

            // then
            actualResult.Should().BeEquivalentTo(expectedCardCharge);
        }
    }
}
