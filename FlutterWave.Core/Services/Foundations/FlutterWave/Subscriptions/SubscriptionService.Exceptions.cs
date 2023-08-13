using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService
{
    internal partial class SubscriptionService
    {
        private delegate ValueTask<Subscription> ReturningSubscriptionFunction();

        private delegate ValueTask<AllSubscription> ReturningAllSubscriptionFunction();
        private async ValueTask<Subscription> TryCatch(ReturningSubscriptionFunction returningSubscriptionFunction)
        {
            try
            {
                return await returningSubscriptionFunction();
            }
            catch (NullSubscriptionsException nullSubscriptionException)
            {
                throw new SubscriptionsValidationException(nullSubscriptionException);
            }
            catch (InvalidSubscriptionsException invalidSubscriptionException)
            {
                throw new SubscriptionsValidationException(invalidSubscriptionException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSubscriptionException =
                    new InvalidConfigurationSubscriptionsException(httpResponseUrlNotFoundException);

                throw new SubscriptionsDependencyException(invalidConfigurationSubscriptionException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSubscriptionException =
                    new UnauthorizedSubscriptionsException(httpResponseUnauthorizedException);

                throw new SubscriptionsDependencyException(unauthorizedSubscriptionException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSubscriptionException =
                    new UnauthorizedSubscriptionsException(httpResponseForbiddenException);

                throw new SubscriptionsDependencyException(unauthorizedSubscriptionException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSubscriptionException =
                    new NotFoundSubscriptionsException(httpResponseNotFoundException);

                throw new SubscriptionsDependencyValidationException(notFoundSubscriptionException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSubscriptionException =
                    new InvalidSubscriptionsException(httpResponseBadRequestException);

                throw new SubscriptionsDependencyValidationException(invalidSubscriptionException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSubscriptionException =
                    new ExcessiveCallSubscriptionsException(httpResponseTooManyRequestsException);

                throw new SubscriptionsDependencyValidationException(excessiveCallSubscriptionException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSubscriptionException =
                    new FailedServerSubscriptionsException(httpResponseException);

                throw new SubscriptionsDependencyException(failedServerSubscriptionException);
            }
            catch (Exception exception)
            {
                var failedSubscriptionServiceException =
                    new FailedSubscriptionsServiceException(exception);

                throw new SubscriptionsServiceException(failedSubscriptionServiceException);
            }
        }

        private async ValueTask<AllSubscription> TryCatch(ReturningAllSubscriptionFunction returningAllSubscriptionFunction)
        {
            try
            {
                return await returningAllSubscriptionFunction();
            }
            catch (NullSubscriptionsException nullSubscriptionException)
            {
                throw new SubscriptionsValidationException(nullSubscriptionException);
            }
            catch (InvalidSubscriptionsException invalidSubscriptionException)
            {
                throw new SubscriptionsValidationException(invalidSubscriptionException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationSubscriptionException =
                    new InvalidConfigurationSubscriptionsException(httpResponseUrlNotFoundException);

                throw new SubscriptionsDependencyException(invalidConfigurationSubscriptionException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedSubscriptionException =
                    new UnauthorizedSubscriptionsException(httpResponseUnauthorizedException);

                throw new SubscriptionsDependencyException(unauthorizedSubscriptionException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedSubscriptionException =
                    new UnauthorizedSubscriptionsException(httpResponseForbiddenException);

                throw new SubscriptionsDependencyException(unauthorizedSubscriptionException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundSubscriptionException =
                    new NotFoundSubscriptionsException(httpResponseNotFoundException);

                throw new SubscriptionsDependencyValidationException(notFoundSubscriptionException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidSubscriptionException =
                    new InvalidSubscriptionsException(httpResponseBadRequestException);

                throw new SubscriptionsDependencyValidationException(invalidSubscriptionException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallSubscriptionException =
                    new ExcessiveCallSubscriptionsException(httpResponseTooManyRequestsException);

                throw new SubscriptionsDependencyValidationException(excessiveCallSubscriptionException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerSubscriptionException =
                    new FailedServerSubscriptionsException(httpResponseException);

                throw new SubscriptionsDependencyException(failedServerSubscriptionException);
            }
            catch (Exception exception)
            {
                var failedSubscriptionServiceException =
                    new FailedSubscriptionsServiceException(exception);

                throw new SubscriptionsServiceException(failedSubscriptionServiceException);
            }
        }
    }
}