using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PaymentPlanService
{
    internal partial class PaymentPlanService
    {
        private delegate ValueTask<PaymentPlan> ReturningPaymentPlanFunction();

        private delegate ValueTask<AllPaymentPlans> ReturningAllPaymentPlansFunction();

        private delegate ValueTask<UpdatePaymentPlan> ReturningUpdatePaymentPlanFunction();

        private delegate ValueTask<CreatePaymentPlan> ReturningCreatePaymentPlanFunction();
        private async ValueTask<PaymentPlan> TryCatch(ReturningPaymentPlanFunction returningPaymentPlanFunction)
        {
            try
            {
                return await returningPaymentPlanFunction();
            }
            catch (NullPaymentPlanException nullPaymentPlanException)
            {
                throw new PaymentPlanValidationException(nullPaymentPlanException);
            }
            catch (InvalidPaymentPlanException invalidPaymentPlanException)
            {
                throw new PaymentPlanValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPaymentPlanException =
                    new InvalidConfigurationPaymentPlanException(httpResponseUrlNotFoundException);

                throw new PaymentPlanDependencyException(invalidConfigurationPaymentPlanException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseUnauthorizedException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseForbiddenException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPaymentPlanException =
                    new NotFoundPaymentPlanException(httpResponseNotFoundException);

                throw new PaymentPlanDependencyValidationException(notFoundPaymentPlanException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPaymentPlanException =
                    new InvalidPaymentPlanException(httpResponseBadRequestException);

                throw new PaymentPlanDependencyValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPaymentPlanException =
                    new ExcessiveCallPaymentPlanException(httpResponseTooManyRequestsException);

                throw new PaymentPlanDependencyValidationException(excessiveCallPaymentPlanException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPaymentPlanException =
                    new FailedServerPaymentPlanException(httpResponseException);

                throw new PaymentPlanDependencyException(failedServerPaymentPlanException);
            }
            catch (Exception exception)
            {
                var failedPaymentPlanServiceException =
                    new FailedPaymentPlanServiceException(exception);

                throw new PaymentPlanServiceException(failedPaymentPlanServiceException);
            }
        }

        private async ValueTask<AllPaymentPlans> TryCatch(ReturningAllPaymentPlansFunction returningAllPaymentPlansFunction)
        {
            try
            {
                return await returningAllPaymentPlansFunction();
            }
            catch (NullPaymentPlanException nullPaymentPlanException)
            {
                throw new PaymentPlanValidationException(nullPaymentPlanException);
            }
            catch (InvalidPaymentPlanException invalidPaymentPlanException)
            {
                throw new PaymentPlanValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPaymentPlanException =
                    new InvalidConfigurationPaymentPlanException(httpResponseUrlNotFoundException);

                throw new PaymentPlanDependencyException(invalidConfigurationPaymentPlanException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseUnauthorizedException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseForbiddenException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPaymentPlanException =
                    new NotFoundPaymentPlanException(httpResponseNotFoundException);

                throw new PaymentPlanDependencyValidationException(notFoundPaymentPlanException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPaymentPlanException =
                    new InvalidPaymentPlanException(httpResponseBadRequestException);

                throw new PaymentPlanDependencyValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPaymentPlanException =
                    new ExcessiveCallPaymentPlanException(httpResponseTooManyRequestsException);

                throw new PaymentPlanDependencyValidationException(excessiveCallPaymentPlanException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPaymentPlanException =
                    new FailedServerPaymentPlanException(httpResponseException);

                throw new PaymentPlanDependencyException(failedServerPaymentPlanException);
            }
            catch (Exception exception)
            {
                var failedPaymentPlanServiceException =
                    new FailedPaymentPlanServiceException(exception);

                throw new PaymentPlanServiceException(failedPaymentPlanServiceException);
            }
        }

        private async ValueTask<UpdatePaymentPlan> TryCatch(ReturningUpdatePaymentPlanFunction returningUpdatePaymentPlanFunction)
        {
            try
            {
                return await returningUpdatePaymentPlanFunction();
            }
            catch (NullPaymentPlanException nullPaymentPlanException)
            {
                throw new PaymentPlanValidationException(nullPaymentPlanException);
            }
            catch (InvalidPaymentPlanException invalidPaymentPlanException)
            {
                throw new PaymentPlanValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPaymentPlanException =
                    new InvalidConfigurationPaymentPlanException(httpResponseUrlNotFoundException);

                throw new PaymentPlanDependencyException(invalidConfigurationPaymentPlanException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseUnauthorizedException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseForbiddenException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPaymentPlanException =
                    new NotFoundPaymentPlanException(httpResponseNotFoundException);

                throw new PaymentPlanDependencyValidationException(notFoundPaymentPlanException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPaymentPlanException =
                    new InvalidPaymentPlanException(httpResponseBadRequestException);

                throw new PaymentPlanDependencyValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPaymentPlanException =
                    new ExcessiveCallPaymentPlanException(httpResponseTooManyRequestsException);

                throw new PaymentPlanDependencyValidationException(excessiveCallPaymentPlanException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPaymentPlanException =
                    new FailedServerPaymentPlanException(httpResponseException);

                throw new PaymentPlanDependencyException(failedServerPaymentPlanException);
            }
            catch (Exception exception)
            {
                var failedPaymentPlanServiceException =
                    new FailedPaymentPlanServiceException(exception);

                throw new PaymentPlanServiceException(failedPaymentPlanServiceException);
            }
        }

        private async ValueTask<CreatePaymentPlan> TryCatch(ReturningCreatePaymentPlanFunction returningCreatePaymentPlanFunction)
        {
            try
            {
                return await returningCreatePaymentPlanFunction();
            }
            catch (NullPaymentPlanException nullPaymentPlanException)
            {
                throw new PaymentPlanValidationException(nullPaymentPlanException);
            }
            catch (InvalidPaymentPlanException invalidPaymentPlanException)
            {
                throw new PaymentPlanValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationPaymentPlanException =
                    new InvalidConfigurationPaymentPlanException(httpResponseUrlNotFoundException);

                throw new PaymentPlanDependencyException(invalidConfigurationPaymentPlanException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseUnauthorizedException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedPaymentPlanException =
                    new UnauthorizedPaymentPlanException(httpResponseForbiddenException);

                throw new PaymentPlanDependencyException(unauthorizedPaymentPlanException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundPaymentPlanException =
                    new NotFoundPaymentPlanException(httpResponseNotFoundException);

                throw new PaymentPlanDependencyValidationException(notFoundPaymentPlanException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidPaymentPlanException =
                    new InvalidPaymentPlanException(httpResponseBadRequestException);

                throw new PaymentPlanDependencyValidationException(invalidPaymentPlanException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallPaymentPlanException =
                    new ExcessiveCallPaymentPlanException(httpResponseTooManyRequestsException);

                throw new PaymentPlanDependencyValidationException(excessiveCallPaymentPlanException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerPaymentPlanException =
                    new FailedServerPaymentPlanException(httpResponseException);

                throw new PaymentPlanDependencyException(failedServerPaymentPlanException);
            }
            catch (Exception exception)
            {
                var failedPaymentPlanServiceException =
                    new FailedPaymentPlanServiceException(exception);

                throw new PaymentPlanServiceException(failedPaymentPlanServiceException);
            }
        }
    }
}