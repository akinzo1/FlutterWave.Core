using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeApplePayAsync()
        {

            // given
            var request = new ApplePay
            {
                Request = new ApplePayRequest
                {
                    TxRef = "MC-TEST-123456",
                    Amount = 10,
                    Currency = "USD",
                    Email = "user@example.com",
                    FullName = "Yolande Aglaé Colbert",
                    Narration = "Test payment",
                    RedirectUrl = "http://localhost:9000/dump",
                    ClientIp = "192.168.0.1",
                    DeviceFingerprint = "gdgdhdh738bhshsjs",
                    BillingZip = "15101",
                    BillingCity = "allison park",
                    BillingAddress = "3563 Huntertown Rd",
                    BillingState = "Pennsylvania",
                    BillingCountry = "US",
                    PhoneNumber = "09012345678",

                    Meta = new ApplePayRequest.ApplePayMeta
                    {
                        Metaname = "testmeta",
                        Metavalue = "testvalue"
                    },

                }
            };

            // . when
            ApplePay responseAIModels =
                await this.flutterWaveClient.Charge.ChargeApplePayAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
