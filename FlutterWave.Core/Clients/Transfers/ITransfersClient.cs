using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Transfer
{
    public interface ITransfersClient
    {
        /// <exception cref="ChatCompletionClientValidationException" />
        /// <exception cref="ChatCompletionClientDependencyException" />
        /// <exception cref="ChatCompletionClientServiceException" />
        ValueTask<AllTransfers> RetrieveAllTransfersAsync();

        ValueTask<TransferRates> RetrieveTransferRatesAsync(
            string destinationCurrency, int amount, string sourceCurrency);

        ValueTask<TransferFees> RetrieveAllTransferFeesAsync(
            int amount);

        ValueTask<RetryTransfers> RetryTransfersAsync(
            int transactionId);

        ValueTask<FetchTransfers> RetrieveTransferAsync(
            int transactionId);

        ValueTask<FetchRetryTransfers> TransferRetryAsync(
            int transactionId);

        ValueTask<FetchBulkTransfers> RetrieveBulkTransferAsync(
            string batchId);

        ValueTask<InitiateTransfers> InitiateTransferAsync(
        InitiateTransfers transfers);

        ValueTask<BulkCreateTransfers> CreateBulkTransferAsync(
        BulkCreateTransfers transfers);
    }
}
