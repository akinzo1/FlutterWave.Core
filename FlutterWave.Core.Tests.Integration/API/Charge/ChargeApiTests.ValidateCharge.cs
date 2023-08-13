using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostValidateChargeAsync()
        {

            // given
            var request = new ValidateCharge
            {
                Request = new ValidateChargeRequest
                {
                    FlwRef = "FLW275407301",
                    Otp = "123456",
                    Type = "card",
                }
            };

            // . when
            ValidateCharge responseAIModels =
                await this.flutterWaveClient.Charge.ValidateChargeAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
