using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;

namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        [Fact]
        public async Task ShouldValidateBillServiceAsync()
        {
            // given
            string inputItemCode = "AT099";
            string inputCode = "BIL099";
            string inputCustomer = "+2348109328188";

            // when
            ValidateBillService retrievedAIModel =
                await this.flutterWaveClient.BillPayments.FetchValidateBillServiceAsync(inputItemCode, inputCode, inputCustomer);
            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}