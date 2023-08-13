using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;

namespace FlutterWave.Core.Tests.Integration.API.Otp
{
    public partial class OtpApiTests
    {
        [Fact]
        public async Task ShouldValidateOtpAsync()
        {

            // given
            string inputReference = "1234";
            var inputOtp = new ValidateOtp
            {
                Request = new ValidateOtpRequest
                {
                    Otp = "123456"

                }
            };

            // . when
            ValidateOtp responseAIModels =
                await this.flutterWaveClient.Otp.ValidateOtpAsync(inputReference, inputOtp);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
