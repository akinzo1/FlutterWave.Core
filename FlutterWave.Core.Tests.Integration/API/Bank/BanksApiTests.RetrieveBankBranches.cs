using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;

namespace FlutterWave.Core.Tests.Integration.API.Banks
{
    public partial class BanksApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldRetrieveAllBankBranchesByIdAsync()
        {
            // given
            int inputBankCode = 280;

            // when
            BankBranches retrievedAIModel =
              await this.flutterWaveClient.Banks.RetrieveAllBankBranchesByBankCodeAsync(inputBankCode);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}