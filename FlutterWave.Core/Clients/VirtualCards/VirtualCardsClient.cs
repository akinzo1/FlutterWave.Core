using FlutterWave.Core.Models.Clients.VirtualCards.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using FlutterWave.Core.Services.Foundations.FlutterWave.VirtualCardsService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.VirtualCards
{
    internal class VirtualCardsClient : IVirtualCardsClient
    {
        private readonly IVirtualCardsService virtualCardsService;

        public VirtualCardsClient(IVirtualCardsService virtualCardsService) =>
              this.virtualCardsService = virtualCardsService;

        public async ValueTask<CreateVirtualCard> CreateVirtualCardAsync(CreateVirtualCard createVirtualCard)
        {
            try
            {
                return await virtualCardsService.PostCreateVirtualCardRequestAsync(createVirtualCard);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateVirtualCard
                    {
                        Response = new CreateVirtualCardResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchVirtualCard> RetrieveVirtualCardAsync(string virtualCardId)
        {
            try
            {
                return await virtualCardsService.GetVirtualCardRequestAsync(virtualCardId);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchVirtualCard
                    {
                        Response = new FetchVirtualCardResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VirtualCardTransactions> GetVirtualCardTransactionsAsync(string virtualCardId)
        {
            try
            {
                return await virtualCardsService.GetVirtualCardTransactionsRequestAsync(virtualCardId);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new VirtualCardTransactions
                    {
                        Response = new VirtualCardTransactionsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BlockUnblockVirtualCard> PostBlockUnblockVirtualCardAsync(string virtualCardId, string statusAction)
        {
            try
            {
                return await virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(virtualCardId, statusAction);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BlockUnblockVirtualCard
                    {
                        Response = new BlockUnblockVirtualCardResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FundVirtualCard> PostFundVirtualCardAsync(string virtualCardId, FundVirtualCard fundVirtualCard)
        {
            try
            {
                return await virtualCardsService.PostFundVirtualCardRequestAsync(virtualCardId, fundVirtualCard);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FundVirtualCard
                    {
                        Response = new FundVirtualCardResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TerminateVirtualCard> TerminateVirtualCardAsync(string virtualCardId)
        {
            try
            {
                return await virtualCardsService.PostTerminateVirtualCardRequestAsync(virtualCardId);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new TerminateVirtualCard
                    {
                        Response = new TerminateVirtualCardResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<VirtualCardWithdrawal> VirtualCardWithdrawalAsync(string virtualCardId, VirtualCardWithdrawal fundVirtualCard)
        {
            try
            {
                return await virtualCardsService.PostVirtualCardWithdrawalRequestAsync(virtualCardId, fundVirtualCard);
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new VirtualCardWithdrawal
                    {
                        Response = new VirtualCardWithdrawalResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchVirtualCards> RetrieveVirtualCardsAsync()
        {
            try
            {
                return await virtualCardsService.GetVirtualCardsRequestAsync();
            }
            catch (VirtualCardsValidationException virtualCardsValidationException)
            {
                throw new VirtualCardsClientValidationException(
                    virtualCardsValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyValidationException virtualCardsDependencyValidationException)
            {

                var message = virtualCardsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchVirtualCards
                    {
                        Response = new FetchVirtualCardsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualCardsClientValidationException(
                    virtualCardsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualCardsDependencyException virtualCardsDependencyException)
            {
                throw new VirtualCardsClientDependencyException(
                    virtualCardsDependencyException.InnerException as Xeption);
            }
            catch (VirtualCardsServiceException virtualCardsServiceException)
            {
                throw new VirtualCardsClientServiceException(
                    virtualCardsServiceException.InnerException as Xeption);
            }
        }
    }
}
