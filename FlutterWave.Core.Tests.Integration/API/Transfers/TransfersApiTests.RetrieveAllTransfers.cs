using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllTransfersAsync()
        {

            // given

            // . when
            AllTransfers responseAIModels =
                await this.flutterWaveClient.Transfers.RetrieveAllTransfersAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
