using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial interface IFlutterWaveBroker
    {
        ValueTask<ExternalAllSubscriptionsResponse> GetAllSubscriptionsAsync();

        ValueTask<ExternalSubscriptionResponse> PostActivateSubscriptionAsync(string subscriptionId);
        ValueTask<ExternalSubscriptionResponse> PostDeactivateSubscriptionAsync(string subscriptionId);

    }
}
