using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeFawryAsync()
        {

            // given
            var request = new Fawry
            {
                Request = new FawryRequest
                {
                    TxRef = "fawrySample1",
                    Amount = 10,
                    Email = "user@flw.com",
                    Currency = "EGP",
                    PhoneNumber = "09012345678",
                    RedirectUrl = "https://www.flutterwave.com",

                    Meta = new FawryRequest.FawryMeta
                    {
                        Name = "Cornelius",
                        Tools = "Postman"
                    },


                }
            };

            // . when
            Fawry responseAIModels =
                await this.flutterWaveClient.Charge.ChargeFawryAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
