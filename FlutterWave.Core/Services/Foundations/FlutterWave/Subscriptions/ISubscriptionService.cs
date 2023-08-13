using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.SubscriptionService
{
    internal interface ISubscriptionService
    {
        ValueTask<AllSubscription> GetAllSubscriptionsAsync();

        ValueTask<Subscription> PostActivateSubscriptionAsync(string subscriptionId);
        ValueTask<Subscription> PostDeactivateSubscriptionAsync(string subscriptionId);
    }
}
