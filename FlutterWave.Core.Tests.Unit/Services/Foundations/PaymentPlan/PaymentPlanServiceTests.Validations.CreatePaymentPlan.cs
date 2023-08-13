



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreatePaymentPlanIfCreatePaymentPlanRequestIsNullAsync()
        {
            // given
            CreatePaymentPlan? nullCreatePaymentPlan = null;
            var nullCreatePaymentPlanException = new NullPaymentPlanException();

            var exceptedPaymentPlanValidationException =
                new PaymentPlanValidationException(nullCreatePaymentPlanException);

            // when
            ValueTask<CreatePaymentPlan> PaymentPlanTask =
                this.paymentPlanService.PostCreatePaymentPlanAsync(nullCreatePaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    PaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should()
                .BeEquivalentTo(exceptedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(
                    It.IsAny<ExternalCreatePaymentPlanRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreatePaymentPlanIfRequestIsNullAsync()
        {
            // given
            var invalidPaymentPlan = new CreatePaymentPlan();
            invalidPaymentPlan.Request = null;

            var invalidPaymentPlanException =
                new InvalidPaymentPlanException();

            invalidPaymentPlanException.AddData(
                key: nameof(CreatePaymentPlanRequest),
                values: "Value is required");


            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(
                    invalidPaymentPlanException);

            // when
            ValueTask<CreatePaymentPlan> CreatePaymentPlanTask =
                this.paymentPlanService.PostCreatePaymentPlanAsync(invalidPaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    CreatePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should()
                .BeEquivalentTo(expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(
                    It.IsAny<ExternalCreatePaymentPlanRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, 0, null, null)]
        [InlineData(0, 0, "", "")]
        [InlineData(0, 0, " ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostCreatePaymentPlanIfCreatePaymentPlanRequestIsInvalidAsync(
            int invalidAmount, int invalidDuration,
            string invalidName, string invalidInterval
            )
        {
            // given
            var CreatePaymentPlan = new CreatePaymentPlan
            {
                Request = new CreatePaymentPlanRequest
                {

                    Amount = invalidAmount,
                    Duration = invalidDuration,
                    Name = invalidName,
                    Interval = invalidInterval,


                }
            };

            var invalidPaymentPlanException = new InvalidPaymentPlanException();

            invalidPaymentPlanException.AddData(
                   key: nameof(CreatePaymentPlanRequest.Amount),
                   values: "Value is required");

            invalidPaymentPlanException.AddData(
               key: nameof(CreatePaymentPlanRequest.Duration),
               values: "Value is required");

            invalidPaymentPlanException.AddData(
               key: nameof(CreatePaymentPlanRequest.Name),
               values: "Value is required");

            invalidPaymentPlanException.AddData(
              key: nameof(CreatePaymentPlanRequest.Interval),
              values: "Value is required");

            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(invalidPaymentPlanException);

            // when
            ValueTask<CreatePaymentPlan> CreatePaymentPlanTask =
                this.paymentPlanService.PostCreatePaymentPlanAsync(CreatePaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(CreatePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreatePaymentPlanIfCreatePaymentPlanRequestIsEmptyAsync()
        {
            // given
            var CreatePaymentPlan = new CreatePaymentPlan
            {
                Request = new CreatePaymentPlanRequest
                {
                    Amount = 0,
                    Duration = 0,
                    Name = string.Empty,
                    Interval = string.Empty,


                }
            };

            var invalidPaymentPlanException = new InvalidPaymentPlanException();


            invalidPaymentPlanException.AddData(
                   key: nameof(CreatePaymentPlanRequest.Amount),
                   values: "Value is required");

            invalidPaymentPlanException.AddData(
               key: nameof(CreatePaymentPlanRequest.Duration),
               values: "Value is required");

            invalidPaymentPlanException.AddData(
               key: nameof(CreatePaymentPlanRequest.Name),
               values: "Value is required");

            invalidPaymentPlanException.AddData(
              key: nameof(CreatePaymentPlanRequest.Interval),
              values: "Value is required");

            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(invalidPaymentPlanException);

            // when
            ValueTask<CreatePaymentPlan> CreatePaymentPlanTask =
                this.paymentPlanService.PostCreatePaymentPlanAsync(CreatePaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    CreatePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}