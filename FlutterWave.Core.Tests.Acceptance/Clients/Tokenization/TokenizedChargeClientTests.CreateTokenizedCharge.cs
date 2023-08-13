



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Force.DeepCloner;
using Newtonsoft.Json;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TokenizedChargeClient
{
    public partial class TokenizedChargeClientTests
    {
        [Fact]
        public async Task ShouldCreateTokenizedChargeAsync()
        {

            // given
            CreateTokenizedCharge randomCreateTokenizedCharge = CreateRandomCreateTokenizedChargeResult();
            CreateTokenizedCharge inputCreateTokenizedCharge = randomCreateTokenizedCharge;

            ExternalCreateTokenizedChargeRequest CreateTokenizedChargeRequest =
                ConvertToTokenizedChargeRequest(inputCreateTokenizedCharge);

            ExternalCreateTokenizedChargeResponse CreateTokenizedChargeResponse =
                            CreateRandomExternalCreateTokenizedChargeResponseResult();

            CreateTokenizedCharge expectedCreateTokenizedCharge = inputCreateTokenizedCharge.DeepClone();
            expectedCreateTokenizedCharge = ConvertToTokenizedChargeResponse(expectedCreateTokenizedCharge, CreateTokenizedChargeResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPost()
                    .WithPath($"/v3/tokenized-charges")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        CreateTokenizedChargeRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(CreateTokenizedChargeResponse));

            // when
            CreateTokenizedCharge actualResult =
                await this.flutterWaveClient.TokenizedCharge.CreateTokenizedChargeAsync(inputCreateTokenizedCharge);

            // then
            actualResult.Should().BeEquivalentTo(expectedCreateTokenizedCharge);
        }
    }
}
