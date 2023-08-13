using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetrieveTransferFeesAsync()
        {
            // given
            int amount = 20000;

            // when
            TransferFees retrievedAIModel =
              await this.flutterWaveClient.Transfers.RetrieveAllTransferFeesAsync(amount);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}