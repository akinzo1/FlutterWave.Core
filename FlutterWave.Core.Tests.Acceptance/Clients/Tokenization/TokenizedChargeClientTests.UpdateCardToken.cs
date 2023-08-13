



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
        public async Task ShouldPostUpdateCardTokenAsync()
        {

            // given
            UpdateCardToken randomUpdateCardToken = CreateRandomUpdateCardTokenResult();
            UpdateCardToken inputUpdateCardToken = randomUpdateCardToken;
            string inputRandomId = GetRandomString();

            ExternalUpdateCardTokenRequest UpdateCardTokenRequest =
                ConvertToTokenizedChargeRequest(inputUpdateCardToken);

            ExternalUpdateCardTokenResponse UpdateCardTokenResponse =
                            CreateRandomExternalUpdateCardTokenResponseResult();

            UpdateCardToken expectedUpdateCardToken = inputUpdateCardToken.DeepClone();
            expectedUpdateCardToken = ConvertToTokenizedChargeResponse(expectedUpdateCardToken, UpdateCardTokenResponse);

            var jsonSerializationSettings = new JsonSerializerSettings();
            jsonSerializationSettings.DefaultValueHandling = DefaultValueHandling.Ignore;

            this.wireMockServer.Given(
                Request.Create()
                .UsingPut()
                    .WithPath($"/v3/tokens/{inputRandomId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}")
                    .WithHeader("Content-Type", "application/json; charset=utf-8")
                    .WithBody(JsonConvert.SerializeObject(
                        UpdateCardTokenRequest,
                        jsonSerializationSettings)))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(UpdateCardTokenResponse));

            // when
            UpdateCardToken actualResult =
                await this.flutterWaveClient.TokenizedCharge.UpdateCardTokenAsync(inputRandomId, inputUpdateCardToken);

            // then
            actualResult.Should().BeEquivalentTo(expectedUpdateCardToken);
        }
    }
}
