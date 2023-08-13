using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeUkEuBankAccountsAsync()
        {

            // given
            var request = new UkEuBankAccounts
            {
                Request = new UkEuBankAccountsRequest
                {
                    Currency = "GBP",
                    RedirectUrl = "https://flutterwave.ng",
                    Amount = 10,
                    PhoneNumber = "07086234518",
                    Email = "user@example.com",
                    TxRef = "YOUR_PAYMENT_REFERENCE",
                    FullName = "Example User",
                    IsTokenIo = 1
                }
            };

            // . when
            UkEuBankAccounts responseAIModels =
                await this.flutterWaveClient.Charge.ChargeUkEuBankAccountsAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
