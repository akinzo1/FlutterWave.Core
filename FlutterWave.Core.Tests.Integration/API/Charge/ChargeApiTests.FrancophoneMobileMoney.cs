using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeFrancophoneMobileMoneyAsync()
        {

            // given
            var request = new FrancophoneMobileMoney
            {
                Request = new FrancophoneMobileMoneyRequest
                {
                    TxRef = "MC-158523s09v5050e8",
                    Amount = 10,
                    Currency = "XAF",
                    Country = "CM",
                    Email = "user@example.com",
                    PhoneNumber = "23700000020",
                    FullName = "Yolande Aglaé Colbert"
                }
            };

            // . when
            FrancophoneMobileMoney responseAIModels =
                await this.flutterWaveClient.Charge.ChargeFrancophoneMobileMoneyAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
