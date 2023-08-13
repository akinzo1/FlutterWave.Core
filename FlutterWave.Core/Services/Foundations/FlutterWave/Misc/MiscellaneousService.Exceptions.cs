using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.MiscService
{
    internal partial class MiscellaneousService
    {
        private delegate ValueTask<BvnConsent> ReturningBvnConsentFunction();

        private delegate ValueTask<BinVerification> ReturningBinVerificationFunction();

        private delegate ValueTask<BalanceByCurrencies> ReturningBalanceByCurrenciesFunction();

        private delegate ValueTask<BalanceByCurrency> ReturningBalanceByCurrencyFunction();

        private delegate ValueTask<BankAccountVerification> ReturningBankAccountVerificationFunction();

        private delegate ValueTask<Statement> ReturningStatementFunction();

        private async ValueTask<BvnConsent> TryCatch(ReturningBvnConsentFunction returningBvnConsentFunction)
        {
            try
            {
                return await returningBvnConsentFunction();
            }
            catch (NullMiscellaneousException nullMIscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMIscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMIscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMIscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMIscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMIscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMIscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMIscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMIscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMIscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMIscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMIscellaneousServiceException);
            }
        }

        private async ValueTask<BinVerification> TryCatch(ReturningBinVerificationFunction returningBinVerificationFunction)
        {
            try
            {
                return await returningBinVerificationFunction();
            }
            catch (NullMiscellaneousException nullMIscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMIscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMIscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMIscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMIscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMIscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMIscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMIscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMIscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMIscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMIscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMIscellaneousServiceException);
            }
        }

        private async ValueTask<BalanceByCurrencies> TryCatch(ReturningBalanceByCurrenciesFunction returningBalanceByCurrenciesFunction)
        {
            try
            {
                return await returningBalanceByCurrenciesFunction();
            }
            catch (NullMiscellaneousException nullMIscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMIscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMIscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMIscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMIscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMIscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMIscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMIscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMIscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMIscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMIscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMIscellaneousServiceException);
            }
        }

        private async ValueTask<BalanceByCurrency> TryCatch(ReturningBalanceByCurrencyFunction returningBalanceByCurrencyFunction)
        {
            try
            {
                return await returningBalanceByCurrencyFunction();
            }
            catch (NullMiscellaneousException nullMIscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMIscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMIscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMIscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMIscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMIscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMIscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMIscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMIscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMIscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMIscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMIscellaneousServiceException);
            }
        }

        private async ValueTask<BankAccountVerification> TryCatch(ReturningBankAccountVerificationFunction returningBankAccountVerificationFunction)
        {
            try
            {
                return await returningBankAccountVerificationFunction();
            }
            catch (NullMiscellaneousException nullMIscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMIscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMIscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMIscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMIscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMIscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMIscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMIscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMIscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMIscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMIscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMIscellaneousServiceException);
            }
        }

        private async ValueTask<Statement> TryCatch(ReturningStatementFunction returningStatementFunction)
        {
            try
            {
                return await returningStatementFunction();
            }
            catch (NullMiscellaneousException nullMIscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMIscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMIscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMIscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMIscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMIscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMIscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMIscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMIscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMIscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMIscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMIscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMIscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMIscellaneousServiceException);
            }
        }

    }
}