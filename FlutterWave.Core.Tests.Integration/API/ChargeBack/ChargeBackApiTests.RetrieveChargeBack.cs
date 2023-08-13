using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;

namespace FlutterWave.Core.Tests.Integration.API.ChargeBacks
{
    public partial class ChargeBackApiTests
    {
        [Fact]
        public async Task ShouldRetrieveChargeAsync()
        {
            // given
            string inputFlutterWaveReference = "yuyutr";

            // when
            ChargeBack retrievedAIModel =
              await this.flutterWaveClient.ChargeBack.RetrieveChargeBackAsync(inputFlutterWaveReference);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}