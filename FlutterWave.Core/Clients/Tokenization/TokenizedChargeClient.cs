using FlutterWave.Core.Models.Clients.TokenizedCharge.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using FlutterWave.Core.Services.Foundations.FlutterWave.TokenizedChargeService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.Tokenization
{
    internal class TokenizedChargeClient : ITokenizedChargeClient
    {
        private readonly ITokenizedChargeService tokenizedChargeService;

        public TokenizedChargeClient(ITokenizedChargeService tokenizedChargeService) =>
              this.tokenizedChargeService = tokenizedChargeService;

        public async ValueTask<CreateBulkTokenizedCharge> CreateBulkTokenizedChargeAsync(CreateBulkTokenizedCharge createBulkTokenizedCharge)
        {
            try
            {
                return await tokenizedChargeService.PostCreateBulkTokenizedChargeRequestAsync(createBulkTokenizedCharge);
            }
            catch (TokenizedChargeValidationException tokenizedChargeValidationException)
            {
                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyValidationException tokenizedChargeDependencyValidationException)
            {

                var message = tokenizedChargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateBulkTokenizedCharge
                    {
                        Response = new CreateBulkTokenizedChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeDependencyValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyException tokenizedChargeDependencyException)
            {
                throw new TokenizedChargeClientDependencyException(
                    tokenizedChargeDependencyException.InnerException as Xeption);
            }
            catch (TokenizedChargeServiceException tokenizedChargeServiceException)
            {
                throw new TokenizedChargeClientServiceException(
                    tokenizedChargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<CreateTokenizedCharge> CreateTokenizedChargeAsync(CreateTokenizedCharge createTokenizedCharge)
        {
            try
            {
                return await tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(createTokenizedCharge);
            }
            catch (TokenizedChargeValidationException tokenizedChargeValidationException)
            {
                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyValidationException tokenizedChargeDependencyValidationException)
            {

                var message = tokenizedChargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new CreateTokenizedCharge
                    {
                        Response = new CreateTokenizedChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeDependencyValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyException tokenizedChargeDependencyException)
            {
                throw new TokenizedChargeClientDependencyException(
                    tokenizedChargeDependencyException.InnerException as Xeption);
            }
            catch (TokenizedChargeServiceException tokenizedChargeServiceException)
            {
                throw new TokenizedChargeClientServiceException(
                    tokenizedChargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<FetchBulkTokenizedCharge> RetrieveBulkTokenizedChargesAsync(int bulkId)
        {
            try
            {
                return await tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(bulkId);
            }
            catch (TokenizedChargeValidationException tokenizedChargeValidationException)
            {
                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyValidationException tokenizedChargeDependencyValidationException)
            {

                var message = tokenizedChargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new FetchBulkTokenizedCharge
                    {
                        Response = new FetchBulkTokenizedChargeResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeDependencyValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyException tokenizedChargeDependencyException)
            {
                throw new TokenizedChargeClientDependencyException(
                    tokenizedChargeDependencyException.InnerException as Xeption);
            }
            catch (TokenizedChargeServiceException tokenizedChargeServiceException)
            {
                throw new TokenizedChargeClientServiceException(
                    tokenizedChargeServiceException.InnerException as Xeption);
            }
        }
        public async ValueTask<BulkTokenizedStatus> RetrieveBulkTokenizedStatusAsync(int bulkId)
        {
            try
            {
                return await tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(bulkId);
            }
            catch (TokenizedChargeValidationException tokenizedChargeValidationException)
            {
                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyValidationException tokenizedChargeDependencyValidationException)
            {

                var message = tokenizedChargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new BulkTokenizedStatus
                    {
                        Response = new BulkTokenizedStatusResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeDependencyValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyException tokenizedChargeDependencyException)
            {
                throw new TokenizedChargeClientDependencyException(
                    tokenizedChargeDependencyException.InnerException as Xeption);
            }
            catch (TokenizedChargeServiceException tokenizedChargeServiceException)
            {
                throw new TokenizedChargeClientServiceException(
                    tokenizedChargeServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateCardToken> UpdateCardTokenAsync(string token, UpdateCardToken createBulkTokenizedCharge)
        {
            try
            {
                return await tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, createBulkTokenizedCharge);
            }
            catch (TokenizedChargeValidationException tokenizedChargeValidationException)
            {
                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyValidationException tokenizedChargeDependencyValidationException)
            {

                var message = tokenizedChargeDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new UpdateCardToken
                    {
                        Response = new UpdateCardTokenResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new TokenizedChargeClientValidationException(
                    tokenizedChargeDependencyValidationException.InnerException as Xeption);
            }
            catch (TokenizedChargeDependencyException tokenizedChargeDependencyException)
            {
                throw new TokenizedChargeClientDependencyException(
                    tokenizedChargeDependencyException.InnerException as Xeption);
            }
            catch (TokenizedChargeServiceException tokenizedChargeServiceException)
            {
                throw new TokenizedChargeClientServiceException(
                    tokenizedChargeServiceException.InnerException as Xeption);
            }
        }
    }
}
