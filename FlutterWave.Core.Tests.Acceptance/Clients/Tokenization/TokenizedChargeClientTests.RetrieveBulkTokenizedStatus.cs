



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.TokenizedChargeClient
{
    public partial class TokenizedChargeClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkTokenizedStatusAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputBulkTokenizedChargeId = randomId;

            ExternalBulkTokenizedStatusResponse randomExternalBulkTokenizedStatusResponse =
                CreateRandomExternalBulkTokenizedStatusResponseResult();

            ExternalBulkTokenizedStatusResponse retrievedTokenizedChargeResult =
                randomExternalBulkTokenizedStatusResponse;

            BulkTokenizedStatus expectedBulkTokenizedStatusResponse =
               ConvertToTokenizedChargeResponse(retrievedTokenizedChargeResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/bulk-tokenized-charges/{inputBulkTokenizedChargeId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedTokenizedChargeResult));

            // when
            BulkTokenizedStatus actualResult =
                await this.flutterWaveClient.TokenizedCharge.RetrieveBulkTokenizedStatusAsync(inputBulkTokenizedChargeId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBulkTokenizedStatusResponse);
        }
    }
}
