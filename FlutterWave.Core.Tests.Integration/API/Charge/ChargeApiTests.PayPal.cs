using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargePayPalAsync()
        {

            // given
            var request = new PayPal
            {
                Request = new PayPalRequest
                {
                    TxRef = "PayPalv3Test03",
                    Amount = 10,
                    Currency = "USD",
                    Country = "US",
                    Email = "dovedom221@vss6.com",
                    PhoneNumber = "054222234847",
                    FullName = "John Madakin",
                    ClientIp = "154.123.220.1",
                    RedirectUrl = "http://johnmadakin.com/u/payment-completed",
                    DeviceFingerprint = "62wd23423rq324323qew1",
                    BillingAddress = "3563 Huntertown Rd",
                    BillingCity = "Allison park",
                    BillingZip = "15101",
                    BillingState = "Pensylvannia",
                    BillingCountry = "US",
                    ShippingName = "Robert K Gagne",
                    ShippingAddress = "1010  Woodrow Way",
                    ShippingCity = "Lufkin",
                    ShippingZip = "75904",
                    ShippingState = "Texas",
                    ShippingCountry = "US"
                }
            };

            // . when
            PayPal responseAIModels =
                await this.flutterWaveClient.Charge.ChargePayPalAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
