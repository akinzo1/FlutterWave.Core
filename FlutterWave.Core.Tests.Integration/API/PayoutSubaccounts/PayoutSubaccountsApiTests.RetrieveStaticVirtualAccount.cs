using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveStaticVirtualAccountAsync()
        {
            // given
            string inputReference = "AT099";
            string inputCurrency = "BIL099";


            // when
            FetchStaticVirtualAccounts retrievedAIModel =
                await this.flutterWaveClient.PayoutSubaccounts.RetrieveStaticVirtualAccountAsync(inputReference, inputCurrency);
            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}