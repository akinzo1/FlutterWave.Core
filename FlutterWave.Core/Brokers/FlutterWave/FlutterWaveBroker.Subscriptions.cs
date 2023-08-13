using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions;
using System.Threading.Tasks;

namespace FlutterWave.Core
{
    internal partial class FlutterWaveBroker
    {




        public async ValueTask<ExternalAllSubscriptionsResponse> GetAllSubscriptionsAsync()
        {
            return await GetAsync<ExternalAllSubscriptionsResponse>(
                relativeUrl: "v3/subscriptions");
        }

        public async ValueTask<ExternalSubscriptionResponse> PostActivateSubscriptionAsync(string subscriptionId)
        {
            return await PutAsync<ExternalSubscriptionResponse>(
                relativeUrl: $"v3/subscriptions/{subscriptionId}/activate", content: null);
        }

        public async ValueTask<ExternalSubscriptionResponse> PostDeactivateSubscriptionAsync(string subscriptionId)
        {
            return await PutAsync<ExternalSubscriptionResponse>(
                relativeUrl: $"v3/subscriptions/{subscriptionId}/cancel", content: null);
        }

    }
}
