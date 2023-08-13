using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService
{
    internal partial class CollectionSubaccountsService
    {
        private delegate ValueTask<CreateCollectionSubaccount> ReturningCreateCollectionSubaccountFunction();
        private delegate ValueTask<DeleteSubaccount> ReturningDeleteSubaccountFunction();
        private delegate ValueTask<FetchSubaccount> ReturningFetchSubaccountFunction();
        private delegate ValueTask<FetchSubaccounts> ReturningFetchSubaccountsFunction();
        private delegate ValueTask<UpdateSubaccount> ReturningUpdateSubaccountFunction();


        private async ValueTask<CreateCollectionSubaccount> TryCatch(ReturningCreateCollectionSubaccountFunction returningCreateCollectionSubaccountFunction)
        {
            try
            {
                return await returningCreateCollectionSubaccountFunction();
            }
            catch (NullCollectionSubaccountsException nullCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);
            }
            catch (InvalidCollectionSubaccountsException invalidCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCollectionSubaccountsException =
                    new InvalidConfigurationCollectionSubaccountsException(httpResponseUrlNotFoundException);

                throw new CollectionSubaccountsDependencyException(invalidConfigurationCollectionSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseUnauthorizedException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseForbiddenException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCollectionSubaccountsException =
                    new NotFoundCollectionSubaccountsException(httpResponseNotFoundException);

                throw new CollectionSubaccountsDependencyValidationException(notFoundCollectionSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCollectionSubaccountsException =
                    new InvalidCollectionSubaccountsException(httpResponseBadRequestException);

                throw new CollectionSubaccountsDependencyValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCollectionSubaccountsException =
                    new ExcessiveCallCollectionSubaccountsException(httpResponseTooManyRequestsException);

                throw new CollectionSubaccountsDependencyValidationException(excessiveCallCollectionSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCollectionSubaccountsException =
                    new FailedServerCollectionSubaccountsException(httpResponseException);

                throw new CollectionSubaccountsDependencyException(failedServerCollectionSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedCollectionSubaccountsServiceException =
                    new FailedCollectionSubaccountsServiceException(exception);

                throw new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);
            }
        }
        private async ValueTask<DeleteSubaccount> TryCatch(ReturningDeleteSubaccountFunction returningDeleteSubaccountFunction)
        {
            try
            {
                return await returningDeleteSubaccountFunction();
            }
            catch (NullCollectionSubaccountsException nullCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);
            }
            catch (InvalidCollectionSubaccountsException invalidCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCollectionSubaccountsException =
                    new InvalidConfigurationCollectionSubaccountsException(httpResponseUrlNotFoundException);

                throw new CollectionSubaccountsDependencyException(invalidConfigurationCollectionSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseUnauthorizedException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseForbiddenException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCollectionSubaccountsException =
                    new NotFoundCollectionSubaccountsException(httpResponseNotFoundException);

                throw new CollectionSubaccountsDependencyValidationException(notFoundCollectionSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCollectionSubaccountsException =
                    new InvalidCollectionSubaccountsException(httpResponseBadRequestException);

                throw new CollectionSubaccountsDependencyValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCollectionSubaccountsException =
                    new ExcessiveCallCollectionSubaccountsException(httpResponseTooManyRequestsException);

                throw new CollectionSubaccountsDependencyValidationException(excessiveCallCollectionSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCollectionSubaccountsException =
                    new FailedServerCollectionSubaccountsException(httpResponseException);

                throw new CollectionSubaccountsDependencyException(failedServerCollectionSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedCollectionSubaccountsServiceException =
                    new FailedCollectionSubaccountsServiceException(exception);

                throw new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);
            }
        }
        private async ValueTask<FetchSubaccount> TryCatch(ReturningFetchSubaccountFunction returningFetchSubaccountFunction)
        {
            try
            {
                return await returningFetchSubaccountFunction();
            }
            catch (NullCollectionSubaccountsException nullCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);
            }
            catch (InvalidCollectionSubaccountsException invalidCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCollectionSubaccountsException =
                    new InvalidConfigurationCollectionSubaccountsException(httpResponseUrlNotFoundException);

                throw new CollectionSubaccountsDependencyException(invalidConfigurationCollectionSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseUnauthorizedException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseForbiddenException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCollectionSubaccountsException =
                    new NotFoundCollectionSubaccountsException(httpResponseNotFoundException);

                throw new CollectionSubaccountsDependencyValidationException(notFoundCollectionSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCollectionSubaccountsException =
                    new InvalidCollectionSubaccountsException(httpResponseBadRequestException);

                throw new CollectionSubaccountsDependencyValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCollectionSubaccountsException =
                    new ExcessiveCallCollectionSubaccountsException(httpResponseTooManyRequestsException);

                throw new CollectionSubaccountsDependencyValidationException(excessiveCallCollectionSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCollectionSubaccountsException =
                    new FailedServerCollectionSubaccountsException(httpResponseException);

                throw new CollectionSubaccountsDependencyException(failedServerCollectionSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedCollectionSubaccountsServiceException =
                    new FailedCollectionSubaccountsServiceException(exception);

                throw new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);
            }
        }
        private async ValueTask<FetchSubaccounts> TryCatch(ReturningFetchSubaccountsFunction returningFetchSubaccountsFunction)
        {
            try
            {
                return await returningFetchSubaccountsFunction();
            }
            catch (NullCollectionSubaccountsException nullCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);
            }
            catch (InvalidCollectionSubaccountsException invalidCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCollectionSubaccountsException =
                    new InvalidConfigurationCollectionSubaccountsException(httpResponseUrlNotFoundException);

                throw new CollectionSubaccountsDependencyException(invalidConfigurationCollectionSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseUnauthorizedException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseForbiddenException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCollectionSubaccountsException =
                    new NotFoundCollectionSubaccountsException(httpResponseNotFoundException);

                throw new CollectionSubaccountsDependencyValidationException(notFoundCollectionSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCollectionSubaccountsException =
                    new InvalidCollectionSubaccountsException(httpResponseBadRequestException);

                throw new CollectionSubaccountsDependencyValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCollectionSubaccountsException =
                    new ExcessiveCallCollectionSubaccountsException(httpResponseTooManyRequestsException);

                throw new CollectionSubaccountsDependencyValidationException(excessiveCallCollectionSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCollectionSubaccountsException =
                    new FailedServerCollectionSubaccountsException(httpResponseException);

                throw new CollectionSubaccountsDependencyException(failedServerCollectionSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedCollectionSubaccountsServiceException =
                    new FailedCollectionSubaccountsServiceException(exception);

                throw new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);
            }
        }

        private async ValueTask<UpdateSubaccount> TryCatch(ReturningUpdateSubaccountFunction returningUpdateSubaccountFunction)
        {
            try
            {
                return await returningUpdateSubaccountFunction();
            }
            catch (NullCollectionSubaccountsException nullCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(nullCollectionSubaccountsException);
            }
            catch (InvalidCollectionSubaccountsException invalidCollectionSubaccountsException)
            {
                throw new CollectionSubaccountsValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationCollectionSubaccountsException =
                    new InvalidConfigurationCollectionSubaccountsException(httpResponseUrlNotFoundException);

                throw new CollectionSubaccountsDependencyException(invalidConfigurationCollectionSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseUnauthorizedException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedCollectionSubaccountsException =
                    new UnauthorizedCollectionSubaccountsException(httpResponseForbiddenException);

                throw new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundCollectionSubaccountsException =
                    new NotFoundCollectionSubaccountsException(httpResponseNotFoundException);

                throw new CollectionSubaccountsDependencyValidationException(notFoundCollectionSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidCollectionSubaccountsException =
                    new InvalidCollectionSubaccountsException(httpResponseBadRequestException);

                throw new CollectionSubaccountsDependencyValidationException(invalidCollectionSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallCollectionSubaccountsException =
                    new ExcessiveCallCollectionSubaccountsException(httpResponseTooManyRequestsException);

                throw new CollectionSubaccountsDependencyValidationException(excessiveCallCollectionSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerCollectionSubaccountsException =
                    new FailedServerCollectionSubaccountsException(httpResponseException);

                throw new CollectionSubaccountsDependencyException(failedServerCollectionSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedCollectionSubaccountsServiceException =
                    new FailedCollectionSubaccountsServiceException(exception);

                throw new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);
            }
        }


    }
}