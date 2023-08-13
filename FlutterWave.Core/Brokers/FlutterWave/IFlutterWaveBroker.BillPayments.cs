using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {

        ValueTask<ExternalBillCategoriesResponse> GetBillCategoriesAsync();

        ValueTask<ExternalValidateBillServiceResponse> GetValidateBillServiceAsync(
            string itemCode, string code, string customer);

        ValueTask<ExternalCreateBillPaymentResponse> PostCreateBillPaymentAsync(
            ExternalCreateBillPaymentRequest externalCreateBillPaymentRequest);

        ValueTask<ExternalBulkBillPaymentsResponse> PostCreateBulkBillAsync(
          ExternalBulkBillPaymentsRequest externalBulkBillPaymentsRequest);

        ValueTask<ExternalBillStatusPaymentResponse> GetBillStatusPaymentAsync(
            string reference);

        ValueTask<ExternalBillPaymentsResponse> GetBillPaymentsAsync();

    }


}
