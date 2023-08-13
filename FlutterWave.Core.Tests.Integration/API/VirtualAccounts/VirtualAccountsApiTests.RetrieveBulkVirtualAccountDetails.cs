using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;

namespace FlutterWave.Core.Tests.Integration.API.VirtualAccounts
{
    public partial class VirtualAccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkVirtualAccountDetailsAsync()
        {
            // given
            string batchId = "yuyutr";

            // when
            BulkVirtualAccountDetails retrievedAIModel =
              await this.flutterWaveClient.VirtualAccounts.RetrieveBulkVirtualAccountDetailsAsync(batchId);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}