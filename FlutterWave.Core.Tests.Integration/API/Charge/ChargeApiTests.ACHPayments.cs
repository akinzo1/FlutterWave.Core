using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeACHPaymentsAsync()
        {

            // given
            var request = new ACHPayments
            {
                Request = new ACHPaymentsRequest
                {
                    TxRef = "MC-1585230ew9v5050e8",
                    Amount = 100,
                    Currency = "USD",
                    Country = "US",
                    Email = "user@example.com",
                    PhoneNumber = "0902620185",
                    FullName = "Yolande Aglaé Colbert",
                    ClientIp = "154.123.220.1",
                    RedirectUrl = "https://www.flutterwave.com/us/",
                    DeviceFingerprint = "62wd23423rq324323qew1",

                    Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                    {
                        FlightID = "123949494DC",
                    },


                }
            };

            // . when
            ACHPayments responseAIModels =
                await this.flutterWaveClient.Charge.ChargeACHPaymentsAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
