using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeUgandaMobileMoneyAsync()
        {

            // given
            var request = new UgandaMobileMoney
            {
                Request = new UgandaMobileMoneyRequest
                {
                    TxRef = "MC-158523s09v5050e8",
                    Amount = 150,
                    RedirectUrl = "flutterwave.com",
                    Voucher = 100,
                    Currency = "TZS",
                    Network = "Halopesa",
                    Email = "user@example.com",
                    PhoneNumber = "0782835136",
                    FullName = "Yolande Aglaé Colbert",
                    ClientIp = "154.123.220.1",
                    DeviceFingerprint = "62wd23423rq324323qew1",
                    Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                    {
                        FlightID = "677",

                    },
                }
            };

            // . when
            UgandaMobileMoney responseAIModels =
                await this.flutterWaveClient.Charge.ChargeUgandaMobileMoneyAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
