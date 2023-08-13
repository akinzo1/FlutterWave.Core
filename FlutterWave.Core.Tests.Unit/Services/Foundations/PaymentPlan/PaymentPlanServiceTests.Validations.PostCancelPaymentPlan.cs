



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptionOnCancelPaymentPlanWithPaymentPlanIdDataIsInvalidAsync(
            string invalidPaymentPlanReference)
        {
            // given
            var invalidPaymentPlanException =
                new InvalidPaymentPlanException();

            invalidPaymentPlanException.AddData(
                key: nameof(PaymentPlan),
                values: "Value is required");

            var expectedPaymentPlanValidationException =
                new PaymentPlanValidationException(invalidPaymentPlanException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
                this.paymentPlanService.PostCancelPaymentPlanAsync(invalidPaymentPlanReference);

            PaymentPlanValidationException actualPaymentPlanValidationException =
                await Assert.ThrowsAsync<PaymentPlanValidationException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanValidationException.Should()
                .BeEquivalentTo(expectedPaymentPlanValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(
                    It.IsAny<string>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}