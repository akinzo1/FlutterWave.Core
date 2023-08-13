using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Transaction
{
    public interface ITransactionsClient
    {
        /// <exception cref="ChatCompletionClientValidationException" />
        /// <exception cref="ChatCompletionClientDependencyException" />
        /// <exception cref="ChatCompletionClientServiceException" />
        ValueTask<CreateRefund> CreateRefundRequestAsync(
        int transactionId);

        ValueTask<MultipleRefundTransaction> RetrieveMultipleRefundsAsync(string from, string to);

        ValueTask<RefundDetails> RetrieveRefundDetailsAsync(
            string transactionId);

        ValueTask<TransactionFees> RetrieveTransactionFeesAsync(int amount, string currency);

        ValueTask<MultipleTransaction> RetrieveMultipleTransactionAsync(
            string from, string to);

        ValueTask<TransactionTimeline> RetrieveTransactionTimelineAsync(
        string transactionId);

        ValueTask<VerifyTransaction> VerifyTransactionAsync(
            int transactionId);

        ValueTask<VerifyTransaction> VerifyTransactionAsync(
            string transactionReference);
    }
}
