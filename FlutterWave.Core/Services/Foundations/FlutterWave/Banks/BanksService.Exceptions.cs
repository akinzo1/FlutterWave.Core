using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BanksService
{
    internal partial class BanksService
    {
        private delegate ValueTask<BankBranches> ReturningBankBranchesFunction();

        private delegate ValueTask<Bank> ReturningBankFunction();
        private static async ValueTask<Bank> TryCatch(ReturningBankFunction returningBankFunction)
        {
            try
            {
                return await returningBankFunction();
            }
            catch (NullBanksException nullBanksException)
            {
                throw new BanksValidationException(nullBanksException);
            }
            catch (InvalidBanksException invalidBanksException)
            {
                throw new BanksValidationException(invalidBanksException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBanksException =
                    new InvalidConfigurationBanksException(httpResponseUrlNotFoundException);

                throw new BanksDependencyException(invalidConfigurationBanksException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBanksException =
                    new UnauthorizedBanksException(httpResponseUnauthorizedException);

                throw new BanksDependencyException(unauthorizedBanksException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBanksException =
                    new UnauthorizedBanksException(httpResponseForbiddenException);

                throw new BanksDependencyException(unauthorizedBanksException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBanksException =
                    new NotFoundBanksException(httpResponseNotFoundException);

                throw new BanksDependencyValidationException(notFoundBanksException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBanksException =
                    new InvalidBanksException(httpResponseBadRequestException);

                throw new BanksDependencyValidationException(invalidBanksException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBanksException =
                    new ExcessiveCallBanksException(httpResponseTooManyRequestsException);

                throw new BanksDependencyValidationException(excessiveCallBanksException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBanksException =
                    new FailedServerBanksException(httpResponseException);

                throw new BanksDependencyException(failedServerBanksException);
            }
            catch (Exception exception)
            {
                var failedBanksServiceException =
                    new FailedBanksServiceException(exception);

                throw new BanksServiceException(failedBanksServiceException);
            }
        }
        private static async ValueTask<BankBranches> TryCatch(ReturningBankBranchesFunction returningBankBranchesFunction)
        {
            try
            {
                return await returningBankBranchesFunction();
            }
            catch (NullBanksException nullBanksException)
            {
                throw new BanksValidationException(nullBanksException);
            }
            catch (InvalidBanksException invalidBanksException)
            {
                throw new BanksValidationException(invalidBanksException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBanksException =
                    new InvalidConfigurationBanksException(httpResponseUrlNotFoundException);

                throw new BanksDependencyException(invalidConfigurationBanksException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBanksException =
                    new UnauthorizedBanksException(httpResponseUnauthorizedException);

                throw new BanksDependencyException(unauthorizedBanksException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBanksException =
                    new UnauthorizedBanksException(httpResponseForbiddenException);

                throw new BanksDependencyException(unauthorizedBanksException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {

                var notFoundBanksException =
                    new NotFoundBanksException(httpResponseNotFoundException);

                throw new BanksDependencyValidationException(notFoundBanksException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBanksException =
                    new InvalidBanksException(httpResponseBadRequestException);

                throw new BanksDependencyValidationException(invalidBanksException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBanksException =
                    new ExcessiveCallBanksException(httpResponseTooManyRequestsException);

                throw new BanksDependencyValidationException(excessiveCallBanksException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBanksException =
                    new FailedServerBanksException(httpResponseException);

                throw new BanksDependencyException(failedServerBanksException);
            }
            catch (Exception exception)
            {
                var failedBanksServiceException =
                    new FailedBanksServiceException(exception);

                throw new BanksServiceException(failedBanksServiceException);
            }
        }


    }
}