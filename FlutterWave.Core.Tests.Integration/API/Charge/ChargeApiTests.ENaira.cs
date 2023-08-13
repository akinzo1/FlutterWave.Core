using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeENairaAsync()
        {

            // given
            var request = new ENaira
            {
                Request = new ENairaRequest
                {
                    TxRef = "YOUR_PAYMENT_REFERENCE",
                    Amount = 100,
                    Currency = "NGN",
                    Email = "user@example.com",
                    FullName = "Yemi Desola",
                    PhoneNumber = "09000000000",
                    RedirectUrl = "https://example_company.com/success"


                }
            };

            // . when
            ENaira responseAIModels =
                await this.flutterWaveClient.Charge.ChargeENairaAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
