using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;

namespace FlutterWave.Core.Tests.Integration.API.Miscellaneous
{
    public partial class MiscellaneousApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBalanceByCurrencyAsync()
        {
            // given
            string inputCurrencyCode = "NG";


            // when
            BalanceByCurrency retrievedAIModel =
              await this.flutterWaveClient.Miscellaneous.BalanceByCurrencyAsync(inputCurrencyCode);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}