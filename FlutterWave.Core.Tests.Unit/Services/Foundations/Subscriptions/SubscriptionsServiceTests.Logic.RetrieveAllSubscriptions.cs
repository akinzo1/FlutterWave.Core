



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
        public async Task ShouldRetrieveAllSubscriptionsOfAccountAsync()
        {
            // given 

            dynamic createRandomSubscriptionsProperties =
                     CreateRandomAllSubscriptionsProperties();



            var randomExternalSubscriptionResponse = new ExternalAllSubscriptionsResponse
            {

                Message = createRandomSubscriptionsProperties.Message,
                Status = createRandomSubscriptionsProperties.Status,
                Meta = new ExternalAllSubscriptionsResponse.ExternalSubscriptionsMeta
                {
                    PageInfo = new ExternalAllSubscriptionsResponse.PageInfo
                    {
                        CurrentPage = createRandomSubscriptionsProperties.Meta.CurrentPage,
                        Total = createRandomSubscriptionsProperties.Meta.Total,
                        TotalPages = createRandomSubscriptionsProperties.Meta.TotalPages
                    },
                },
                Data = ((List<dynamic>)createRandomSubscriptionsProperties.Data).Select(data =>
                {
                    return new ExternalAllSubscriptionsResponse.Datum
                    {
                        Amount = data.Amount,
                        CreatedAt = data.CreatedAt,
                        Customer = new ExternalAllSubscriptionsResponse.Customer
                        {
                            Id = data.Customer.Id,
                            CustomerEmail = data.Customer.CustomerEmail
                        },
                        Id = data.Id,
                        Plan = data.Plan,
                        Status = data.Status
                    };
                }).ToList(),




            };

            var randomSubscriptionsResponse = new AllSubscriptionsResponse
            {

                Message = createRandomSubscriptionsProperties.Message,
                Status = createRandomSubscriptionsProperties.Status,
                Meta = new AllSubscriptionsResponse.SubscriptionsMeta
                {
                    PageInfo = new AllSubscriptionsResponse.PageInfo
                    {
                        CurrentPage = createRandomSubscriptionsProperties.Meta.CurrentPage,
                        Total = createRandomSubscriptionsProperties.Meta.Total,
                        TotalPages = createRandomSubscriptionsProperties.Meta.TotalPages
                    },
                },
                Data = ((List<dynamic>)createRandomSubscriptionsProperties.Data).Select(data =>
                {
                    return new AllSubscriptionsResponse.Datum
                    {
                        Amount = data.Amount,
                        CreatedAt = data.CreatedAt,
                        Customer = new AllSubscriptionsResponse.Customer
                        {
                            Id = data.Customer.Id,
                            CustomerEmail = data.Customer.CustomerEmail
                        },
                        Id = data.Id,
                        Plan = data.Plan,
                        Status = data.Status
                    };
                }).ToList(),

            };


            var expectedSubscriptions = new AllSubscription
            {
                Response = randomSubscriptionsResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllSubscriptionsAsync())
                    .ReturnsAsync(randomExternalSubscriptionResponse);

            // when
            AllSubscription actualSubscriptions =
               await this.subscriptionsService.GetAllSubscriptionsAsync();

            // then
            actualSubscriptions.Should().BeEquivalentTo(expectedSubscriptions);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllSubscriptionsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}