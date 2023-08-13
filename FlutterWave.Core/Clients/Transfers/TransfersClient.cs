using FlutterWave.Core.Models.Clients.Transfers.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using FlutterWave.Core.Services.Foundations.FlutterWave.TransfersService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Transfer
{
    internal class TransfersClient : ITransfersClient
    {
        private readonly ITransfersService transfersService;

        public TransfersClient(ITransfersService transfersService) =>
              this.transfersService = transfersService;

        public async ValueTask<TransferFees> RetrieveAllTransferFeesAsync(int amount)
        {
            try
            {
                return await transfersService.GetAllTransferFeesAsync(amount);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new TransferFees
                    {
                        Response = new TransferFeesResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AllTransfers> RetrieveAllTransfersAsync()
        {
            try
            {
                return await transfersService.GetAllTransfersAsync();
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new AllTransfers
                    {
                        Response = new AllTransfersResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchBulkTransfers> RetrieveBulkTransferAsync(string batchId)
        {
            try
            {
                return await transfersService.GetBulkTransferAsync(batchId);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchBulkTransfers
                    {
                        Response = new FetchBulkTransferResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<RetryTransfers> RetryTransfersAsync(int transactionId)
        {
            try
            {
                return await transfersService.GetRetryTransfersAsync(transactionId);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new RetryTransfers
                    {
                        Response = new RetryTransferResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchTransfers> RetrieveTransferAsync(int transactionId)
        {
            try
            {
                return await transfersService.GetTransferAsync(transactionId);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchTransfers
                    {
                        Response = new FetchTransferResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TransferRates> RetrieveTransferRatesAsync(string destinationCurrency, int amount, string sourceCurrency)
        {
            try
            {
                return await transfersService.GetTransferRatesAsync(destinationCurrency, amount, sourceCurrency);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new TransferRates
                    {
                        Response = new TransferRatesResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchRetryTransfers> TransferRetryAsync(int transactionId)
        {
            try
            {
                return await transfersService.GetTransferRetryAsync(transactionId);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchRetryTransfers
                    {
                        Response = new FetchTransferRetryResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BulkCreateTransfers> CreateBulkTransferAsync(BulkCreateTransfers transfers)
        {
            try
            {
                return await transfersService.PostCreateBulkTransferAsync(transfers);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BulkCreateTransfers
                    {
                        Response = new CreateBulkTransferResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<InitiateTransfers> InitiateTransferAsync(InitiateTransfers transfers)
        {
            try
            {
                return await transfersService.PostInitiateTransferAsync(transfers);
            }
            catch (TransfersValidationException TransactionValidationException)
            {
                throw new TransfersClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new InitiateTransfers
                    {
                        Response = new InitiateTransferResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransfersClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransfersDependencyException TransactionDependencyException)
            {
                throw new TransfersClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransfersServiceException TransactionServiceException)
            {
                throw new TransfersClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }
    }
}
