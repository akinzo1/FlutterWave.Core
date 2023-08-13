using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TransfersService
{
    internal partial class TransfersService
    {
        private delegate ValueTask<FetchRetryTransfers> ReturningTransfersFunction();

        private delegate ValueTask<RetryTransfers> ReturningRetryTransfersFunction();

        private delegate ValueTask<InitiateTransfers> ReturningInitiateTransfersFunction();

        private delegate ValueTask<FetchTransfers> ReturningFetchTransfersFunction();

        private delegate ValueTask<FetchBulkTransfers> ReturningFetchBulkTransfersFunction();

        private delegate ValueTask<BulkCreateTransfers> ReturningBulkCreateTransfersFunction();

        private delegate ValueTask<AllTransfers> ReturningAllTransfersFunction();

        private delegate ValueTask<TransferFees> ReturningTransferFeesFunction();

        private delegate ValueTask<TransferRates> ReturningTransferRatesFunction();

        private async ValueTask<FetchRetryTransfers> TryCatch(ReturningTransfersFunction returningTransfersFunction)
        {
            try
            {
                return await returningTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<RetryTransfers> TryCatch(ReturningRetryTransfersFunction returningRetryTransfersFunction)
        {
            try
            {
                return await returningRetryTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<InitiateTransfers> TryCatch(ReturningInitiateTransfersFunction returningInitiateTransfersFunction)
        {
            try
            {
                return await returningInitiateTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<FetchTransfers> TryCatch(ReturningFetchTransfersFunction returningFetchTransfersFunction)
        {
            try
            {
                return await returningFetchTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<FetchBulkTransfers> TryCatch(ReturningFetchBulkTransfersFunction returningFetchBulkTransfersFunction)
        {
            try
            {
                return await returningFetchBulkTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<BulkCreateTransfers> TryCatch(ReturningBulkCreateTransfersFunction returningBulkCreateTransfersFunction)
        {
            try
            {
                return await returningBulkCreateTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<AllTransfers> TryCatch(ReturningAllTransfersFunction returningAllTransfersFunction)
        {
            try
            {
                return await returningAllTransfersFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<TransferFees> TryCatch(ReturningTransferFeesFunction returningTransferFeesFunction)
        {
            try
            {
                return await returningTransferFeesFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }
        private async ValueTask<TransferRates> TryCatch(ReturningTransferRatesFunction returningTransferRatesFunction)
        {
            try
            {
                return await returningTransferRatesFunction();
            }
            catch (NullTransfersException nullTransfersException)
            {
                throw new TransfersValidationException(nullTransfersException);
            }
            catch (InvalidTransfersException invalidTransfersException)
            {
                throw new TransfersValidationException(invalidTransfersException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransfersException =
                    new InvalidConfigurationTransfersException(httpResponseUrlNotFoundException);

                throw new TransfersDependencyException(invalidConfigurationTransfersException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseUnauthorizedException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransfersException =
                    new UnauthorizedTransfersException(httpResponseForbiddenException);

                throw new TransfersDependencyException(unauthorizedTransfersException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransfersException =
                    new NotFoundTransfersException(httpResponseNotFoundException);

                throw new TransfersDependencyValidationException(notFoundTransfersException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransfersException =
                    new InvalidTransfersException(httpResponseBadRequestException);

                throw new TransfersDependencyValidationException(invalidTransfersException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransfersException =
                    new ExcessiveCallTransfersException(httpResponseTooManyRequestsException);

                throw new TransfersDependencyValidationException(excessiveCallTransfersException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransfersException =
                    new FailedServerTransfersException(httpResponseException);

                throw new TransfersDependencyException(failedServerTransfersException);
            }
            catch (Exception exception)
            {
                var failedTransfersServiceException =
                    new FailedTransfersServiceException(exception);

                throw new TransfersServiceException(failedTransfersServiceException);
            }
        }

    }
}