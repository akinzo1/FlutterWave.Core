using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalCreateRefundResponse> PostCreateRefundRequestAsync(
        int transactionId)
        {
            return await PostAsync<ExternalCreateRefundResponse>(
           relativeUrl: $"v3/transactions/{transactionId}/refund", content: null);
        }

        public async ValueTask<ExternalFetchMultipleTransactionsResponse> GetMultipleRefundsAsync(string from, string to)
        {
            return await GetAsync<ExternalFetchMultipleTransactionsResponse>(
            relativeUrl: $"v3/refunds?from={from}&to={to}");
        }

        public async ValueTask<ExternalFetchRefundDetailsResponse> GetRefundDetailsAsync(
            string transactionId)
        {
            return await GetAsync<ExternalFetchRefundDetailsResponse>(
                       relativeUrl: $"v3/refunds/{transactionId}");
        }

        public async ValueTask<ExternalFetchTransactionFeesResponse> GetTransactionFeesAsync(int amount, string currency)
        {
            return await GetAsync<ExternalFetchTransactionFeesResponse>(
                        relativeUrl: $"v3/transactions/fee?from={amount}&to={currency}");
        }

        public async ValueTask<ExternalMultipleTransactionResponse> GetMultipleTransactionAsync(
            string from, string to)
        {
            return await GetAsync<ExternalMultipleTransactionResponse>(
            relativeUrl: $"v3/transactions?from={from}&to={to}");
        }

        public async ValueTask<ExternalTransactionTimelineResponse> GetTransactionTimelineAsync(
        string transactionId)
        {
            return await GetAsync<ExternalTransactionTimelineResponse>(
                       relativeUrl: $"v3/transactions/{transactionId}/events");
        }

        public async ValueTask<ExternalVerifyTransactionResponse> PostVerifyTransactionAsync(
            int transactionId)
        {
            return await GetAsync<ExternalVerifyTransactionResponse>(
                   relativeUrl: $"v3/transactions/{transactionId}/verify");
        }

        public async ValueTask<ExternalVerifyTransactionResponse> PostVerifyTransactionAsync(
            string transactionReference)
        {
            return await GetAsync<ExternalVerifyTransactionResponse>(
            relativeUrl: $"v3/transactions/{transactionReference}/verify");
        }
    }
}
