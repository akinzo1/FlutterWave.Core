using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;

namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllBalanceCurrenciesAsync()
        {

            // given

            // . when
            BalanceByCurrencies responseAIModels =
                await this.flutterWaveClient.Miscellaneous.BalanceCurrenciesAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
