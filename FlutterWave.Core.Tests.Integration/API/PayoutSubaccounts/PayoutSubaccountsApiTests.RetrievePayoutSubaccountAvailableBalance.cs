using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldPayoutSubaccountAvailableBalanceAsync()
        {
            // given
            string inputReference = "AT099";
            string inputCurrency = "BIL099";


            // when
            FetchSubaccountAvailableBalance retrievedAIModel =
                await this.flutterWaveClient.PayoutSubaccounts.RetrievePayoutSubaccountsAvailableBalanceAsync(inputReference, inputCurrency);
            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}