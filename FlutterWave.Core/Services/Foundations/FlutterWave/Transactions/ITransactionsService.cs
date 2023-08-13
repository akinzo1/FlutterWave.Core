using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TransactionsService
{
    internal interface ITransactionsService
    {
        ValueTask<CreateRefund> PostCreateRefundRequestAsync(
            int transactionId);

        ValueTask<MultipleRefundTransaction> GetMultipleRefundsAsync(string from, string to);

        ValueTask<RefundDetails> GetRefundDetailsAsync(
            string transactionId);

        ValueTask<TransactionFees> GetTransactionFeesAsync(int amount, string currency);

        ValueTask<MultipleTransaction> GetMultipleTransactionAsync(
            string from, string to);

        ValueTask<TransactionTimeline> GetTransactionTimelineAsync(
        string transactionId);

        ValueTask<VerifyTransaction> PostVerifyTransactionAsync(
            int transactionId);

        ValueTask<VerifyTransaction> PostVerifyTransactionAsync(
            string transactionReference);
    }
}
