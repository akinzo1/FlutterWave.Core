



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePaymentPlansOfAccountAsync()
        {
            // given 

            dynamic createRandomPaymentPlansProperties =
                     CreateRandomPaymentPlansProperties();


            var randomExternalPaymentPlanResponse = new ExternalPaymentPlansResponse
            {

                Message = createRandomPaymentPlansProperties.Message,
                Status = createRandomPaymentPlansProperties.Status,
                Data = ((List<dynamic>)createRandomPaymentPlansProperties.Data).Select(data =>
                {
                    return new ExternalPaymentPlansResponse.Datum
                    {
                        Status = data.Status,
                        Name = data.Name,
                        Amount = data.Amount,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Duration = data.Duration,
                        Id = data.Id,
                        Interval = data.Interval,
                        PlanToken = data.PlanToken
                    };
                }).ToList(),

            };

            var randomPaymentPlanResponse = new PaymentPlansResponse
            {

                Message = createRandomPaymentPlansProperties.Message,
                Status = createRandomPaymentPlansProperties.Status,
                Data = ((List<dynamic>)createRandomPaymentPlansProperties.Data).Select(data =>
                {
                    return new PaymentPlansResponse.Datum
                    {
                        Status = data.Status,
                        Name = data.Name,
                        Amount = data.Amount,
                        CreatedAt = data.CreatedAt,
                        Currency = data.Currency,
                        Duration = data.Duration,
                        Id = data.Id,
                        Interval = data.Interval,
                        PlanToken = data.PlanToken
                    };
                }).ToList(),

            };

            var expectedPaymentPlan = new AllPaymentPlans
            {
                Response = randomPaymentPlanResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPaymentPlansAsync())
                    .ReturnsAsync(randomExternalPaymentPlanResponse);

            // when
            AllPaymentPlans actualPaymentPlan =
               await this.paymentPlanService.GetPaymentPlansAsync();

            // then
            actualPaymentPlan.Should().BeEquivalentTo(expectedPaymentPlan);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}