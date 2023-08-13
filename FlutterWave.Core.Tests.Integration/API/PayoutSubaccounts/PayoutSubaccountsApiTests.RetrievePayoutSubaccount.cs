using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrievePayoutSubaccountStatusAsync()
        {

            // given
            string inputTransactionRefernce = "9300049404444";

            // . when
            FetchPayoutSubaccount responseAIModels =
                await this.flutterWaveClient.PayoutSubaccounts.RetrievePayoutSubaccountAsync(inputTransactionRefernce);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
