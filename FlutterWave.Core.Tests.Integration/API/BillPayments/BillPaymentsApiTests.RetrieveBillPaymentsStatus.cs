using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;

namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveBillPaymentsStatusAsync()
        {

            // given
            string inputTransactionRefernce = "9300049404444";

            // . when
            BillPaymentsStatus responseAIModels =
                await this.flutterWaveClient.BillPayments.FetchBillStatusPaymentAsync(inputTransactionRefernce);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
