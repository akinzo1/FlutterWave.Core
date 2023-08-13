using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;

namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBillCategoriesAsync()
        {

            // given


            // . when
            BillCategories responseAIModels =
                await this.flutterWaveClient.BillPayments.FetchBillCategoriesAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
