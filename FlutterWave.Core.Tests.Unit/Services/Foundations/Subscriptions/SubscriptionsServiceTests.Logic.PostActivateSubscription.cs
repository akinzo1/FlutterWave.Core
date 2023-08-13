



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalSubscriptions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscriptions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Subscriptions
{
    public partial class SubscriptionsServiceTests
    {
        [Fact]
        public async Task ShouldPostActivateSubscriptionByIdAsync()
        {
            // given 
            string inputSubscriptionId = GetRandomString();
            dynamic createRandomSubscriptionsProperties =
                     CreateRandomActivateSubscriptionsProperties();


            var randomExternalSubscriptionResponse = new ExternalSubscriptionResponse
            {

                Message = createRandomSubscriptionsProperties.Message,
                Status = createRandomSubscriptionsProperties.Status,
                Data = new ExternalSubscriptionResponse.ExternalSubscriptionData
                {
                    Amount = createRandomSubscriptionsProperties.Data.Amount,
                    CreatedAt = createRandomSubscriptionsProperties.Data.CreatedAt,
                    Customer = new ExternalSubscriptionResponse.Customer
                    {
                        Id = createRandomSubscriptionsProperties.Data.Customer.Id,
                        CustomerEmail = createRandomSubscriptionsProperties.Data.Customer.CustomerEmail
                    },
                    Id = createRandomSubscriptionsProperties.Data.Id,
                    Plan = createRandomSubscriptionsProperties.Data.Plan,
                    Status = createRandomSubscriptionsProperties.Data.Status
                }


            };

            var randomSubscriptionsResponse = new SubscriptionResponse
            {

                Message = createRandomSubscriptionsProperties.Message,
                Status = createRandomSubscriptionsProperties.Status,
                Data = new SubscriptionResponse.SubscriptionData
                {

                    Amount = createRandomSubscriptionsProperties.Data.Amount,
                    CreatedAt = createRandomSubscriptionsProperties.Data.CreatedAt,
                    Customer = new SubscriptionResponse.Customer
                    {
                        Id = createRandomSubscriptionsProperties.Data.Customer.Id,
                        CustomerEmail = createRandomSubscriptionsProperties.Data.Customer.CustomerEmail
                    },
                    Id = createRandomSubscriptionsProperties.Data.Id,
                    Plan = createRandomSubscriptionsProperties.Data.Plan,
                    Status = createRandomSubscriptionsProperties.Data.Status

                }

            };

            var expectedSubscriptions = new Subscription
            {
                Response = randomSubscriptionsResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostActivateSubscriptionAsync(inputSubscriptionId))
                    .ReturnsAsync(randomExternalSubscriptionResponse);

            // when
            Subscription actualSubscriptions =
               await this.subscriptionsService.PostActivateSubscriptionAsync(inputSubscriptionId);

            // then
            actualSubscriptions.Should().BeEquivalentTo(expectedSubscriptions);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostActivateSubscriptionAsync(inputSubscriptionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}