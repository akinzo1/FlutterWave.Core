using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.VirtualCardsService
{
    internal partial class VirtualCardsService
    {
        private delegate ValueTask<BlockUnblockVirtualCard> ReturningBlockUnblockVirtualCardFunction();
        private delegate ValueTask<CreateVirtualCard> ReturningCreateVirtualCardFunction();
        private delegate ValueTask<FetchVirtualCard> ReturningFetchVirtualCardFunction();
        private delegate ValueTask<FetchVirtualCards> ReturningFetchVirtualCardsFunction();
        private delegate ValueTask<FundVirtualCard> ReturningFundVirtualCardFunction();
        private delegate ValueTask<TerminateVirtualCard> ReturningTerminateVirtualCardFunction();
        private delegate ValueTask<VirtualCardTransactions> ReturningVirtualCardTransactionsFunction();
        private delegate ValueTask<VirtualCardWithdrawal> ReturningVirtualCardWithdrawalFunction();

        private async ValueTask<BlockUnblockVirtualCard> TryCatch(ReturningBlockUnblockVirtualCardFunction returningBlockUnblockVirtualCardFunction)
        {
            try
            {
                return await returningBlockUnblockVirtualCardFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }
        private async ValueTask<CreateVirtualCard> TryCatch(ReturningCreateVirtualCardFunction returningCreateVirtualCardFunction)
        {
            try
            {
                return await returningCreateVirtualCardFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }
        private async ValueTask<FetchVirtualCard> TryCatch(ReturningFetchVirtualCardFunction returningFetchVirtualCardFunction)
        {
            try
            {
                return await returningFetchVirtualCardFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }
        private async ValueTask<FetchVirtualCards> TryCatch(ReturningFetchVirtualCardsFunction returningFetchVirtualCardsFunction)
        {
            try
            {
                return await returningFetchVirtualCardsFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }

        private async ValueTask<FundVirtualCard> TryCatch(ReturningFundVirtualCardFunction returningFundVirtualCardFunction)
        {
            try
            {
                return await returningFundVirtualCardFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }
        private async ValueTask<TerminateVirtualCard> TryCatch(ReturningTerminateVirtualCardFunction returningTerminateVirtualCardFunction)
        {
            try
            {
                return await returningTerminateVirtualCardFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }
        private async ValueTask<VirtualCardTransactions> TryCatch(ReturningVirtualCardTransactionsFunction returningVirtualCardTransactionsFunction)
        {
            try
            {
                return await returningVirtualCardTransactionsFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }

        private async ValueTask<VirtualCardWithdrawal> TryCatch(ReturningVirtualCardWithdrawalFunction returningVirtualCardWithdrawalFunction)
        {
            try
            {
                return await returningVirtualCardWithdrawalFunction();
            }
            catch (NullVirtualCardsException nullVirtualCardsException)
            {
                throw new VirtualCardsValidationException(nullVirtualCardsException);
            }
            catch (InvalidVirtualCardsException invalidVirtualCardsException)
            {
                throw new VirtualCardsValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationVirtualCardsException =
                    new InvalidConfigurationVirtualCardsException(httpResponseUrlNotFoundException);

                throw new VirtualCardsDependencyException(invalidConfigurationVirtualCardsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseUnauthorizedException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedVirtualCardsException =
                    new UnauthorizedVirtualCardsException(httpResponseForbiddenException);

                throw new VirtualCardsDependencyException(unauthorizedVirtualCardsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundVirtualCardsException =
                    new NotFoundVirtualCardsException(httpResponseNotFoundException);

                throw new VirtualCardsDependencyValidationException(notFoundVirtualCardsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidVirtualCardsException =
                    new InvalidVirtualCardsException(httpResponseBadRequestException);

                throw new VirtualCardsDependencyValidationException(invalidVirtualCardsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallVirtualCardsException =
                    new ExcessiveCallVirtualCardsException(httpResponseTooManyRequestsException);

                throw new VirtualCardsDependencyValidationException(excessiveCallVirtualCardsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerVirtualCardsException =
                    new FailedServerVirtualCardsException(httpResponseException);

                throw new VirtualCardsDependencyException(failedServerVirtualCardsException);
            }
            catch (Exception exception)
            {
                var failedVirtualCardsServiceException =
                    new FailedVirtualCardsServiceException(exception);

                throw new VirtualCardsServiceException(failedVirtualCardsServiceException);
            }
        }


    }
}