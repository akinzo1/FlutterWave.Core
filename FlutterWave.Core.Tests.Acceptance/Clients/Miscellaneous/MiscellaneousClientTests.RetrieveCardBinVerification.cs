



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.MiscellaneousClient
{
    public partial class MiscellaneousClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBinVerificationByBinAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomBin = randomString;
            string inputBin = randomBin;

            ExternalCardBinVerificationResponse randomExternalCardBinVerificationResponse =
                CreateExternalCardBinVerificationResponseResult();

            ExternalCardBinVerificationResponse retrievedBinVerificationResult =
                randomExternalCardBinVerificationResponse;

            BinVerification expectedBanksResponse =
                ConvertToMiscellaneousResponse(retrievedBinVerificationResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/card-bins/{inputBin}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBinVerificationResult));

            // when
            BinVerification actualResult =
                await this.flutterWaveClient.Miscellaneous.CardBinVerificationAsync(inputBin);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
