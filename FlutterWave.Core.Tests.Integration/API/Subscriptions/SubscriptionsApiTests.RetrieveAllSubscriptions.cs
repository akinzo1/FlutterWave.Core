using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;

namespace FlutterWave.Core.Tests.Integration.API.Subscriptions
{
    public partial class SubscriptionsApiTests
    {
        [Fact]
        public async Task ShouldRetrieveAllSubscriptionsAsync()
        {

            // given

            // . when
            AllSubscription responseAIModels =
                await this.flutterWaveClient.Subscriptions.FetchAllSubscriptionsAsync();

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
