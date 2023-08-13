using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeGhanaMobileMoneyAsync()
        {

            // given
            var request = new GhanaMobileMoney
            {
                Request = new GhanaMobileMoneyRequest
                {
                    TxRef = "MC-158523s09v5050e8",
                    Amount = 150,
                    Currency = "GHS",
                    Voucher = "143256743",
                    Network = "MTN",
                    Email = "user@example.com",
                    PhoneNumber = "054709929220",
                    FullName = "Yolande Aglaé Colbert",
                    ClientIp = "154.123.220.1",
                    DeviceFingerprint = "62wd23423rq324323qew1",

                    Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                    {
                        FlightID = "",

                    },


                }
            };

            // . when
            GhanaMobileMoney responseAIModels =
                await this.flutterWaveClient.Charge.ChargeGhanaMobileMoneyAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
