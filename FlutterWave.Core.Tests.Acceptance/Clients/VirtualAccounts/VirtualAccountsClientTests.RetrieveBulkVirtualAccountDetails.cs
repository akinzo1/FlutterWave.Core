



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.VirtualAccountsClient
{
    public partial class VirtualAccountsClientTests
    {
        [Fact]
        public async Task ShouldRetrieveVirtualAccountsDetailsByBatchIdAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputBatchId = randomId;

            ExternalBulkVirtualAccountDetailsResponse randomExternalBulkVirtualAccountDetailsResponseResponse =
                CreateExternalBulkVirtualAccountDetailsResponseResult();

            ExternalBulkVirtualAccountDetailsResponse retrievedBulkCreateVirtualAccountsResponseResult =
                randomExternalBulkVirtualAccountDetailsResponseResponse;

            BulkVirtualAccountDetails expectedBanksResponse =
                ConvertToVirtualAccountsResponse(retrievedBulkCreateVirtualAccountsResponseResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/bulk-virtual-account-numbers/{inputBatchId}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBulkCreateVirtualAccountsResponseResult));

            // when
            BulkVirtualAccountDetails actualResult =
                await this.flutterWaveClient.VirtualAccounts.RetrieveBulkVirtualAccountDetailsAsync(inputBatchId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
