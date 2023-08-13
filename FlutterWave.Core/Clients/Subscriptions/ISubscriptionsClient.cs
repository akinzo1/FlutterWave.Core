using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.OTP
{
    public interface ISubscriptionsClient
    {
        /// <exception cref="ChatCompletionClientValidationException" />
        /// <exception cref="ChatCompletionClientDependencyException" />
        /// <exception cref="ChatCompletionClientServiceException" />
        ValueTask<AllSubscription> FetchAllSubscriptionsAsync();

        ValueTask<Subscription> ActivateSubscriptionAsync(string subscriptionId);
        ValueTask<Subscription> DeactivateSubscriptionAsync(string subscriptionId);
    }
}
