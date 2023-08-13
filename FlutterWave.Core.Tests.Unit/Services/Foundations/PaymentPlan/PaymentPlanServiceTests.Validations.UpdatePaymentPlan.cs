



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdatePaymentPlanIfUpdatePaymentPlanRequestIsNullAsync()
        {
            // given
            string inputPaymentPlanReference = GetRandomString();


            UpdatePaymentPlan? nullUpdatePaymentPlan = null;
            var nullUpdatePaymentPlanException = new NullPaymentPlanException();

            var exceptedPaymentPlanValidationException =
                new PaymentPlanValidationException(nullUpdatePaymentPlanException);

            // when
            ValueTask<UpdatePaymentPlan> PaymentPlanTask =
                this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanReference, nullUpdatePaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    PaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should()
                .BeEquivalentTo(exceptedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanReference,
                    It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdatePaymentPlanIfRequestIsNullAsync()
        {
            // given
            string inputPaymentPlanReference = GetRandomString();

            var invalidPaymentPlan = new UpdatePaymentPlan();
            invalidPaymentPlan.Request = null;

            var invalidPaymentPlanException =
                new InvalidPaymentPlanException();

            invalidPaymentPlanException.AddData(
                key: nameof(UpdatePaymentPlanRequest),
                values: "Value is required");


            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(
                    invalidPaymentPlanException);

            // when
            ValueTask<UpdatePaymentPlan> UpdatePaymentPlanTask =
                this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanReference, invalidPaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    UpdatePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should()
                .BeEquivalentTo(expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanReference,
                    It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData(" ", " ")]
        public async Task ShouldThrowValidationExceptionOnPostUpdatePaymentPlanIfUpdatePaymentPlanRequestIsInvalidAsync(
            string invalidName, string invalidStatus

            )
        {
            // given
            string inputPaymentPlanReference = GetRandomString();

            var validatePaymentPlan = new UpdatePaymentPlan
            {
                Request = new UpdatePaymentPlanRequest
                {

                    Name = invalidName,
                    Status = invalidStatus

                }
            };

            var invalidPaymentPlanException = new InvalidPaymentPlanException();

            invalidPaymentPlanException.AddData(
                   key: nameof(UpdatePaymentPlanRequest.Name),
                   values: "Value is required");

            invalidPaymentPlanException.AddData(
                   key: nameof(UpdatePaymentPlanRequest.Status),
                   values: "Value is required");

            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(invalidPaymentPlanException);

            // when
            ValueTask<UpdatePaymentPlan> UpdatePaymentPlanTask =
                this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanReference, validatePaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(UpdatePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUpdatePaymentPlanIfUpdatePaymentPlanRequestIsEmptyAsync()
        {
            // given
            string inputPaymentPlanReference = GetRandomString();

            var UpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = new UpdatePaymentPlanRequest
                {
                    Status = string.Empty,
                    Name = string.Empty


                }
            };

            var invalidPaymentPlanException = new InvalidPaymentPlanException();


            invalidPaymentPlanException.AddData(
                   key: nameof(UpdatePaymentPlanRequest.Status),
                   values: "Value is required");


            invalidPaymentPlanException.AddData(
               key: nameof(UpdatePaymentPlanRequest.Name),
               values: "Value is required");



            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(invalidPaymentPlanException);

            // when
            ValueTask<UpdatePaymentPlan> UpdatePaymentPlanTask =
                this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanReference, UpdatePaymentPlan);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    UpdatePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}