using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldPostCreatePayoutSubaccountAsync()
        {

            // given
            var request = new CreatePayoutSubaccount
            {
                Request = new CreatePayoutSubaccountRequest
                {
                    AccountName = "John Doe",
                    Email = "developers@flutterwavego.com",
                    MobileNumber = "010101010",
                    Country = "US",
                    AccountReference = "uuyyuprer",
                    BankCode = 044,
                    BarterId = "12345",
                }
            };

            // . when
            CreatePayoutSubaccount responseAIModels =
                await this.flutterWaveClient.PayoutSubaccounts.CreatePayoutSubaccountAsync(request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
