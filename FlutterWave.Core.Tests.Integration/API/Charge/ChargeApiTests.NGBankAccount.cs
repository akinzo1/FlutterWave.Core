using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;

namespace FlutterWave.Core.Tests.Integration.API.Charge
{
    public partial class ChargeApiTests
    {
        [Fact]
        public async Task ShouldPostChargeNGBankAccountsAsync()
        {

            // given
            var request = new NGBankAccounts
            {
                Request = new NGBankAccountsRequest
                {
                    TxRef = "MC-1585230ew9v5050e8",
                    Amount = 100,
                    AccountBank = "044",
                    AccountNumber = "0690000032",
                    Currency = "NGN",
                    Email = "user@example.com",
                    PhoneNumber = "0902620185",
                    FullName = "Yolande Aglaé Colbert"
                }
            };

            // . when
            NGBankAccounts responseAIModels =
                await this.flutterWaveClient.Charge.ChargeNGBankAccountAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
