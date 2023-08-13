



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
        public async Task ShouldPostActivateSubscriptionAsync()
        {
            // given
            string randomString = GetRandomString();
            string randomSubscriptionId = randomString;
            string inputSubscriptionId = randomSubscriptionId;

            ExternalSubscriptionResponse randomExternalSubscriptionResponse =
                CreateExternalSubscriptionResponseResult();

            ExternalSubscriptionResponse retrieveSubscriptionResult =
                randomExternalSubscriptionResponse;

            Subscription expectedBanksResponse =
                 ConvertToSubscriptionResponse(retrieveSubscriptionResult);

            this.wireMockServer.Given(
                Request.Create()
            .UsingPut()
                    .WithPath($"/v3/subscriptions/{inputSubscriptionId}/activate")
                    .WithHeader("Authorization", $"Bearer {this.apiKey}"))
                .RespondWith(
                    Response.Create()
                    .WithBodyAsJson(retrieveSubscriptionResult));

            // when
            Subscription actualResult =
                 await this.flutterWaveClient.Subscriptions.ActivateSubscriptionAsync(inputSubscriptionId);

            // then
            actualResult.Should().BeEquivalentTo(expectedBanksResponse);
        }
    }
}
