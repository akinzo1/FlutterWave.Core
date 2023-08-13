using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.OtpService
{
    internal partial class OtpService
    {
        private delegate ValueTask<CreateOtp> ReturningOtpFunction();

        private delegate ValueTask<ValidateOtp> ReturningValidateOtpFunction();

        private async ValueTask<CreateOtp> TryCatch(ReturningOtpFunction returningOtpFunction)
        {
            try
            {
                return await returningOtpFunction();
            }
            catch (NullOtpException nullOtpException)
            {
                throw new OtpValidationException(nullOtpException);
            }
            catch (InvalidOtpException invalidOtpException)
            {
                throw new OtpValidationException(invalidOtpException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationOtpException =
                    new InvalidConfigurationOtpException(httpResponseUrlNotFoundException);

                throw new OtpDependencyException(invalidConfigurationOtpException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedOtpException =
                    new UnauthorizedOtpException(httpResponseUnauthorizedException);

                throw new OtpDependencyException(unauthorizedOtpException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedOtpException =
                    new UnauthorizedOtpException(httpResponseForbiddenException);

                throw new OtpDependencyException(unauthorizedOtpException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundOtpException =
                    new NotFoundOtpException(httpResponseNotFoundException);

                throw new OtpDependencyValidationException(notFoundOtpException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidOtpException =
                    new InvalidOtpException(httpResponseBadRequestException);

                throw new OtpDependencyValidationException(invalidOtpException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallOtpException =
                    new ExcessiveCallOtpException(httpResponseTooManyRequestsException);

                throw new OtpDependencyValidationException(excessiveCallOtpException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerOtpException =
                    new FailedServerOtpException(httpResponseException);

                throw new OtpDependencyException(failedServerOtpException);
            }
            catch (Exception exception)
            {
                var failedOtpServiceException =
                    new FailedOtpServiceException(exception);

                throw new OtpServiceException(failedOtpServiceException);
            }
        }
        private async ValueTask<ValidateOtp> TryCatch(ReturningValidateOtpFunction returningValidateOtpFunction)
        {
            try
            {
                return await returningValidateOtpFunction();
            }
            catch (NullOtpException nullOtpException)
            {
                throw new OtpValidationException(nullOtpException);
            }
            catch (InvalidOtpException invalidOtpException)
            {
                throw new OtpValidationException(invalidOtpException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationOtpException =
                    new InvalidConfigurationOtpException(httpResponseUrlNotFoundException);

                throw new OtpDependencyException(invalidConfigurationOtpException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedOtpException =
                    new UnauthorizedOtpException(httpResponseUnauthorizedException);

                throw new OtpDependencyException(unauthorizedOtpException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedOtpException =
                    new UnauthorizedOtpException(httpResponseForbiddenException);

                throw new OtpDependencyException(unauthorizedOtpException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundOtpException =
                    new NotFoundOtpException(httpResponseNotFoundException);

                throw new OtpDependencyValidationException(notFoundOtpException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidOtpException =
                    new InvalidOtpException(httpResponseBadRequestException);

                throw new OtpDependencyValidationException(invalidOtpException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallOtpException =
                    new ExcessiveCallOtpException(httpResponseTooManyRequestsException);

                throw new OtpDependencyValidationException(excessiveCallOtpException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerOtpException =
                    new FailedServerOtpException(httpResponseException);

                throw new OtpDependencyException(failedServerOtpException);
            }
            catch (Exception exception)
            {
                var failedOtpServiceException =
                    new FailedOtpServiceException(exception);

                throw new OtpServiceException(failedOtpServiceException);
            }
        }


    }
}