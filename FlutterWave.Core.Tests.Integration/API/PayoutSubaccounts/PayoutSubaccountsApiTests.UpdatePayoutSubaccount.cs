using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldPostUpdatePayoutSubaccountAsync()
        {

            // given
            var request = new UpdatePayoutSubaccount
            {
                Request = new UpdatePayoutSubaccountRequest
                {
                    AccountName = "Flutterwave Developers",
                    Email = "developers@flutterwavego.com",
                    MobileNumber = "010101010",
                    Country = "NG"
                }
            };

            var accountReference = "1234";
            // . when
            UpdatePayoutSubaccount responseAIModels =
                await this.flutterWaveClient.PayoutSubaccounts.UpdatePayoutSubaccountAsync(accountReference, request);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
