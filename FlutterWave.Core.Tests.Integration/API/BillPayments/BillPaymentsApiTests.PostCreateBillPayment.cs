using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;

namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        [Fact]
        public async Task ShouldPostBillPaymentsAsync()
        {

            // given
            var billPayments = new PostBillPayments
            {
                Request = new CreateBillPaymentRequest
                {
                    Amount = "500",
                    Recurrence = "ONCE",
                    Type = "AIRTIME",
                    Reference = "93000494044440",
                    BillerName = "DSTV, MTN ,VTU,VODAFONE, VTU, VODAFONE POSTPAID PAYMENT",
                    Country = "NG",
                    Customer = "+23490803840303"
                }
            };

            // . when
            PostBillPayments responseAIModels =
                await this.flutterWaveClient.BillPayments.SendCreateBillPaymentAsync(billPayments);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
