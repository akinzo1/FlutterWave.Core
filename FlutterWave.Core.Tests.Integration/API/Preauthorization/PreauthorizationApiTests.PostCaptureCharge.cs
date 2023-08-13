using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        [Fact]
        public async Task ShouldPostCaptureChargeAsync()
        {

            // given
            var request = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = 12,

                }
            };

            var flwRef = "1234";
            // . when
            CaptureCharge responseAIModels =
                await this.flutterWaveClient.Preauthorization.CaptureChargeAsync(flwRef, request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
