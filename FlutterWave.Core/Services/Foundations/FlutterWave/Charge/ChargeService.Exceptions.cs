using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeService
{
    internal partial class ChargeService
    {
        private delegate ValueTask<ACHPayments> ReturningACHPaymentsFunction();
        private delegate ValueTask<GooglePay> ReturningGooglePayFunction();
        private delegate ValueTask<Fawry> ReturningFawryFunction();
        private delegate ValueTask<ZambiaMobileMoney> ReturningZambiaMobileMoneyFunction();
        private delegate ValueTask<GhanaMobileMoney> ReturningGhanaMobileMoneyFunction();
        private delegate ValueTask<RwandaMobileMoney> ReturningRwandaMobileMoneyFunction();
        private delegate ValueTask<TanzaniaMobileMoney> ReturningTanzaniaMobileMoneyFunction();
        private delegate ValueTask<ApplePay> ReturningApplePayFunction();
        private delegate ValueTask<BankTransfer> ReturningBankTransferFunction();
        private delegate ValueTask<NGBankAccounts> ReturningNGBankAccountsFunction();
        private delegate ValueTask<CardCharge> ReturningCardChargeFunction();
        private delegate ValueTask<ENaira> ReturningENairaFunction();
        private delegate ValueTask<FrancophoneMobileMoney> ReturningFrancophoneMobileMoneyFunction();
        private delegate ValueTask<Mpesa> ReturningMpesaFunction();
        private delegate ValueTask<PayPal> ReturningPayPalFunction();
        private delegate ValueTask<UgandaMobileMoney> ReturningUgandaMobileMoneyFunction();
        private delegate ValueTask<UkEuBankAccounts> ReturningUkEuBankAccountsFunction();
        private delegate ValueTask<USSD> ReturningUSSDFunction();
        private delegate ValueTask<ValidateCharge> ReturningValidateChargeFunction();
        private async ValueTask<ACHPayments> TryCatch(ReturningACHPaymentsFunction returningACHPaymentsFunction)
        {
            try
            {
                return await returningACHPaymentsFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<GooglePay> TryCatch(ReturningGooglePayFunction returningGooglePayFunction)
        {
            try
            {
                return await returningGooglePayFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<Fawry> TryCatch(ReturningFawryFunction returningFawryFunction)
        {
            try
            {
                return await returningFawryFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<ZambiaMobileMoney> TryCatch(ReturningZambiaMobileMoneyFunction returningZambiaMobileMoneyFunction)
        {
            try
            {
                return await returningZambiaMobileMoneyFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<GhanaMobileMoney> TryCatch(ReturningGhanaMobileMoneyFunction returningGhanaMobileMoneyFunction)
        {
            try
            {
                return await returningGhanaMobileMoneyFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<RwandaMobileMoney> TryCatch(ReturningRwandaMobileMoneyFunction returningRwandaMobileMoneyFunction)
        {
            try
            {
                return await returningRwandaMobileMoneyFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<TanzaniaMobileMoney> TryCatch(ReturningTanzaniaMobileMoneyFunction returningTanzaniaMobileMoneyFunction)
        {
            try
            {
                return await returningTanzaniaMobileMoneyFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<ApplePay> TryCatch(ReturningApplePayFunction returningApplePayFunction)
        {
            try
            {
                return await returningApplePayFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<BankTransfer> TryCatch(ReturningBankTransferFunction returningBankTransferFunction)
        {
            try
            {
                return await returningBankTransferFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<NGBankAccounts> TryCatch(ReturningNGBankAccountsFunction returningNGBankAccountsFunction)
        {
            try
            {
                return await returningNGBankAccountsFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<CardCharge> TryCatch(ReturningCardChargeFunction returningCardChargeFunction)
        {
            try
            {
                return await returningCardChargeFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<ENaira> TryCatch(ReturningENairaFunction returningENairaFunction)
        {
            try
            {
                return await returningENairaFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<FrancophoneMobileMoney> TryCatch(ReturningFrancophoneMobileMoneyFunction returningFrancophoneMobileMoneyFunction)
        {
            try
            {
                return await returningFrancophoneMobileMoneyFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<Mpesa> TryCatch(ReturningMpesaFunction returningMpesaFunction)
        {
            try
            {
                return await returningMpesaFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<PayPal> TryCatch(ReturningPayPalFunction returningPayPalFunction)
        {
            try
            {
                return await returningPayPalFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<UgandaMobileMoney> TryCatch(ReturningUgandaMobileMoneyFunction returningUgandaMobileMoneyFunction)
        {
            try
            {
                return await returningUgandaMobileMoneyFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<UkEuBankAccounts> TryCatch(ReturningUkEuBankAccountsFunction returningUkEuBankAccountsFunction)
        {
            try
            {
                return await returningUkEuBankAccountsFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<USSD> TryCatch(ReturningUSSDFunction returningUSSDFunction)
        {
            try
            {
                return await returningUSSDFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }
        private async ValueTask<ValidateCharge> TryCatch(ReturningValidateChargeFunction returningValidateChargeFunction)
        {
            try
            {
                return await returningValidateChargeFunction();
            }
            catch (NullChargeException nullChargeException)
            {
                throw new ChargeValidationException(nullChargeException);
            }
            catch (InvalidChargeException invalidChargeException)
            {
                throw new ChargeValidationException(invalidChargeException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeException =
                    new InvalidConfigurationChargeException(httpResponseUrlNotFoundException);

                throw new ChargeDependencyException(invalidConfigurationChargeException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseUnauthorizedException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeException =
                    new UnauthorizedChargeException(httpResponseForbiddenException);

                throw new ChargeDependencyException(unauthorizedChargeException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeException =
                    new NotFoundChargeException(httpResponseNotFoundException);

                throw new ChargeDependencyValidationException(notFoundChargeException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeException =
                    new InvalidChargeException(httpResponseBadRequestException);

                throw new ChargeDependencyValidationException(invalidChargeException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeException =
                    new ExcessiveCallChargeException(httpResponseTooManyRequestsException);

                throw new ChargeDependencyValidationException(excessiveCallChargeException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeException =
                    new FailedServerChargeException(httpResponseException);

                throw new ChargeDependencyException(failedServerChargeException);
            }
            catch (Exception exception)
            {
                var failedChargeServiceException =
                    new FailedChargeServiceException(exception);

                throw new ChargeServiceException(failedChargeServiceException);
            }
        }

    }
}