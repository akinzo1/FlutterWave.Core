



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldPostCreatePaymentPlanWithCreatePaymentPlanRequestAsync()
        {
            // given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            dynamic createRandomPaymentPlanProperties =
                   CreateRandomPaymentPlanProperties();


            var randomExternalCreatePaymentPlanRequest = new ExternalCreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };


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



            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {

                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName
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

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
            };

            CreatePaymentPlan inputCreatePaymentPlan = randomCreatePaymentPlan;
            CreatePaymentPlan expectedCreatePaymentPlan = inputCreatePaymentPlan.DeepClone();
            expectedCreatePaymentPlan.Response = randomPaymentPlanResponse;

            ExternalCreatePaymentPlanRequest mappedExternalCreatePaymentPlanRequest =
               randomExternalCreatePaymentPlanRequest;

            ExternalPaymentPlanResponse returnedExternalCreatePaymentPlanResponse =
                randomExternalPaymentPlanResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.PostCreatePaymentPlanAsync(It.Is(
                 SameExternalCreatePaymentPlanRequestAs(mappedExternalCreatePaymentPlanRequest))))
                .ReturnsAsync(returnedExternalCreatePaymentPlanResponse);

            // when
            CreatePaymentPlan actualCreatePaymentPlan =
                await this.paymentPlanService.PostCreatePaymentPlanAsync(inputCreatePaymentPlan);

            // then
            actualCreatePaymentPlan.Should().BeEquivalentTo(expectedCreatePaymentPlan);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.PostCreatePaymentPlanAsync(It.Is(
                   SameExternalCreatePaymentPlanRequestAs(mappedExternalCreatePaymentPlanRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}