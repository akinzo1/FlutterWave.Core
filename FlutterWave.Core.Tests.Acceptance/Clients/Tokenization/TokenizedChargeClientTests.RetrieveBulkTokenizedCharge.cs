



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
        public async Task ShouldRetrieveBulkTokenizedChargeAsync()
        {
            // given
            int randomNumber = GetRandomNumber();
            int randomId = randomNumber;
            int inputBulkTokenizedChargeId = randomId;

            ExternalFetchBulkTokenizedChargeResponse randomExternalFetchBulkTokenizedChargeResponse =
                CreateRandomExternalFetchBulkTokenizedChargeResponseResult();

            ExternalFetchBulkTokenizedChargeResponse retrievedTokenizedChargeResult =
                randomExternalFetchBulkTokenizedChargeResponse;

            FetchBulkTokenizedCharge expectedFetchBulkTokenizedChargeResponse =
               ConvertToTokenizedChargeResponse(retrievedTokenizedChargeResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/bulk-tokenized-charges/{inputBulkTokenizedChargeId}/transactions")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedTokenizedChargeResult));

            // when
            FetchBulkTokenizedCharge actualResult =
                await this.flutterWaveClient.TokenizedCharge.RetrieveBulkTokenizedChargesAsync(inputBulkTokenizedChargeId);

            // then
            actualResult.Should().BeEquivalentTo(expectedFetchBulkTokenizedChargeResponse);
        }
    }
}
