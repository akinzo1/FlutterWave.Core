using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService
{
    internal partial class PreauthorizationService
    {
        private delegate ValueTask<CaptureCharge> ReturningCaptureChargeFunction();
        private delegate ValueTask<CapturePayPalCharge> ReturningCapturePayPalChargeFunction();
        private delegate ValueTask<CreateCharge> ReturningCreateChargeFunction();
        private delegate ValueTask<CreatePreauthorizationRefund> ReturningCreatePreauthorizationRefundFunction();
        private delegate ValueTask<VoidCharge> ReturningVoidChargeFunction();
        private delegate ValueTask<VoidPayPalCharge> ReturningVoidPayPalChargeFunction();


        private async ValueTask<CaptureCharge> TryCatch(ReturningCaptureChargeFunction returningCaptureChargeFunction)
        {
            try
            {
                return await returningCaptureChargeFunction();
            }
            catch (NullPreauthorizationException nullPreauthorizationException)
            {
                throw new PreauthorizationValidationException(nullPreauthorizationException);
            }
            catch (InvalidPreauthorizationException invalidPreauthorizationException)
            {
                throw new PreauthorizationValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPreauthorizationException =
                    new InvalidConfigurationPreauthorizationException(httpResponseUrlNotFoundException);

                throw new PreauthorizationDependencyException(invalidConfigurationPreauthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseUnauthorizedException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseForbiddenException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPreauthorizationException =
                    new NotFoundPreauthorizationException(httpResponseNotFoundException);

                throw new PreauthorizationDependencyValidationException(notFoundPreauthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPreauthorizationException =
                    new InvalidPreauthorizationException(httpResponseBadRequestException);

                throw new PreauthorizationDependencyValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPreauthorizationException =
                    new ExcessiveCallPreauthorizationException(httpResponseTooManyRequestsException);

                throw new PreauthorizationDependencyValidationException(excessiveCallPreauthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPreauthorizationException =
                    new FailedServerPreauthorizationException(httpResponseException);

                throw new PreauthorizationDependencyException(failedServerPreauthorizationException);
            }
            catch (Exception exception)
            {
                var failedPreauthorizationServiceException =
                    new FailedPreauthorizationServiceException(exception);

                throw new PreauthorizationServiceException(failedPreauthorizationServiceException);
            }
        }
        private async ValueTask<CapturePayPalCharge> TryCatch(ReturningCapturePayPalChargeFunction returningCapturePayPalChargeFunction)
        {
            try
            {
                return await returningCapturePayPalChargeFunction();
            }
            catch (NullPreauthorizationException nullPreauthorizationException)
            {
                throw new PreauthorizationValidationException(nullPreauthorizationException);
            }
            catch (InvalidPreauthorizationException invalidPreauthorizationException)
            {
                throw new PreauthorizationValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPreauthorizationException =
                    new InvalidConfigurationPreauthorizationException(httpResponseUrlNotFoundException);

                throw new PreauthorizationDependencyException(invalidConfigurationPreauthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseUnauthorizedException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseForbiddenException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPreauthorizationException =
                    new NotFoundPreauthorizationException(httpResponseNotFoundException);

                throw new PreauthorizationDependencyValidationException(notFoundPreauthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPreauthorizationException =
                    new InvalidPreauthorizationException(httpResponseBadRequestException);

                throw new PreauthorizationDependencyValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPreauthorizationException =
                    new ExcessiveCallPreauthorizationException(httpResponseTooManyRequestsException);

                throw new PreauthorizationDependencyValidationException(excessiveCallPreauthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPreauthorizationException =
                    new FailedServerPreauthorizationException(httpResponseException);

                throw new PreauthorizationDependencyException(failedServerPreauthorizationException);
            }
            catch (Exception exception)
            {
                var failedPreauthorizationServiceException =
                    new FailedPreauthorizationServiceException(exception);

                throw new PreauthorizationServiceException(failedPreauthorizationServiceException);
            }
        }
        private async ValueTask<CreateCharge> TryCatch(ReturningCreateChargeFunction returningCreateChargeFunction)
        {
            try
            {
                return await returningCreateChargeFunction();
            }
            catch (NullPreauthorizationException nullPreauthorizationException)
            {
                throw new PreauthorizationValidationException(nullPreauthorizationException);
            }
            catch (InvalidPreauthorizationException invalidPreauthorizationException)
            {
                throw new PreauthorizationValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPreauthorizationException =
                    new InvalidConfigurationPreauthorizationException(httpResponseUrlNotFoundException);

                throw new PreauthorizationDependencyException(invalidConfigurationPreauthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseUnauthorizedException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseForbiddenException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPreauthorizationException =
                    new NotFoundPreauthorizationException(httpResponseNotFoundException);

                throw new PreauthorizationDependencyValidationException(notFoundPreauthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPreauthorizationException =
                    new InvalidPreauthorizationException(httpResponseBadRequestException);

                throw new PreauthorizationDependencyValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPreauthorizationException =
                    new ExcessiveCallPreauthorizationException(httpResponseTooManyRequestsException);

                throw new PreauthorizationDependencyValidationException(excessiveCallPreauthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPreauthorizationException =
                    new FailedServerPreauthorizationException(httpResponseException);

                throw new PreauthorizationDependencyException(failedServerPreauthorizationException);
            }
            catch (Exception exception)
            {
                var failedPreauthorizationServiceException =
                    new FailedPreauthorizationServiceException(exception);

                throw new PreauthorizationServiceException(failedPreauthorizationServiceException);
            }
        }

        private async ValueTask<CreatePreauthorizationRefund> TryCatch(ReturningCreatePreauthorizationRefundFunction returningCreatePreauthorizationRefundFunction)
        {
            try
            {
                return await returningCreatePreauthorizationRefundFunction();
            }
            catch (NullPreauthorizationException nullPreauthorizationException)
            {
                throw new PreauthorizationValidationException(nullPreauthorizationException);
            }
            catch (InvalidPreauthorizationException invalidPreauthorizationException)
            {
                throw new PreauthorizationValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPreauthorizationException =
                    new InvalidConfigurationPreauthorizationException(httpResponseUrlNotFoundException);

                throw new PreauthorizationDependencyException(invalidConfigurationPreauthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseUnauthorizedException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseForbiddenException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPreauthorizationException =
                    new NotFoundPreauthorizationException(httpResponseNotFoundException);

                throw new PreauthorizationDependencyValidationException(notFoundPreauthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPreauthorizationException =
                    new InvalidPreauthorizationException(httpResponseBadRequestException);

                throw new PreauthorizationDependencyValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPreauthorizationException =
                    new ExcessiveCallPreauthorizationException(httpResponseTooManyRequestsException);

                throw new PreauthorizationDependencyValidationException(excessiveCallPreauthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPreauthorizationException =
                    new FailedServerPreauthorizationException(httpResponseException);

                throw new PreauthorizationDependencyException(failedServerPreauthorizationException);
            }
            catch (Exception exception)
            {
                var failedPreauthorizationServiceException =
                    new FailedPreauthorizationServiceException(exception);

                throw new PreauthorizationServiceException(failedPreauthorizationServiceException);
            }
        }
        private async ValueTask<VoidCharge> TryCatch(ReturningVoidChargeFunction returningVoidChargeFunction)
        {
            try
            {
                return await returningVoidChargeFunction();
            }
            catch (NullPreauthorizationException nullPreauthorizationException)
            {
                throw new PreauthorizationValidationException(nullPreauthorizationException);
            }
            catch (InvalidPreauthorizationException invalidPreauthorizationException)
            {
                throw new PreauthorizationValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPreauthorizationException =
                    new InvalidConfigurationPreauthorizationException(httpResponseUrlNotFoundException);

                throw new PreauthorizationDependencyException(invalidConfigurationPreauthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseUnauthorizedException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseForbiddenException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPreauthorizationException =
                    new NotFoundPreauthorizationException(httpResponseNotFoundException);

                throw new PreauthorizationDependencyValidationException(notFoundPreauthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPreauthorizationException =
                    new InvalidPreauthorizationException(httpResponseBadRequestException);

                throw new PreauthorizationDependencyValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPreauthorizationException =
                    new ExcessiveCallPreauthorizationException(httpResponseTooManyRequestsException);

                throw new PreauthorizationDependencyValidationException(excessiveCallPreauthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPreauthorizationException =
                    new FailedServerPreauthorizationException(httpResponseException);

                throw new PreauthorizationDependencyException(failedServerPreauthorizationException);
            }
            catch (Exception exception)
            {
                var failedPreauthorizationServiceException =
                    new FailedPreauthorizationServiceException(exception);

                throw new PreauthorizationServiceException(failedPreauthorizationServiceException);
            }
        }
        private async ValueTask<VoidPayPalCharge> TryCatch(ReturningVoidPayPalChargeFunction returningVoidPayPalChargeFunction)
        {
            try
            {
                return await returningVoidPayPalChargeFunction();
            }
            catch (NullPreauthorizationException nullPreauthorizationException)
            {
                throw new PreauthorizationValidationException(nullPreauthorizationException);
            }
            catch (InvalidPreauthorizationException invalidPreauthorizationException)
            {
                throw new PreauthorizationValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPreauthorizationException =
                    new InvalidConfigurationPreauthorizationException(httpResponseUrlNotFoundException);

                throw new PreauthorizationDependencyException(invalidConfigurationPreauthorizationException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseUnauthorizedException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPreauthorizationException =
                    new UnauthorizedPreauthorizationException(httpResponseForbiddenException);

                throw new PreauthorizationDependencyException(unauthorizedPreauthorizationException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPreauthorizationException =
                    new NotFoundPreauthorizationException(httpResponseNotFoundException);

                throw new PreauthorizationDependencyValidationException(notFoundPreauthorizationException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPreauthorizationException =
                    new InvalidPreauthorizationException(httpResponseBadRequestException);

                throw new PreauthorizationDependencyValidationException(invalidPreauthorizationException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPreauthorizationException =
                    new ExcessiveCallPreauthorizationException(httpResponseTooManyRequestsException);

                throw new PreauthorizationDependencyValidationException(excessiveCallPreauthorizationException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPreauthorizationException =
                    new FailedServerPreauthorizationException(httpResponseException);

                throw new PreauthorizationDependencyException(failedServerPreauthorizationException);
            }
            catch (Exception exception)
            {
                var failedPreauthorizationServiceException =
                    new FailedPreauthorizationServiceException(exception);

                throw new PreauthorizationServiceException(failedPreauthorizationServiceException);
            }
        }

    }
}