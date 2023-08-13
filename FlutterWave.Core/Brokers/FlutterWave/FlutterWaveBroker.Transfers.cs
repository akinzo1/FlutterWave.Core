using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {
        public async ValueTask<ExternalAllTransfersResponse> GetAllTransfersAsync()
        {
            return await GetAsync<ExternalAllTransfersResponse>(
               relativeUrl: "v3/transfers");
        }

        public async ValueTask<ExternalTransferRatesResponse> GetTransferRatesAsync(
            string destinationCurrency, int amount, string sourceCurrency)
        {
            return await GetAsync<ExternalTransferRatesResponse>(
            relativeUrl: $"v3/transfers/rates?amount={amount}&destination_currency={destinationCurrency}&source_currency={sourceCurrency}");
        }

        public async ValueTask<ExternalTransferFeesResponse> GetAllTransferFeesAsync(
            int amount)
        {
            return await GetAsync<ExternalTransferFeesResponse>(
              relativeUrl: $"v3/transfers/fee?amount={amount}");
        }


        public async ValueTask<ExternalFetchTransferResponse> GetTransferAsync(
            int transactionId)
        {
            return await GetAsync<ExternalFetchTransferResponse>(
            relativeUrl: $"v3/transfers/{transactionId}");
        }

        public async ValueTask<ExternalFetchTransferRetryResponse> GetTransferRetryAsync(
             int transactionId)
        {
            return await GetAsync<ExternalFetchTransferRetryResponse>(
               relativeUrl: $"v3/transfers/{transactionId}/retries");
        }

        public async ValueTask<ExternalFetchBulkTransferResponse> GetBulkTransferAsync(
             string batchId)
        {
            return await GetAsync<ExternalFetchBulkTransferResponse>(
            relativeUrl: $"v3/transfers?{batchId}");
        }

        public async ValueTask<ExternalInitiateTransferResponse> PostInitiateTransferAsync(
               ExternalInitiateTransferRequest externalInitiateTransferRequest)
        {
            return await PostAsync<ExternalInitiateTransferRequest, ExternalInitiateTransferResponse>(
               relativeUrl: "v3/transfers",
               content: externalInitiateTransferRequest);
        }

        public async ValueTask<ExternalCreateBulkTransferResponse> PostCreateBulkTransferAsync(
        ExternalCreateBulkTransferRequest externalCreateBulkTransferRequest)
        {
            return await PostAsync<ExternalCreateBulkTransferRequest, ExternalCreateBulkTransferResponse>(
                     relativeUrl: "v3/bulk-transfers",
                     content: externalCreateBulkTransferRequest);
        }

        public async ValueTask<ExternalRetryTransferResponse> GetRetryTransfersAsync(int transactionId)
        {
            return await PostAsync<ExternalRetryTransferResponse>(
                     relativeUrl: $"v3/transfers/{transactionId}/retries",
                     content: null);
        }
    }
}
