using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService
{
    internal partial class PayoutSubaccountsService
    {
        private delegate ValueTask<CreatePayoutSubaccount> ReturningCreatePayoutSubaccountFunction();
        private delegate ValueTask<FetchPayoutSubaccount> ReturningFetchPayoutSubaccountFunction();
        private delegate ValueTask<UpdatePayoutSubaccount> ReturningUpdatePayoutSubaccountFunction();
        private delegate ValueTask<ListPayoutSubaccounts> ReturningListPayoutSubaccountsFunction();
        private delegate ValueTask<FetchPayoutSubaccountTransactions> ReturningFetchPayoutSubaccountTransactionsFunction();
        private delegate ValueTask<FetchStaticVirtualAccounts> ReturningFetchStaticVirtualAccountsFunction();
        private delegate ValueTask<FetchSubaccountAvailableBalance> ReturningFetchSubaccountAvailableBalanceFunction();

        private async ValueTask<CreatePayoutSubaccount> TryCatch(ReturningCreatePayoutSubaccountFunction returningCreatePayoutSubaccountFunction)
        {
            try
            {
                return await returningCreatePayoutSubaccountFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }
        private async ValueTask<FetchPayoutSubaccount> TryCatch(ReturningFetchPayoutSubaccountFunction returningFetchPayoutSubaccountFunction)
        {
            try
            {
                return await returningFetchPayoutSubaccountFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }
        private async ValueTask<UpdatePayoutSubaccount> TryCatch(ReturningUpdatePayoutSubaccountFunction returningUpdatePayoutSubaccountFunction)
        {
            try
            {
                return await returningUpdatePayoutSubaccountFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }
        private async ValueTask<ListPayoutSubaccounts> TryCatch(ReturningListPayoutSubaccountsFunction returningListPayoutSubaccountsFunction)
        {
            try
            {
                return await returningListPayoutSubaccountsFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }

        private async ValueTask<FetchPayoutSubaccountTransactions> TryCatch(ReturningFetchPayoutSubaccountTransactionsFunction returningFetchPayoutSubaccountTransactionsFunction)
        {
            try
            {
                return await returningFetchPayoutSubaccountTransactionsFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }
        private async ValueTask<FetchStaticVirtualAccounts> TryCatch(ReturningFetchStaticVirtualAccountsFunction returningFetchStaticVirtualAccountsFunction)
        {
            try
            {
                return await returningFetchStaticVirtualAccountsFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }

        private async ValueTask<FetchSubaccountAvailableBalance> TryCatch(ReturningFetchSubaccountAvailableBalanceFunction returningFetchSubaccountAvailableBalanceFunction)
        {
            try
            {
                return await returningFetchSubaccountAvailableBalanceFunction();
            }
            catch (NullPayoutSubaccountsException nullPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(nullPayoutSubaccountsException);
            }
            catch (InvalidPayoutSubaccountsException invalidPayoutSubaccountsException)
            {
                throw new PayoutSubaccountsValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPayoutSubaccountsException =
                    new InvalidConfigurationPayoutSubaccountsException(httpResponseUrlNotFoundException);

                throw new PayoutSubaccountsDependencyException(invalidConfigurationPayoutSubaccountsException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseUnauthorizedException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPayoutSubaccountsException =
                    new UnauthorizedPayoutSubaccountsException(httpResponseForbiddenException);

                throw new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPayoutSubaccountsException =
                    new NotFoundPayoutSubaccountsException(httpResponseNotFoundException);

                throw new PayoutSubaccountsDependencyValidationException(notFoundPayoutSubaccountsException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPayoutSubaccountsException =
                    new InvalidPayoutSubaccountsException(httpResponseBadRequestException);

                throw new PayoutSubaccountsDependencyValidationException(invalidPayoutSubaccountsException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPayoutSubaccountsException =
                    new ExcessiveCallPayoutSubaccountsException(httpResponseTooManyRequestsException);

                throw new PayoutSubaccountsDependencyValidationException(excessiveCallPayoutSubaccountsException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPayoutSubaccountsException =
                    new FailedServerPayoutSubaccountsException(httpResponseException);

                throw new PayoutSubaccountsDependencyException(failedServerPayoutSubaccountsException);
            }
            catch (Exception exception)
            {
                var failedPayoutSubaccountsServiceException =
                    new FailedPayoutSubaccountsServiceException(exception);

                throw new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);
            }
        }


    }
}