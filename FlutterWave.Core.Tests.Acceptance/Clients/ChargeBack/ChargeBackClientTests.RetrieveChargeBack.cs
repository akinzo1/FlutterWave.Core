



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.ChargeBackClient
{
    public partial class ChargeBackClientTests
    {
        [Fact]
        public async Task ShouldRetrieveChargeBacksByReferenceAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomReference = randomString;
            string inputReference = randomReference;

            ExternalChargeBackResponse randomExternalChargeBackResponse =
                CreateExternalChargeBackResult();

            ExternalChargeBackResponse retrievedChargeBackResult =
                randomExternalChargeBackResponse;

            ChargeBack expectedBanksResponse =
                ConvertToChargeBackResponse(retrievedChargeBackResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/chargebacks")
                     .WithParam("flw_ref", inputReference)
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedChargeBackResult));

            // when
            ChargeBack actualResult =
                await this.flutterWaveClient.ChargeBack.RetrieveChargeBackAsync(inputReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
