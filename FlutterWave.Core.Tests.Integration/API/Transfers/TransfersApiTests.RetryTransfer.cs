using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetryTransferAsync()
        {

            // given
            int transactionId = 2234;
            // . when
            RetryTransfers responseAIModels =
                await this.flutterWaveClient.Transfers.RetryTransfersAsync(transactionId);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
