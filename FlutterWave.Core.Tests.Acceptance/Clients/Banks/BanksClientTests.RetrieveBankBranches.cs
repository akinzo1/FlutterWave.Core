



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBanks;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.Banks
{
    public partial class BanksClientTests
    {
        [Fact]
        public async Task ShouldRetrieveBankBranchesByIdAsync()
        {
            // given
            int randomString = GetRandomNumber();
            int randomBankCode = randomString;
            int inputBankCode = randomBankCode;

            ExternalBankBranchesResponse randomExternalBankBranchesResponse =
                CreateRandomExternalBankBranchesResult();

            ExternalBankBranchesResponse retrievedBankBranchesResult =
                randomExternalBankBranchesResponse;

            BankBranches expectedBanksResponse =
                ConvertToBankBranchesResponse(retrievedBankBranchesResult);

            this.wireMockServer.Given(
                Request.Create()
                .UsingGet()
                    .WithPath($"/v3/banks/{inputBankCode}/branches")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrievedBankBranchesResult));

            // when
            BankBranches actualResult =
                await this.flutterWaveClient.Banks.RetrieveAllBankBranchesByBankCodeAsync(inputBankCode);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
