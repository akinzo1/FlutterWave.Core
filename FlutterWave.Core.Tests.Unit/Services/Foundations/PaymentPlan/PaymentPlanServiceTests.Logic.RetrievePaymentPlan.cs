



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldRetrievePaymentPlanOfAccountAsync()
        {
            // given 
            string inputPaymentPlanId = GetRandomString();


            dynamic createRandomPaymentPlanProperties =
                     CreateRandomPaymentPlanProperties();


            var randomExternalPaymentPlanResponse = new ExternalPaymentPlanResponse
            {

                Message = createRandomPaymentPlanProperties.Message,
                Status = createRandomPaymentPlanProperties.Status,
                Data = new ExternalPaymentPlanResponse.Datum
                {
                    Status = createRandomPaymentPlanProperties.Data.Status,
                    Name = createRandomPaymentPlanProperties.Data.Name,
                    Amount = createRandomPaymentPlanProperties.Data.Amount,
                    CreatedAt = createRandomPaymentPlanProperties.Data.CreatedAt,
                    Currency = createRandomPaymentPlanProperties.Data.Currency,
                    Duration = createRandomPaymentPlanProperties.Data.Duration,
                    Id = createRandomPaymentPlanProperties.Data.Id,
                    Interval = createRandomPaymentPlanProperties.Data.Interval,
                    PlanToken = createRandomPaymentPlanProperties.Data.PlanToken
                }

            };

            var randomPaymentPlanResponse = new PaymentPlanResponse
            {

                Message = createRandomPaymentPlanProperties.Message,
                Status = createRandomPaymentPlanProperties.Status,
                Data = new PaymentPlanResponse.Datum
                {
                    Status = createRandomPaymentPlanProperties.Data.Status,
                    Name = createRandomPaymentPlanProperties.Data.Name,
                    Amount = createRandomPaymentPlanProperties.Data.Amount,
                    CreatedAt = createRandomPaymentPlanProperties.Data.CreatedAt,
                    Currency = createRandomPaymentPlanProperties.Data.Currency,
                    Duration = createRandomPaymentPlanProperties.Data.Duration,
                    Id = createRandomPaymentPlanProperties.Data.Id,
                    Interval = createRandomPaymentPlanProperties.Data.Interval,
                    PlanToken = createRandomPaymentPlanProperties.Data.PlanToken
                }

            };

            var expectedPaymentPlan = new PaymentPlan
            {
                Response = randomPaymentPlanResponse
            };


            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPaymentPlanAsync(inputPaymentPlanId))
                    .ReturnsAsync(randomExternalPaymentPlanResponse);

            // when
            PaymentPlan actualPaymentPlan =
               await this.paymentPlanService.GetPaymentPlanAsync(inputPaymentPlanId);

            // then
            actualPaymentPlan.Should().BeEquivalentTo(expectedPaymentPlan);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlanAsync(inputPaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}