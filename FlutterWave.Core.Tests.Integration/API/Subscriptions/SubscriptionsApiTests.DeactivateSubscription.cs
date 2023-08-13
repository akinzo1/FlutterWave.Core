using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;

namespace FlutterWave.Core.Tests.Integration.API.Subscriptions
{
    public partial class SubscriptionsApiTests
    {
        [Fact]
        public async Task ShouldDeactivateSubscriptionAsync()
        {
            // given
            string inputSubscriptionId = "yuyutr";

            // when
            Subscription retrievedAIModel =
              await this.flutterWaveClient.Subscriptions.DeactivateSubscriptionAsync(inputSubscriptionId);

            // then
            Assert.NotNull(retrievedAIModel);
        }
    }
}