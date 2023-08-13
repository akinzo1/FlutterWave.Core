using FlutterWave.Core.Models.Clients.PayoutSubaccounts.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.PayoutSubaccounts
{
    internal class PayoutSubaccountsClient : IPayoutSubaccountsClient
    {
        private readonly IPayoutSubaccountsService payoutSubaccountsService;

        public PayoutSubaccountsClient(IPayoutSubaccountsService payoutSubaccountsService) =>
              this.payoutSubaccountsService = payoutSubaccountsService;

        public async ValueTask<CreatePayoutSubaccount> CreatePayoutSubaccountAsync(CreatePayoutSubaccount createPayoutSubaccount)
        {
            try
            {
                return await payoutSubaccountsService.PostCreatePayoutSubaccountRequestAsync(createPayoutSubaccount);
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreatePayoutSubaccount
                    {
                        Response = new CreatePayoutSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ListPayoutSubaccounts> RetrieveListPayoutSubaccountsAsync()
        {
            try
            {
                return await payoutSubaccountsService.GetListPayoutSubaccountsRequestAsync();
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new ListPayoutSubaccounts
                    {
                        Response = new ListPayoutSubaccountsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchPayoutSubaccount> RetrievePayoutSubaccountAsync(string accountReference)
        {
            try
            {
                return await payoutSubaccountsService.GetPayoutSubaccountRequestAsync(accountReference);
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchPayoutSubaccount
                    {
                        Response = new FetchPayoutSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchSubaccountAvailableBalance> RetrievePayoutSubaccountsAvailableBalanceAsync(string accountReference, string currency)
        {
            try
            {
                return await payoutSubaccountsService.GetPayoutSubaccountsAvailableBalanceRequestAsync(accountReference, currency);
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchSubaccountAvailableBalance
                    {
                        Response = new FetchSubaccountAvailableBalanceResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchPayoutSubaccountTransactions> RetrievePayoutSubaccountTransactionsAsync(string accountReference, string from, string to, string currency)
        {
            try
            {
                return await payoutSubaccountsService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchPayoutSubaccountTransactions
                    {
                        Response = new FetchPayoutSubaccountTransactionsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchStaticVirtualAccounts> RetrieveStaticVirtualAccountAsync(string accountReference, string currency)
        {
            try
            {
                return await payoutSubaccountsService.GetStaticVirtualAccountRequestAsync(accountReference, currency);
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchStaticVirtualAccounts
                    {
                        Response = new FetchStaticVirtualAccountsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdatePayoutSubaccount> UpdatePayoutSubaccountAsync(string accountReference, UpdatePayoutSubaccount upddatePayoutSubaccount)
        {
            try
            {
                return await payoutSubaccountsService.PostUpdatePayoutSubaccountRequestAsync(accountReference, upddatePayoutSubaccount);
            }
            catch (PayoutSubaccountsValidationException virtualCardsValidationException)
            {
                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UpdatePayoutSubaccount
                    {
                        Response = new UpdatePayoutSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new PayoutSubaccountsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsDependencyException virtualCardsDependencyException)
            {
                throw new PayoutSubaccountsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (PayoutSubaccountsServiceException payoutSubaccountsServiceException)
            {
                throw new PayoutSubaccountsClientServiceException(
                    payoutSubaccountsServiceException.InnerException as Xeption);
            }
        }
    }
}
