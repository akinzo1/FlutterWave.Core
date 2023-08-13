using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;

namespace FlutterWave.Core.Tests.Integration.API.BillPayment
{
    public partial class BillPaymentsApiTests
    {
        [Fact]
        public async Task ShouldPostBulkPaymentsAsync()
        {

            // given
            var bulkBillPayments = new BulkBillPayments
            {
                Request = new BulkBillPaymentsRequest
                {
                    CallbackUrl = "https://webhook.site/5f9a659a-11a2-4925-89cf-8a59ea6a019a",
                    BulkReference = "edf-12de5223d2f32",
                    BulkData = new List<BulkBillPaymentsRequest.BulkDatum>
                  {
                     new BulkBillPaymentsRequest.BulkDatum
                     {
                          Country = "NG",
                          Customer = "+23490803840303",
                          Amount = 500,
                          Recurrence = "WEEKLY",
                          Type = "AIRTIME",
                          Reference = "930049200929",
                     },
                     new BulkBillPaymentsRequest.BulkDatum
                     {
                          Country = "NG",
                          Customer = "+23490803840304",
                          Amount = 500,
                          Recurrence = "WEEKLY",
                          Type = "AIRTIME",
                          Reference = "930004912332",
                                         }
                  }
                }
            };

            // . when
            BulkBillPayments responseAIModels =
                await this.flutterWaveClient.BillPayments.SendCreateBulkBillAsync(bulkBillPayments);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
