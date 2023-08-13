using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldPostVoidChargeAsync()
        {

            // given
            var flwRef = "1234";

            // . when
            VoidCharge responseAIModels =
                await this.flutterWaveClient.Preauthorization.VoidChargeAsync(flwRef);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
