using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;

namespace FlutterWave.Core.Tests.Integration.API.ChargeBacks
{
    public partial class ChargeBackApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllChargeBacksAsync()
        {

            // given

            // . when
            AllChargeBacks responseAIModels =
                await this.flutterWaveClient.ChargeBack.RetrieveAllChargeBacksAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
