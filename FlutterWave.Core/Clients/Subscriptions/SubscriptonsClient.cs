using FlutterWave.Core.Models.Clients.Subscription.Exceptions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService;
using System.Text.Json;
using System.Threading.Tasks;
using Xeptions;

namespace FlutterWave.Core.Clients.OTP
{
    internal class SubscriptionsClient : ISubscriptionsClient
    {
        private readonly ISubscriptionService subscriptionsService;

        public SubscriptionsClient(ISubscriptionService subscriptionsService) =>
              this.subscriptionsService = subscriptionsService;

        public async ValueTask<AllSubscription> FetchAllSubscriptionsAsync()
        {
            try
            {
                return await subscriptionsService.GetAllSubscriptionsAsync();
            }
            catch (SubscriptionsValidationException SubscriptionValidationException)
            {
                throw new SubscriptionClientValidationException(
                    SubscriptionValidationException.InnerException as Xeption);
            }
            catch (SubscriptionsDependencyValidationException SubscriptionDependencyValidationException)
            {

                var message = SubscriptionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new AllSubscription
                    {
                        Response = new AllSubscriptionsResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new SubscriptionClientValidationException(
                    SubscriptionDependencyValidationException.InnerException as Xeption);
            }
            catch (SubscriptionsDependencyException SubscriptionDependencyException)
            {
                throw new SubscriptionClientDependencyException(
                    SubscriptionDependencyException.InnerException as Xeption);
            }
            catch (SubscriptionsServiceException SubscriptionServiceException)
            {
                throw new SubscriptionClientServiceException(
                    SubscriptionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Subscription> ActivateSubscriptionAsync(string subscriptionId)
        {
            try
            {
                return await subscriptionsService.PostActivateSubscriptionAsync(subscriptionId);
            }
            catch (SubscriptionsValidationException SubscriptionValidationException)
            {
                throw new SubscriptionClientValidationException(
                    SubscriptionValidationException.InnerException as Xeption);
            }
            catch (SubscriptionsDependencyValidationException SubscriptionDependencyValidationException)
            {

                var message = SubscriptionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Subscription
                    {
                        Response = new SubscriptionResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new SubscriptionClientValidationException(
                    SubscriptionDependencyValidationException.InnerException as Xeption);
            }
            catch (SubscriptionsDependencyException SubscriptionDependencyException)
            {
                throw new SubscriptionClientDependencyException(
                    SubscriptionDependencyException.InnerException as Xeption);
            }
            catch (SubscriptionsServiceException SubscriptionServiceException)
            {
                throw new SubscriptionClientServiceException(
                    SubscriptionServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Subscription> DeactivateSubscriptionAsync(string subscriptionId)
        {
            try
            {
                return await subscriptionsService.PostDeactivateSubscriptionAsync(subscriptionId);
            }
            catch (SubscriptionsValidationException SubscriptionValidationException)
            {
                throw new SubscriptionClientValidationException(
                    SubscriptionValidationException.InnerException as Xeption);
            }
            catch (SubscriptionsDependencyValidationException SubscriptionDependencyValidationException)
            {

                var message = SubscriptionDependencyValidationException.InnerException.InnerException.Message;
                if (message != null)
                {
                    ExternalErrorResponse bankBranches =
                        JsonSerializer.Deserialize<ExternalErrorResponse>(message);

                    return new Subscription
                    {
                        Response = new SubscriptionResponse
                        {
                            Message = bankBranches.Message,
                            Status = bankBranches.Status,
                        }
                    };
                }

                throw new SubscriptionClientValidationException(
                    SubscriptionDependencyValidationException.InnerException as Xeption);
            }
            catch (SubscriptionsDependencyException SubscriptionDependencyException)
            {
                throw new SubscriptionClientDependencyException(
                    SubscriptionDependencyException.InnerException as Xeption);
            }
            catch (SubscriptionsServiceException SubscriptionServiceException)
            {
                throw new SubscriptionClientServiceException(
                    SubscriptionServiceException.InnerException as Xeption);
            }
        }
    }
}
