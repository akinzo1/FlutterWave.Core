using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalAllTransfersResponse> GetAllTransfersAsync();

        ValueTask<ExternalTransferRatesResponse> GetTransferRatesAsync(
            string destinationCurrency, int amount, string sourceCurrency);

        ValueTask<ExternalTransferFeesResponse> GetAllTransferFeesAsync(
            int amount);

        ValueTask<ExternalRetryTransferResponse> GetRetryTransfersAsync(
            int transactionId);

        ValueTask<ExternalFetchTransferResponse> GetTransferAsync(
            int transactionId);

        ValueTask<ExternalFetchTransferRetryResponse> GetTransferRetryAsync(
            int transactionId);

        ValueTask<ExternalFetchBulkTransferResponse> GetBulkTransferAsync(
            string batchId);

        ValueTask<ExternalInitiateTransferResponse> PostInitiateTransferAsync(
        ExternalInitiateTransferRequest externalInitiateTransferRequest);

        ValueTask<ExternalCreateBulkTransferResponse> PostCreateBulkTransferAsync(
        ExternalCreateBulkTransferRequest externalCreateBulkTransferRequest);


    }
}
