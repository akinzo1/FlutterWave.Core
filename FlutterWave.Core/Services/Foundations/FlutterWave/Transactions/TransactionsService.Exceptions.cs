using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.TransactionsService
{
    internal partial class TransactionsService
    {
        private delegate ValueTask<MultipleTransaction> ReturningMultipleTransactionsFunction();

        private delegate ValueTask<MultipleRefundTransaction> ReturningMultipleRefundTransactionsFunction();

        private delegate ValueTask<VerifyTransaction> ReturningVerifyTransactionFunction();

        private delegate ValueTask<TransactionTimeline> ReturningTransactionTimelineFunction();

        private delegate ValueTask<TransactionFees> ReturningTransactionFeesFunction();

        private delegate ValueTask<CreateRefund> ReturningCreateRefundFunction();

        private delegate ValueTask<RefundDetails> ReturningRefundDetailsFunction();


        private async ValueTask<MultipleRefundTransaction> TryCatch(
                ReturningMultipleRefundTransactionsFunction returningMultipleRefundTransactionsFunction)
        {
            try
            {
                return await returningMultipleRefundTransactionsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<TransactionTimeline> TryCatch(
                ReturningTransactionTimelineFunction returningTransactionTimelineFunction)
        {
            try
            {
                return await returningTransactionTimelineFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<TransactionFees> TryCatch(
           ReturningTransactionFeesFunction returningTransactionFeesFunction)
        {
            try
            {
                return await returningTransactionFeesFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<CreateRefund> TryCatch(
            ReturningCreateRefundFunction returningCreateRefundFunction)
        {
            try
            {
                return await returningCreateRefundFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<RefundDetails> TryCatch(
            ReturningRefundDetailsFunction returningRefundDetailsFunction)
        {
            try
            {
                return await returningRefundDetailsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<VerifyTransaction> TryCatch(
            ReturningVerifyTransactionFunction returningVerifyTransactionFunction)
        {
            try
            {
                return await returningVerifyTransactionFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }
        private async ValueTask<MultipleTransaction> TryCatch(
            ReturningMultipleTransactionsFunction returningMultipleTransactionsFunction)
        {
            try
            {
                return await returningMultipleTransactionsFunction();
            }
            catch (NullTransactionsException nullTransactionsException)
            {
                throw new TransactionsValidationException(nullTransactionsException);
            }
            catch (InvalidTransactionsException invalidTransactionsException)
            {
                throw new TransactionsValidationException(invalidTransactionsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTransactionsException =
                    new InvalidConfigurationTransactionsException(httpResponseUrlNotFoundException);

                throw new TransactionsDependencyException(invalidConfigurationTransactionsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseUnauthorizedException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTransactionsException =
                    new UnauthorizedTransactionsException(httpResponseForbiddenException);

                throw new TransactionsDependencyException(unauthorizedTransactionsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTransactionsException =
                    new NotFoundTransactionsException(httpResponseNotFoundException);

                throw new TransactionsDependencyValidationException(notFoundTransactionsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTransactionsException =
                    new InvalidTransactionsException(httpResponseBadRequestException);

                throw new TransactionsDependencyValidationException(invalidTransactionsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTransactionsException =
                    new ExcessiveCallTransactionsException(httpResponseTooManyRequestsException);

                throw new TransactionsDependencyValidationException(excessiveCallTransactionsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTransactionsException =
                    new FailedServerTransactionsException(httpResponseException);

                throw new TransactionsDependencyException(failedServerTransactionsException);
            }
            catch (Exception exception)
            {
                var failedTransactionsServiceException =
                    new FailedTransactionsServiceException(exception);

                throw new TransactionsServiceException(failedTransactionsServiceException);
            }
        }


    }
}