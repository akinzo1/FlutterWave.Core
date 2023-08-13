using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldTransferRetryAsync()
        {
            // given
            int transactionId = 2234;

            // when
            FetchRetryTransfers retrievedAIModel =
              await this.flutterWaveClient.Transfers.TransferRetryAsync(transactionId);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}