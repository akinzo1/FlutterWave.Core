using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;

namespace FlutterWave.Core.Tests.Integration.API.PayoutSubaccounts
{
    public partial class PayoutSubaccountsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveListPayoutSubaccountsAsync()
        {

            // given


            // . when
            ListPayoutSubaccounts responseAIModels =
                await this.flutterWaveClient.PayoutSubaccounts.RetrieveListPayoutSubaccountsAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
