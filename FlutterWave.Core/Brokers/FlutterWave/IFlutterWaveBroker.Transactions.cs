using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalCreateRefundResponse> PostCreateRefundRequestAsync(
        int transactionId);

        ValueTask<ExternalFetchMultipleTransactionsResponse> GetMultipleRefundsAsync(string from, string to);

        ValueTask<ExternalFetchRefundDetailsResponse> GetRefundDetailsAsync(
            string transactionId);

        ValueTask<ExternalFetchTransactionFeesResponse> GetTransactionFeesAsync(int amount, string currency);

        ValueTask<ExternalMultipleTransactionResponse> GetMultipleTransactionAsync(
            string from, string to);

        ValueTask<ExternalTransactionTimelineResponse> GetTransactionTimelineAsync(
        string transactionId);

        ValueTask<ExternalVerifyTransactionResponse> PostVerifyTransactionAsync(
            int transactionId);

        ValueTask<ExternalVerifyTransactionResponse> PostVerifyTransactionAsync(
            string transactionReference);
    }


}
