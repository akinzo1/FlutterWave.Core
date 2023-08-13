



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Force.DeepCloner;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldPostUpdatePaymentPlanWithUpdatePaymentPlanRequestAsync()
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();


            dynamic createRandomPaymentPlanProperties =
                   CreateRandomPaymentPlanProperties();


            var randomExternalUpdatePaymentPlanRequest = new ExternalUpdatePaymentPlanRequest
            {

                Name = inputName,
                Status = inputStatus,

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



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,

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

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            UpdatePaymentPlan inputUpdatePaymentPlan = randomUpdatePaymentPlan;
            UpdatePaymentPlan expectedUpdatePaymentPlan = inputUpdatePaymentPlan.DeepClone();
            expectedUpdatePaymentPlan.Response = randomPaymentPlanResponse;

            ExternalUpdatePaymentPlanRequest mappedExternalUpdatePaymentPlanRequest =
               randomExternalUpdatePaymentPlanRequest;

            ExternalPaymentPlanResponse returnedExternalUpdatePaymentPlanResponse =
                randomExternalPaymentPlanResponse;

            this.flutterWaveBrokerMock.Setup(broker =>
             broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.Is(
                 SameExternalUpdatePaymentPlanRequestAs(mappedExternalUpdatePaymentPlanRequest))))
                .ReturnsAsync(returnedExternalUpdatePaymentPlanResponse);

            // when
            UpdatePaymentPlan actualUpdatePaymentPlan =
                await this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, inputUpdatePaymentPlan);

            // then
            actualUpdatePaymentPlan.Should().BeEquivalentTo(expectedUpdatePaymentPlan);

            this.flutterWaveBrokerMock.Verify(broker =>
               broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.Is(
                   SameExternalUpdatePaymentPlanRequestAs(mappedExternalUpdatePaymentPlanRequest))),
                   Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}