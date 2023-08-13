



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
        public async Task ShouldVoidPayPalChargeAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputFlwRef = randomId;

            ExternalVoidPayPalChargeResponse randomExternalVoidPayPalChargeResponse =
                CreateRandomExternalVoidPayPalChargeResponseResult();

            ExternalVoidPayPalChargeResponse retrievedPreauthorizationResult =
                randomExternalVoidPayPalChargeResponse;

            VoidPayPalCharge expectedVoidPayPalChargeResponse =
               ConvertToPreauthorizationResponse(retrievedPreauthorizationResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPost()
                    .WithPath($"/v3/charges/paypal-void/{inputFlwRef}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedPreauthorizationResult));

            // when
            VoidPayPalCharge actualResult =
                await this.flutterWaveClient.Preauthorization.VoidPayPalChargeAsync(inputFlwRef);

            // then
            actualResult.Should().BeEquivalentTo(expectedVoidPayPalChargeResponse);
        }
    }
}
