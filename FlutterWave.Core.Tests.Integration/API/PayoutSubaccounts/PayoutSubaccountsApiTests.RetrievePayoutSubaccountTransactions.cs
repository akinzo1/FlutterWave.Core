using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldPayoutSubaccountTransactionsAsync()
        {
            // given
            string inputReference = "AT099";
            string inputCurrency = "BIL099";
            string inputFrom = "AT099";
            string inputTo = "BIL099";

            // when
            FetchPayoutSubaccountTransactions retrievedAIModel =
                await this.flutterWaveClient.PayoutSubaccounts.RetrievePayoutSubaccountTransactionsAsync(inputReference, inputFrom, inputTo, inputCurrency);
            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}