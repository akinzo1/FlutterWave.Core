using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;

namespace FlutterWave.Core.Tests.Integration.API.Banks
{
    public partial class BanksApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllBanksByCountryAsync()
        {

            // given
            string country = "cc";

            // . when
            Bank responseAIModels =
                await this.flutterWaveClient.Banks.RetrieveAllBanksByCountryAsync(country);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
