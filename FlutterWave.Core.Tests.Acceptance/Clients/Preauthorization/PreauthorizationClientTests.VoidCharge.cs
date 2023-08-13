



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.PreauthorizationClient
{
    public partial class PreauthorizationClientTests
    {
        [Fact]
        public async Task ShouldVoidChargeAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputflwRef = randomId;

            ExternalVoidChargeResponse randomExternalVoidChargeResponse =
                CreateRandomExternalVoidChargeResponseResult();

            ExternalVoidChargeResponse retrievedPreauthorizationResult =
                randomExternalVoidChargeResponse;

            VoidCharge expectedVoidChargeResponse =
               ConvertToPreauthorizationResponse(retrievedPreauthorizationResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPost()
                    .WithPath($"/v3/charges/{inputflwRef}/")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPreauthorizationResult));

            // when
            VoidCharge actualResult =
                await this.flutterWaveClient.Preauthorization.VoidChargeAsync(inputflwRef);

            // then
            actualResult.Should().BeEquivalentTo(expectedVoidChargeResponse);
        }
    }
}
