using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeRwandaMobileMoneyAsync()
        {

            // given
            var request = new RwandaMobileMoney
            {
                Request = new RwandaMobileMoneyRequest
                {
                    TxRef = "MC-158523s09v5050e8",
                    OrderId = "USS_URG_893982923s2323",
                    Amount = 10,
                    Currency = "RWF",
                    Email = "user@example.com",
                    PhoneNumber = "054709929220",
                    FullName = "Yolande Aglaé Colbert"
                }
            };

            // . when
            RwandaMobileMoney responseAIModels =
                await this.flutterWaveClient.Charge.ChargeRwandaMobileMoneyAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
