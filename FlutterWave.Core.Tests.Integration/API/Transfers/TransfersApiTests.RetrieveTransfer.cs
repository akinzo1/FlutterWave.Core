using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetrieveTransferAsync()
        {
            // given
            int transactionId = 2344;

            // when
            FetchTransfers retrievedAIModel =
              await this.flutterWaveClient.Transfers.RetrieveTransferAsync(transactionId);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}