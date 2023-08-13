using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalBillCategoriesResponse> GetBillCategoriesAsync()
        {
            return await GetAsync<ExternalBillCategoriesResponse>(
                   relativeUrl: $"v3/bill-categories");
        }

        public async ValueTask<ExternalValidateBillServiceResponse> GetValidateBillServiceAsync(
            string itemCode, string code, string customer)
        {
            return await GetAsync<ExternalValidateBillServiceResponse>(
                  relativeUrl: $"v3/bill-items/{itemCode}/validate?code={code}&customer={customer}");
        }

        public async ValueTask<ExternalCreateBillPaymentResponse> PostCreateBillPaymentAsync(
            ExternalCreateBillPaymentRequest externalCreateBillPaymentRequest)
        {
            return await PostAsync<ExternalCreateBillPaymentRequest, ExternalCreateBillPaymentResponse>(
                             relativeUrl: $"v3/bills",
                             content: externalCreateBillPaymentRequest
                             );
        }

        public async ValueTask<ExternalBulkBillPaymentsResponse> PostCreateBulkBillAsync(
          ExternalBulkBillPaymentsRequest externalBulkBillPaymentsRequest)
        {
            return await PostAsync<ExternalBulkBillPaymentsRequest, ExternalBulkBillPaymentsResponse>(
                                   relativeUrl: $"v3/bulk-bills",
                                   content: externalBulkBillPaymentsRequest
                                   );
        }

        public async ValueTask<ExternalBillStatusPaymentResponse> GetBillStatusPaymentAsync(
            string reference)
        {
            return await GetAsync<ExternalBillStatusPaymentResponse>(
                  relativeUrl: $"v3/bills/{reference}");
        }

        public async ValueTask<ExternalBillPaymentsResponse> GetBillPaymentsAsync()
        {
            return await GetAsync<ExternalBillPaymentsResponse>(
                 relativeUrl: $"v3/bills");
        }
    }
}
