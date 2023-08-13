



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace FlutterWave.Core.Tests.Acceptance.Clients.SubscriptionClient
{
    public partial class SubscriptionClientTests
    {
        [Fact]
        public async Task ShouldRetrieveAllSubscriptionsAsync()
        {
            // given


            ExternalAllSubscriptionsResponse randomExternalAllSubscriptionsResponse =
                CreateExternalAllSubscriptionsResponseResult();

            ExternalAllSubscriptionsResponse retrieveSubscriptionResult =
                randomExternalAllSubscriptionsResponse;

            AllSubscription expectedSubscriptionsResponse =
                 ConvertToSubscriptionResponse(retrieveSubscriptionResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingGet()
                    .WithPath($"/v3/subscriptions")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrieveSubscriptionResult));

            // when
            AllSubscription actualResult =
                 await this.flutterWaveClient.Subscriptions.FetchAllSubscriptionsAsync();

            // then
            actualResult.Should().BeEquivalentTo(expectedSubscriptionsResponse);
        }
    }
}
