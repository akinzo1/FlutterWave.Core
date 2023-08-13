using FlutterWave.Core.Models.Clients.Transactions.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using FlutterWave.Core.Services.Foundations.FlutterWave.TransactionsService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Transaction
{
    internal class TransactionsClient : ITransactionsClient
    {
        private readonly ITransactionsService transactionsService;

        public TransactionsClient(ITransactionsService transactionsService) =>
              this.transactionsService = transactionsService;

        public async ValueTask<MultipleRefundTransaction> RetrieveMultipleRefundsAsync(string from, string to)
        {
            try
            {
                return await transactionsService.GetMultipleRefundsAsync(from, to);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new MultipleRefundTransaction
                    {
                        Response = new FetchMultipleRefundTransactionResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MultipleTransaction> RetrieveMultipleTransactionAsync(string from, string to)
        {
            try
            {
                return await transactionsService.GetMultipleTransactionAsync(from, to);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new MultipleTransaction
                    {
                        Response = new FetchMultipleTransactionResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<RefundDetails> RetrieveRefundDetailsAsync(string transactionId)
        {
            try
            {
                return await transactionsService.GetRefundDetailsAsync(transactionId);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new RefundDetails
                    {
                        Response = new FetchRefundDetailsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TransactionFees> RetrieveTransactionFeesAsync(int amount, string currency)
        {
            try
            {
                return await transactionsService.GetTransactionFeesAsync(amount, currency);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new TransactionFees
                    {
                        Response = new FetchTransactionFeesResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TransactionTimeline> RetrieveTransactionTimelineAsync(string transactionId)
        {
            try
            {
                return await transactionsService.GetTransactionTimelineAsync(transactionId);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new TransactionTimeline
                    {
                        Response = new TransactionTimelineResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateRefund> CreateRefundRequestAsync(int transactionId)
        {
            try
            {
                return await transactionsService.PostCreateRefundRequestAsync(transactionId);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateRefund
                    {
                        Response = new CreateRefundResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VerifyTransaction> VerifyTransactionAsync(int transactionId)
        {
            try
            {
                return await transactionsService.PostVerifyTransactionAsync(transactionId);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new VerifyTransaction
                    {
                        Response = new VerifyTransactionResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VerifyTransaction> VerifyTransactionAsync(string transactionReference)
        {
            try
            {
                return await transactionsService.PostVerifyTransactionAsync(transactionReference);
            }
            catch (TransactionsValidationException TransactionValidationException)
            {
                throw new TransactionsClientValidationException(
                    TransactionValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyValidationException TransactionDependencyValidationException)
            {

                var message = TransactionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new VerifyTransaction
                    {
                        Response = new VerifyTransactionResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TransactionsClientValidationException(
                    TransactionDependencyValidationException.InnerException as Xeption);
            }
            catch (TransactionsDependencyException TransactionDependencyException)
            {
                throw new TransactionsClientDependencyException(
                    TransactionDependencyException.InnerException as Xeption);
            }
            catch (TransactionsServiceException TransactionServiceException)
            {
                throw new TransactionsClientServiceException(
                    TransactionServiceException.InnerException as Xeption);
            }
        }
    }
}
