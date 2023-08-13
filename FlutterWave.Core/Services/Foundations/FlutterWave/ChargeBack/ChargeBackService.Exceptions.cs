using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.ChargeBackService
{
    internal partial class ChargeBackService
    {
        private delegate ValueTask<AcceptDeclineChargeBack> ReturningAcceptDeclineChargeBackFunction();

        private delegate ValueTask<ChargeBack> ReturningChargeBackFunction();

        private delegate ValueTask<AllChargeBacks> ReturningAllChargeBackFunction();


        private async ValueTask<AcceptDeclineChargeBack> TryCatch(ReturningAcceptDeclineChargeBackFunction returningAcceptDeclineChargeBackFunction)
        {
            try
            {
                return await returningAcceptDeclineChargeBackFunction();
            }
            catch (NullChargeBackException nullChargeBackException)
            {
                throw new ChargeBackValidationException(nullChargeBackException);
            }
            catch (InvalidChargeBackException invalidChargeBackException)
            {
                throw new ChargeBackValidationException(invalidChargeBackException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeBackException =
                    new InvalidConfigurationChargeBackException(httpResponseUrlNotFoundException);

                throw new ChargeBackDependencyException(invalidConfigurationChargeBackException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeBackException =
                    new UnauthorizedChargeBackException(httpResponseUnauthorizedException);

                throw new ChargeBackDependencyException(unauthorizedChargeBackException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeBackException =
                    new UnauthorizedChargeBackException(httpResponseForbiddenException);

                throw new ChargeBackDependencyException(unauthorizedChargeBackException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeBackException =
                    new NotFoundChargeBackException(httpResponseNotFoundException);

                throw new ChargeBackDependencyValidationException(notFoundChargeBackException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeBackException =
                    new InvalidChargeBackException(httpResponseBadRequestException);

                throw new ChargeBackDependencyValidationException(invalidChargeBackException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeBackException =
                    new ExcessiveCallChargeBackException(httpResponseTooManyRequestsException);

                throw new ChargeBackDependencyValidationException(excessiveCallChargeBackException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeBackException =
                    new FailedServerChargeBackException(httpResponseException);

                throw new ChargeBackDependencyException(failedServerChargeBackException);
            }
            catch (Exception exception)
            {
                var failedChargeBackServiceException =
                    new FailedChargeBackServiceException(exception);

                throw new ChargeBackServiceException(failedChargeBackServiceException);
            }
        }
        private async ValueTask<ChargeBack> TryCatch(ReturningChargeBackFunction returningChargeBackFunction)
        {
            try
            {
                return await returningChargeBackFunction();
            }
            catch (NullChargeBackException nullChargeBackException)
            {
                throw new ChargeBackValidationException(nullChargeBackException);
            }
            catch (InvalidChargeBackException invalidChargeBackException)
            {
                throw new ChargeBackValidationException(invalidChargeBackException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeBackException =
                    new InvalidConfigurationChargeBackException(httpResponseUrlNotFoundException);

                throw new ChargeBackDependencyException(invalidConfigurationChargeBackException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeBackException =
                    new UnauthorizedChargeBackException(httpResponseUnauthorizedException);

                throw new ChargeBackDependencyException(unauthorizedChargeBackException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeBackException =
                    new UnauthorizedChargeBackException(httpResponseForbiddenException);

                throw new ChargeBackDependencyException(unauthorizedChargeBackException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeBackException =
                    new NotFoundChargeBackException(httpResponseNotFoundException);

                throw new ChargeBackDependencyValidationException(notFoundChargeBackException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeBackException =
                    new InvalidChargeBackException(httpResponseBadRequestException);

                throw new ChargeBackDependencyValidationException(invalidChargeBackException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeBackException =
                    new ExcessiveCallChargeBackException(httpResponseTooManyRequestsException);

                throw new ChargeBackDependencyValidationException(excessiveCallChargeBackException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeBackException =
                    new FailedServerChargeBackException(httpResponseException);

                throw new ChargeBackDependencyException(failedServerChargeBackException);
            }
            catch (Exception exception)
            {
                var failedChargeBackServiceException =
                    new FailedChargeBackServiceException(exception);

                throw new ChargeBackServiceException(failedChargeBackServiceException);
            }
        }
        private async ValueTask<AllChargeBacks> TryCatch(ReturningAllChargeBackFunction returningAllChargeBackFunction)
        {
            try
            {
                return await returningAllChargeBackFunction();
            }
            catch (NullChargeBackException nullChargeBackException)
            {
                throw new ChargeBackValidationException(nullChargeBackException);
            }
            catch (InvalidChargeBackException invalidChargeBackException)
            {
                throw new ChargeBackValidationException(invalidChargeBackException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationChargeBackException =
                    new InvalidConfigurationChargeBackException(httpResponseUrlNotFoundException);

                throw new ChargeBackDependencyException(invalidConfigurationChargeBackException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedChargeBackException =
                    new UnauthorizedChargeBackException(httpResponseUnauthorizedException);

                throw new ChargeBackDependencyException(unauthorizedChargeBackException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedChargeBackException =
                    new UnauthorizedChargeBackException(httpResponseForbiddenException);

                throw new ChargeBackDependencyException(unauthorizedChargeBackException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundChargeBackException =
                    new NotFoundChargeBackException(httpResponseNotFoundException);

                throw new ChargeBackDependencyValidationException(notFoundChargeBackException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidChargeBackException =
                    new InvalidChargeBackException(httpResponseBadRequestException);

                throw new ChargeBackDependencyValidationException(invalidChargeBackException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallChargeBackException =
                    new ExcessiveCallChargeBackException(httpResponseTooManyRequestsException);

                throw new ChargeBackDependencyValidationException(excessiveCallChargeBackException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerChargeBackException =
                    new FailedServerChargeBackException(httpResponseException);

                throw new ChargeBackDependencyException(failedServerChargeBackException);
            }
            catch (Exception exception)
            {
                var failedChargeBackServiceException =
                    new FailedChargeBackServiceException(exception);

                throw new ChargeBackServiceException(failedChargeBackServiceException);
            }
        }

    }
}