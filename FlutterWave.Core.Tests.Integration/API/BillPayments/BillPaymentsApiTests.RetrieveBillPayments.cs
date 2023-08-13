using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;

namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBillPaymentsAsync()
        {

            // given


            // . when
            BillPayments responseAIModels =
                await this.flutterWaveClient.BillPayments.FetchBillPaymentsAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
