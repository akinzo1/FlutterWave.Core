using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeUSSDAsync()
        {

            // given
            var request = new USSD
            {
                Request = new USSDRequest
                {
                    TxRef = "MC-15852309v5050e8y",
                    AccountBank = "057",
                    Amount = 10,
                    Currency = "NGN",
                    Email = "user@example.com",
                    PhoneNumber = "054709929220",
                    FullName = "Yolande Aglaé Colbert"
                }
            };

            // . when
            USSD responseAIModels =
                await this.flutterWaveClient.Charge.ChargeUSSDAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
