using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService
{
    internal interface IBillPaymentService
    {
        ValueTask<BillCategories> GetBillCategoriesAsync();

        ValueTask<ValidateBillService> GetValidateBillServiceAsync(
            string itemCode, string code, string customer);

        ValueTask<PostBillPayments> PostCreateBillPaymentAsync(
            PostBillPayments billPayments);

        ValueTask<BulkBillPayments> PostCreateBulkBillAsync(
          BulkBillPayments billPayments);

        ValueTask<BillPaymentsStatus> GetBillStatusPaymentAsync(
            string reference);

        ValueTask<BillPayments> GetBillPaymentsAsync();
    }
}
