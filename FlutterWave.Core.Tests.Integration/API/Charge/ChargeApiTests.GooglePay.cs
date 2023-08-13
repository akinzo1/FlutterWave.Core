using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeGooglePayAsync()
        {

            // given
            var request = new GooglePay
            {
                Request = new GooglePayRequest
                {

                    TxRef = "MC-TEST-1234568_success_mock",
                    Amount = 10,
                    Currency = "USD",
                    Email = "user@example.com",
                    FullName = "Yolande Aglaé Colbert",
                    Narration = "Test Google Pay charge",
                    RedirectUrl = "http://localhost:9000/dump",
                    ClientIp = "192.168.0.1",
                    DeviceFingerprint = "gdgdhdh738bhshsjs",
                    BillingZip = "15101",
                    BillingCity = "allison park",
                    BillingAddress = "3563 Huntertown Rd",
                    BillingState = "Pennsylvania",
                    BillingCountry = "US",


                    Meta = new GooglePayRequest.GooglePayMeta
                    {
                        MetaName = "oo",
                        MetaValue = "uuj"
                    },

                }
            };

            // . when
            GooglePay responseAIModels =
                await this.flutterWaveClient.Charge.ChargeGooglePayAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
