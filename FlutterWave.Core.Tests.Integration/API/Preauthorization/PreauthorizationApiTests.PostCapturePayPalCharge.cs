using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        [Fact]
        public async Task ShouldPostCapturePayPalChargeAsync()
        {

            // given
            var request = new CapturePayPalCharge
            {
                Request = new CapturePayPalChargeRequest
                {
                    FlwRef = "1234",

                }
            };


            // . when
            CapturePayPalCharge responseAIModels =
                await this.flutterWaveClient.Preauthorization.CapturePayPalChargeAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
