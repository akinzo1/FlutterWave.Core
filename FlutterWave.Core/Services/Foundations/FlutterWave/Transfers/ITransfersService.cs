using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TransfersService
{
    internal interface ITransfersService
    {
        ValueTask<AllTransfers> GetAllTransfersAsync();

        ValueTask<TransferRates> GetTransferRatesAsync(
            string destinationCurrency, int amount, string sourceCurrency);

        ValueTask<TransferFees> GetAllTransferFeesAsync(
            int amount);

        ValueTask<RetryTransfers> GetRetryTransfersAsync(
            int transactionId);

        ValueTask<FetchTransfers> GetTransferAsync(
            int transactionId);

        ValueTask<FetchRetryTransfers> GetTransferRetryAsync(
            int transactionId);

        ValueTask<FetchBulkTransfers> GetBulkTransferAsync(
            string batchId);

        ValueTask<InitiateTransfers> PostInitiateTransferAsync(
        InitiateTransfers initiateTransfers);

        ValueTask<BulkCreateTransfers> PostCreateBulkTransferAsync(
        BulkCreateTransfers externalCreateBulkTransferRequest);

    }
}
