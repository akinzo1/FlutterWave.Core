using FlutterWave.Core.Models.Clients.VirtualAccounts.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccount;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.VirtualAccount
{
    internal class VirtualAccountsClient : IVirtualAccountsClient
    {
        private readonly IVirtualAccountsService virtualAccountsService;

        public VirtualAccountsClient(IVirtualAccountsService virtualAccountsService) =>
              this.virtualAccountsService = virtualAccountsService;

        public async ValueTask<BulkVirtualAccountDetails> RetrieveBulkVirtualAccountDetailsAsync(string batchId)
        {
            try
            {
                return await virtualAccountsService.GetVirtualAccountDetailsRequestAsync(batchId);
            }
            catch (VirtualAccountsValidationException virtualAccountsValidationException)
            {
                throw new VirtualAccountsClientValidationException(
                    virtualAccountsValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyValidationException virtualAccountsDependencyValidationException)
            {

                var message = virtualAccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BulkVirtualAccountDetails
                    {
                        Response = new BulkVirtualAccountDetailsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualAccountsClientValidationException(
                    virtualAccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyException virtualAccountsDependencyException)
            {
                throw new VirtualAccountsClientDependencyException(
                    virtualAccountsDependencyException.InnerException as Xeption);
            }
            catch (VirtualAccountsServiceException virtualAccountsServiceException)
            {
                throw new VirtualAccountsClientServiceException(
                    virtualAccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchVirtualAccounts> RetrieveVirtualAccountNumberAsync(string orderReference)
        {
            try
            {
                return await virtualAccountsService.GetVirtualAccountNumberRequestAsync(orderReference);
            }
            catch (VirtualAccountsValidationException virtualAccountsValidationException)
            {
                throw new VirtualAccountsClientValidationException(
                    virtualAccountsValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyValidationException virtualAccountsDependencyValidationException)
            {

                var message = virtualAccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchVirtualAccounts
                    {
                        Response = new FetchVirtualAccountNumberResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualAccountsClientValidationException(
                    virtualAccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyException virtualAccountsDependencyException)
            {
                throw new VirtualAccountsClientDependencyException(
                    virtualAccountsDependencyException.InnerException as Xeption);
            }
            catch (VirtualAccountsServiceException virtualAccountsServiceException)
            {
                throw new VirtualAccountsClientServiceException(
                    virtualAccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<DeleteVirtualAccounts> RemoveVirtualAccountsAsync(DeleteVirtualAccounts virtualAccounts, string orderReference)
        {
            try
            {
                return await virtualAccountsService.DeleteVirtualAccountsRequestAsync(virtualAccounts, orderReference);
            }
            catch (VirtualAccountsValidationException virtualAccountsValidationException)
            {
                throw new VirtualAccountsClientValidationException(
                    virtualAccountsValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyValidationException virtualAccountsDependencyValidationException)
            {

                var message = virtualAccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new DeleteVirtualAccounts
                    {
                        Response = new DeleteVirtualAccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualAccountsClientValidationException(
                    virtualAccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyException virtualAccountsDependencyException)
            {
                throw new VirtualAccountsClientDependencyException(
                    virtualAccountsDependencyException.InnerException as Xeption);
            }
            catch (VirtualAccountsServiceException virtualAccountsServiceException)
            {
                throw new VirtualAccountsClientServiceException(
                    virtualAccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<BulkCreateVirtualAccounts> BulkCreateVirtualAccountsAsync(BulkCreateVirtualAccounts virtualAccounts)
        {
            try
            {
                return await virtualAccountsService.PostBulkCreateVirtualAccountsRequestAsync(virtualAccounts);
            }
            catch (VirtualAccountsValidationException virtualAccountsValidationException)
            {
                throw new VirtualAccountsClientValidationException(
                    virtualAccountsValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyValidationException virtualAccountsDependencyValidationException)
            {

                var message = virtualAccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BulkCreateVirtualAccounts
                    {
                        Response = new BulkCreateVirtualAccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualAccountsClientValidationException(
                    virtualAccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyException virtualAccountsDependencyException)
            {
                throw new VirtualAccountsClientDependencyException(
                    virtualAccountsDependencyException.InnerException as Xeption);
            }
            catch (VirtualAccountsServiceException virtualAccountsServiceException)
            {
                throw new VirtualAccountsClientServiceException(
                    virtualAccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateVirtualAccounts> CreateVirtualAccountAsync(CreateVirtualAccounts virtualAccounts)
        {
            try
            {
                return await virtualAccountsService.PostCreateVirtualAccountRequestAsync(virtualAccounts);
            }
            catch (VirtualAccountsValidationException virtualAccountsValidationException)
            {
                throw new VirtualAccountsClientValidationException(
                    virtualAccountsValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyValidationException virtualAccountsDependencyValidationException)
            {

                var message = virtualAccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateVirtualAccounts
                    {
                        Response = new CreateVirtualAccountResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualAccountsClientValidationException(
                    virtualAccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyException virtualAccountsDependencyException)
            {
                throw new VirtualAccountsClientDependencyException(
                    virtualAccountsDependencyException.InnerException as Xeption);
            }
            catch (VirtualAccountsServiceException virtualAccountsServiceException)
            {
                throw new VirtualAccountsClientServiceException(
                    virtualAccountsServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateBvnVirtualAccounts> UpdateVirtualAccountsBvnAsync(UpdateBvnVirtualAccounts virtualAccounts, string orderReference)
        {
            try
            {
                return await virtualAccountsService.UpdateVirtualAccountsBvnRequestAsync(virtualAccounts, orderReference);
            }
            catch (VirtualAccountsValidationException virtualAccountsValidationException)
            {
                throw new VirtualAccountsClientValidationException(
                    virtualAccountsValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyValidationException virtualAccountsDependencyValidationException)
            {

                var message = virtualAccountsDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UpdateBvnVirtualAccounts
                    {
                        Response = new UpdateVirtualAccountBvnResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new VirtualAccountsClientValidationException(
                    virtualAccountsDependencyValidationException.InnerException as Xeption);
            }
            catch (VirtualAccountsDependencyException virtualAccountsDependencyException)
            {
                throw new VirtualAccountsClientDependencyException(
                    virtualAccountsDependencyException.InnerException as Xeption);
            }
            catch (VirtualAccountsServiceException virtualAccountsServiceException)
            {
                throw new VirtualAccountsClientServiceException(
                    virtualAccountsServiceException.InnerException as Xeption);
            }
        }
    }
}
