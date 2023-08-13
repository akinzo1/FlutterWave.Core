using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBulkTransfersAsync()
        {
            // given
            string batchId = "26251";

            // when
            FetchBulkTransfers retrievedAIModel =
              await this.flutterWaveClient.Transfers.RetrieveBulkTransferAsync(batchId);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}