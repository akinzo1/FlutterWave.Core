using FlutterWave.Core.Models.Clients.CollectionSubaccounts.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.CollectionSubaccounts
{
    internal class CollectionSubaccountsClient : ICollectionSubaccountsClient
    {
        private readonly ICollectionSubaccountsService collectionSubaccountsService;

        public CollectionSubaccountsClient(ICollectionSubaccountsService collectionSubaccountsService) =>
              this.collectionSubaccountsService = collectionSubaccountsService;

        public async ValueTask<CreateCollectionSubaccount> CreateCollectionSubaccountAsync(CreateCollectionSubaccount createCollectionSubaccount)
        {
            try
            {
                return await collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(createCollectionSubaccount);
            }
            catch (CollectionSubaccountsValidationException collectionSubaccountsValidationException)
            {
                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyValidationException collectionSubaccountsDependencyValidationException)
            {

                var message = collectionSubaccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateCollectionSubaccount
                    {
                        Response = new CreateCollectionSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyException collectionSubaccountsDependencyException)
            {
                throw new CollectionSubaccountsClientDependencyException(
                    collectionSubaccountsDependencyException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsServiceException collectionSubaccountsServiceException)
            {
                throw new CollectionSubaccountsClientServiceException(
                    collectionSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DeleteSubaccount> DeleteCollectionSubaccountAsync(int subaccountId)
        {
            try
            {
                return await collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(subaccountId);
            }
            catch (CollectionSubaccountsValidationException collectionSubaccountsValidationException)
            {
                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyValidationException collectionSubaccountsDependencyValidationException)
            {

                var message = collectionSubaccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new DeleteSubaccount
                    {
                        Response = new DeleteSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyException collectionSubaccountsDependencyException)
            {
                throw new CollectionSubaccountsClientDependencyException(
                    collectionSubaccountsDependencyException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsServiceException collectionSubaccountsServiceException)
            {
                throw new CollectionSubaccountsClientServiceException(
                    collectionSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchSubaccount> RetrieveSubaccountAsync(int subaccountId)
        {
            try
            {
                return await collectionSubaccountsService.GetSubaccountRequestAsync(subaccountId);
            }
            catch (CollectionSubaccountsValidationException collectionSubaccountsValidationException)
            {
                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyValidationException collectionSubaccountsDependencyValidationException)
            {

                var message = collectionSubaccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchSubaccount
                    {
                        Response = new FetchSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyException collectionSubaccountsDependencyException)
            {
                throw new CollectionSubaccountsClientDependencyException(
                    collectionSubaccountsDependencyException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsServiceException collectionSubaccountsServiceException)
            {
                throw new CollectionSubaccountsClientServiceException(
                    collectionSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchSubaccounts> RetrieveSubaccountsAsync()
        {
            try
            {
                return await collectionSubaccountsService.GetSubaccountsRequestAsync();
            }
            catch (CollectionSubaccountsValidationException collectionSubaccountsValidationException)
            {
                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyValidationException collectionSubaccountsDependencyValidationException)
            {

                var message = collectionSubaccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchSubaccounts
                    {
                        Response = new FetchSubaccountsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyException collectionSubaccountsDependencyException)
            {
                throw new CollectionSubaccountsClientDependencyException(
                    collectionSubaccountsDependencyException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsServiceException collectionSubaccountsServiceException)
            {
                throw new CollectionSubaccountsClientServiceException(
                    collectionSubaccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateSubaccount> UpdateCollectionSubaccountAsync(int subaccountId, UpdateSubaccount updateSubaccount)
        {
            try
            {
                return await collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, updateSubaccount);
            }
            catch (CollectionSubaccountsValidationException collectionSubaccountsValidationException)
            {
                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyValidationException collectionSubaccountsDependencyValidationException)
            {

                var message = collectionSubaccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UpdateSubaccount
                    {
                        Response = new UpdateSubaccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new CollectionSubaccountsClientValidationException(
                    collectionSubaccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsDependencyException collectionSubaccountsDependencyException)
            {
                throw new CollectionSubaccountsClientDependencyException(
                    collectionSubaccountsDependencyException.InnerException as Xeption);
            }
            catch (CollectionSubaccountsServiceException collectionSubaccountsServiceException)
            {
                throw new CollectionSubaccountsClientServiceException(
                    collectionSubaccountsServiceException.InnerException as Xeption);
            }
        }
    }
}
