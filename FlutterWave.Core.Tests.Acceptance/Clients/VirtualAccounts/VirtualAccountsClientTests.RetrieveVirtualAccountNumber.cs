



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
        public async Task ShouldRetrieveVirtualAccountNumberByAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomId = randomString;
            string inputReference = randomId;

            ExternalVirtualAccountNumberResponse randomExternalVirtualAccountNumberResponse =
                CreateExternalVirtualAccountNumberResponseResult();

            ExternalVirtualAccountNumberResponse retrievedVirtualAccountsResult =
                randomExternalVirtualAccountNumberResponse;

            FetchVirtualAccounts expectedBanksResponse =
                ConvertToVirtualAccountsResponse(retrievedVirtualAccountsResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/virtual-account-numbers/{inputReference}")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedVirtualAccountsResult));

            // when
            FetchVirtualAccounts actualResult =
                await this.flutterWaveClient.VirtualAccounts.RetrieveVirtualAccountNumberAsync(inputReference);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
