using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.BillPaymentService
{
    internal partial class BillPaymentService
    {
        private delegate ValueTask<BillPayments> ReturningBillPaymentsFunction();

        private delegate ValueTask<BillPaymentsStatus> ReturningBillPaymentsStatusFunction();

        private delegate ValueTask<BillCategories> ReturningBillCategoriesFunction();

        private delegate ValueTask<BulkBillPayments> ReturningBulkBillPaymentsFunction();

        private delegate ValueTask<PostBillPayments> ReturningPostBillPaymentsFunction();

        private delegate ValueTask<ValidateBillService> ReturningValidateBillServiceFunction();
        private async ValueTask<BillCategories> TryCatch(ReturningBillCategoriesFunction returningBillCategoriesFunction)
        {
            try
            {
                return await returningBillCategoriesFunction();
            }
            catch (NullBillPaymentException nullBillPaymentsException)
            {
                throw new BillPaymentValidationException(nullBillPaymentsException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentsException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentsException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentsException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentsException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentsException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentsException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentsException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentsServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentsServiceException);
            }
        }
        private async ValueTask<BillPayments> TryCatch(ReturningBillPaymentsFunction returningBillPaymentsFunction)
        {
            try
            {
                return await returningBillPaymentsFunction();
            }
            catch (NullBillPaymentException nullBillPaymentsException)
            {
                throw new BillPaymentValidationException(nullBillPaymentsException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentsException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentsException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentsException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentsException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentsException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentsException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentsException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentsServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentsServiceException);
            }
        }
        private async ValueTask<BulkBillPayments> TryCatch(ReturningBulkBillPaymentsFunction returningBulkBillPaymentsFunction)
        {
            try
            {
                return await returningBulkBillPaymentsFunction();
            }
            catch (NullBillPaymentException nullBillPaymentsException)
            {
                throw new BillPaymentValidationException(nullBillPaymentsException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentsException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentsException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentsException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentsException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentsException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentsException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentsException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentsServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentsServiceException);
            }
        }

        private async ValueTask<PostBillPayments> TryCatch(
            ReturningPostBillPaymentsFunction returningPostBillPaymentsFunction)
        {
            try
            {
                return await returningPostBillPaymentsFunction();
            }
            catch (NullBillPaymentException nullBillPaymentsException)
            {
                throw new BillPaymentValidationException(nullBillPaymentsException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentsException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentsException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentsException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentsException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentsException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentsException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentsException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentsServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentsServiceException);
            }
        }

        private async ValueTask<ValidateBillService> TryCatch(
            ReturningValidateBillServiceFunction returningValidateBillServiceFunction)
        {
            try
            {
                return await returningValidateBillServiceFunction();
            }
            catch (NullBillPaymentException nullBillPaymentsException)
            {
                throw new BillPaymentValidationException(nullBillPaymentsException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentsException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentsException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentsException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentsException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentsException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentsException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentsException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentsServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentsServiceException);
            }
        }

        private async ValueTask<BillPaymentsStatus> TryCatch(
            ReturningBillPaymentsStatusFunction returningBillPaymentsStatusFunction)
        {
            try
            {
                return await returningBillPaymentsStatusFunction();
            }
            catch (NullBillPaymentException nullBillPaymentsException)
            {
                throw new BillPaymentValidationException(nullBillPaymentsException);
            }
            catch (InvalidBillPaymentException invalidBillPaymentsException)
            {
                throw new BillPaymentValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationBillPaymentsException =
                    new InvalidConfigurationBillPaymentException(httpResponseUrlNotFoundException);

                throw new BillPaymentDependencyException(invalidConfigurationBillPaymentsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseUnauthorizedException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedBillPaymentsException =
                    new UnauthorizedBillPaymentException(httpResponseForbiddenException);

                throw new BillPaymentDependencyException(unauthorizedBillPaymentsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundBillPaymentsException =
                    new NotFoundBillPaymentException(httpResponseNotFoundException);

                throw new BillPaymentDependencyValidationException(notFoundBillPaymentsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidBillPaymentsException =
                    new InvalidBillPaymentException(httpResponseBadRequestException);

                throw new BillPaymentDependencyValidationException(invalidBillPaymentsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallBillPaymentsException =
                    new ExcessiveCallBillPaymentException(httpResponseTooManyRequestsException);

                throw new BillPaymentDependencyValidationException(excessiveCallBillPaymentsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerBillPaymentsException =
                    new FailedServerBillPaymentException(httpResponseException);

                throw new BillPaymentDependencyException(failedServerBillPaymentsException);
            }
            catch (Exception exception)
            {
                var failedBillPaymentsServiceException =
                    new FailedBillPaymentServiceException(exception);

                throw new BillPaymentServiceException(failedBillPaymentsServiceException);
            }
        }

    }
}