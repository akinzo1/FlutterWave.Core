using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualAccountsService
{
    internal partial class VirtualAccountsService
    {
        private delegate ValueTask<BulkCreateVirtualAccounts> ReturningBulkCreateVirtualAccountsFunction();
        private delegate ValueTask<CreateVirtualAccounts> ReturningCreateVirtualAccountsFunction();
        private delegate ValueTask<DeleteVirtualAccounts> ReturningDeleteVirtualAccountsFunction();
        private delegate ValueTask<UpdateBvnVirtualAccounts> ReturningUpdateBvnVirtualAccountsFunction();
        private delegate ValueTask<FetchVirtualAccounts> ReturningFetchVirtualAccountsFunction();
        private delegate ValueTask<BulkVirtualAccountDetails> ReturningBulkVirtualAccountDetailsFunction();

        private async ValueTask<BulkCreateVirtualAccounts> TryCatch(ReturningBulkCreateVirtualAccountsFunction returningBulkCreateVirtualAccountsFunction)
        {
            try
            {
                return await returningBulkCreateVirtualAccountsFunction();
            }
            catch (NullVirtualAccountsException nullVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(nullVirtualAccountsException);
            }
            catch (InvalidVirtualAccountsException invalidVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualAccountsException =
                    new InvalidConfigurationVirtualAccountsException(httpResponseUrlNotFoundException);

                throw new VirtualAccountsDependencyException(invalidConfigurationVirtualAccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseUnauthorizedException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseForbiddenException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualAccountsException =
                    new NotFoundVirtualAccountsException(httpResponseNotFoundException);

                throw new VirtualAccountsDependencyValidationException(notFoundVirtualAccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualAccountsException =
                    new InvalidVirtualAccountsException(httpResponseBadRequestException);

                throw new VirtualAccountsDependencyValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualAccountsException =
                    new ExcessiveCallVirtualAccountsException(httpResponseTooManyRequestsException);

                throw new VirtualAccountsDependencyValidationException(excessiveCallVirtualAccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualAccountsException =
                    new FailedServerVirtualAccountsException(httpResponseException);

                throw new VirtualAccountsDependencyException(failedServerVirtualAccountsException);
            }
            catch (Exception exception)
            {
                var failedVirtualAccountsServiceException =
                    new FailedVirtualAccountsServiceException(exception);

                throw new VirtualAccountsServiceException(failedVirtualAccountsServiceException);
            }
        }
        private async ValueTask<CreateVirtualAccounts> TryCatch(ReturningCreateVirtualAccountsFunction returningCreateVirtualAccountsFunction)
        {
            try
            {
                return await returningCreateVirtualAccountsFunction();
            }
            catch (NullVirtualAccountsException nullVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(nullVirtualAccountsException);
            }
            catch (InvalidVirtualAccountsException invalidVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualAccountsException =
                    new InvalidConfigurationVirtualAccountsException(httpResponseUrlNotFoundException);

                throw new VirtualAccountsDependencyException(invalidConfigurationVirtualAccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseUnauthorizedException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseForbiddenException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualAccountsException =
                    new NotFoundVirtualAccountsException(httpResponseNotFoundException);

                throw new VirtualAccountsDependencyValidationException(notFoundVirtualAccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualAccountsException =
                    new InvalidVirtualAccountsException(httpResponseBadRequestException);

                throw new VirtualAccountsDependencyValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualAccountsException =
                    new ExcessiveCallVirtualAccountsException(httpResponseTooManyRequestsException);

                throw new VirtualAccountsDependencyValidationException(excessiveCallVirtualAccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualAccountsException =
                    new FailedServerVirtualAccountsException(httpResponseException);

                throw new VirtualAccountsDependencyException(failedServerVirtualAccountsException);
            }
            catch (Exception exception)
            {
                var failedVirtualAccountsServiceException =
                    new FailedVirtualAccountsServiceException(exception);

                throw new VirtualAccountsServiceException(failedVirtualAccountsServiceException);
            }
        }
        private async ValueTask<DeleteVirtualAccounts> TryCatch(ReturningDeleteVirtualAccountsFunction returningDeleteVirtualAccountsFunction)
        {
            try
            {
                return await returningDeleteVirtualAccountsFunction();
            }
            catch (NullVirtualAccountsException nullVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(nullVirtualAccountsException);
            }
            catch (InvalidVirtualAccountsException invalidVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualAccountsException =
                    new InvalidConfigurationVirtualAccountsException(httpResponseUrlNotFoundException);

                throw new VirtualAccountsDependencyException(invalidConfigurationVirtualAccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseUnauthorizedException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseForbiddenException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualAccountsException =
                    new NotFoundVirtualAccountsException(httpResponseNotFoundException);

                throw new VirtualAccountsDependencyValidationException(notFoundVirtualAccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualAccountsException =
                    new InvalidVirtualAccountsException(httpResponseBadRequestException);

                throw new VirtualAccountsDependencyValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualAccountsException =
                    new ExcessiveCallVirtualAccountsException(httpResponseTooManyRequestsException);

                throw new VirtualAccountsDependencyValidationException(excessiveCallVirtualAccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualAccountsException =
                    new FailedServerVirtualAccountsException(httpResponseException);

                throw new VirtualAccountsDependencyException(failedServerVirtualAccountsException);
            }
            catch (Exception exception)
            {
                var failedVirtualAccountsServiceException =
                    new FailedVirtualAccountsServiceException(exception);

                throw new VirtualAccountsServiceException(failedVirtualAccountsServiceException);
            }
        }
        private async ValueTask<UpdateBvnVirtualAccounts> TryCatch(ReturningUpdateBvnVirtualAccountsFunction returningUpdateBvnVirtualAccountsFunction)
        {
            try
            {
                return await returningUpdateBvnVirtualAccountsFunction();
            }
            catch (NullVirtualAccountsException nullVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(nullVirtualAccountsException);
            }
            catch (InvalidVirtualAccountsException invalidVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualAccountsException =
                    new InvalidConfigurationVirtualAccountsException(httpResponseUrlNotFoundException);

                throw new VirtualAccountsDependencyException(invalidConfigurationVirtualAccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseUnauthorizedException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseForbiddenException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualAccountsException =
                    new NotFoundVirtualAccountsException(httpResponseNotFoundException);

                throw new VirtualAccountsDependencyValidationException(notFoundVirtualAccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualAccountsException =
                    new InvalidVirtualAccountsException(httpResponseBadRequestException);

                throw new VirtualAccountsDependencyValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualAccountsException =
                    new ExcessiveCallVirtualAccountsException(httpResponseTooManyRequestsException);

                throw new VirtualAccountsDependencyValidationException(excessiveCallVirtualAccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualAccountsException =
                    new FailedServerVirtualAccountsException(httpResponseException);

                throw new VirtualAccountsDependencyException(failedServerVirtualAccountsException);
            }
            catch (Exception exception)
            {
                var failedVirtualAccountsServiceException =
                    new FailedVirtualAccountsServiceException(exception);

                throw new VirtualAccountsServiceException(failedVirtualAccountsServiceException);
            }
        }
        private async ValueTask<FetchVirtualAccounts> TryCatch(ReturningFetchVirtualAccountsFunction returningFetchVirtualAccountsFunction)
        {
            try
            {
                return await returningFetchVirtualAccountsFunction();
            }
            catch (NullVirtualAccountsException nullVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(nullVirtualAccountsException);
            }
            catch (InvalidVirtualAccountsException invalidVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualAccountsException =
                    new InvalidConfigurationVirtualAccountsException(httpResponseUrlNotFoundException);

                throw new VirtualAccountsDependencyException(invalidConfigurationVirtualAccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseUnauthorizedException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseForbiddenException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualAccountsException =
                    new NotFoundVirtualAccountsException(httpResponseNotFoundException);

                throw new VirtualAccountsDependencyValidationException(notFoundVirtualAccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualAccountsException =
                    new InvalidVirtualAccountsException(httpResponseBadRequestException);

                throw new VirtualAccountsDependencyValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualAccountsException =
                    new ExcessiveCallVirtualAccountsException(httpResponseTooManyRequestsException);

                throw new VirtualAccountsDependencyValidationException(excessiveCallVirtualAccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualAccountsException =
                    new FailedServerVirtualAccountsException(httpResponseException);

                throw new VirtualAccountsDependencyException(failedServerVirtualAccountsException);
            }
            catch (Exception exception)
            {
                var failedVirtualAccountsServiceException =
                    new FailedVirtualAccountsServiceException(exception);

                throw new VirtualAccountsServiceException(failedVirtualAccountsServiceException);
            }
        }
        private async ValueTask<BulkVirtualAccountDetails> TryCatch(ReturningBulkVirtualAccountDetailsFunction returningBulkVirtualAccountDetailsFunction)
        {
            try
            {
                return await returningBulkVirtualAccountDetailsFunction();
            }
            catch (NullVirtualAccountsException nullVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(nullVirtualAccountsException);
            }
            catch (InvalidVirtualAccountsException invalidVirtualAccountsException)
            {
                throw new VirtualAccountsValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualAccountsException =
                    new InvalidConfigurationVirtualAccountsException(httpResponseUrlNotFoundException);

                throw new VirtualAccountsDependencyException(invalidConfigurationVirtualAccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseUnauthorizedException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualAccountsException =
                    new UnauthorizedVirtualAccountsException(httpResponseForbiddenException);

                throw new VirtualAccountsDependencyException(unauthorizedVirtualAccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualAccountsException =
                    new NotFoundVirtualAccountsException(httpResponseNotFoundException);

                throw new VirtualAccountsDependencyValidationException(notFoundVirtualAccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualAccountsException =
                    new InvalidVirtualAccountsException(httpResponseBadRequestException);

                throw new VirtualAccountsDependencyValidationException(invalidVirtualAccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualAccountsException =
                    new ExcessiveCallVirtualAccountsException(httpResponseTooManyRequestsException);

                throw new VirtualAccountsDependencyValidationException(excessiveCallVirtualAccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualAccountsException =
                    new FailedServerVirtualAccountsException(httpResponseException);

                throw new VirtualAccountsDependencyException(failedServerVirtualAccountsException);
            }
            catch (Exception exception)
            {
                var failedVirtualAccountsServiceException =
                    new FailedVirtualAccountsServiceException(exception);

                throw new VirtualAccountsServiceException(failedVirtualAccountsServiceException);
            }
        }


    }
}