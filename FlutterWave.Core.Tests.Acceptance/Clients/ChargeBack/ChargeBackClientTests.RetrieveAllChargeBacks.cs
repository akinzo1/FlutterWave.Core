



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
        public async Task ShouldRetrieveAllChargeBacksAsync()
        {
            // given

            ExternalChargeBacksResponse randomExternalChargeBacksResponse =
                CreateExternalChargeBacksResult();

            ExternalChargeBacksResponse retrievedChargeBacksResult =
                randomExternalChargeBacksResponse;

            AllChargeBacks expectedChargeBacksResponse =
                ConvertToChargeBackResponse(retrievedChargeBacksResult);


            this.wireMockServer.Given(
                Request.Create()
                       .UsingGet()
                       .WithPath($"/v3/chargebacks")
                       .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                     Response.Create()
                    .WithBodyAsJson(retrievedChargeBacksResult));

            // when
            AllChargeBacks actualResult =
                await this.flutterWaveClient.ChargeBack.RetrieveAllChargeBacksAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedChargeBacksResponse);
        }
    }
}
