using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;

namespace FlutterWave.Core.Tests.Integration.API.Transfers
{
    public partial class TransfersApiTests
    {
        [Fact]
        public async Task ShouldRetrieveTransferRatesAsync()
        {
            // given
            string destinationCurrency = "yuyutr";
            string sourceCurrency = "yuyutr";
            int amount = 2345;


            // when
            TransferRates retrievedAIModel =
                await this.flutterWaveClient.Transfers.RetrieveTransferRatesAsync(destinationCurrency, amount, sourceCurrency);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}