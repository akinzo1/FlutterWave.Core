using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeZambiaMobileMoneyAsync()
        {

            // given
            var request = new ZambiaMobileMoney
            {
                Request = new ZambiaMobileMoneyRequest
                {
                    TxRef = "MC-158523s09v5050e8",
                    Amount = 1500,
                    OrderId = "45",
                    Currency = "TZS",
                    Network = "Halopesa",
                    Email = "user@example.com",
                    PhoneNumber = "0782835136",
                    FullName = "Yolande Aglaé Colbert",
                    ClientIp = "154.123.220.1",
                    DeviceFingerprint = "62wd23423rq324323qew1",
                    Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                    {
                        FlightID = "677",

                    },
                }
            };

            // . when
            ZambiaMobileMoney responseAIModels =
                await this.flutterWaveClient.Charge.ChargeZambiaMobileMoneyAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
