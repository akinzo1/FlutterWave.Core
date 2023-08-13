



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPaymentPlansRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPaymentPlanException =
                new InvalidConfigurationPaymentPlanException(
                    httpResponseUrlNotFoundException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(
                    invalidConfigurationPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPaymentPlansAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPaymentPlansRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedPaymentPlanException =
                new UnauthorizedPaymentPlanException(unauthorizedException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(unauthorizedPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetPaymentPlansAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentPlansRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPaymentPlanException =
                new NotFoundPaymentPlanException(
                    httpResponseNotFoundException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    notFoundPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPaymentPlansAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentPlansRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPaymentPlanException =
                new InvalidPaymentPlanException(
                    httpResponseBadRequestException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    invalidPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPaymentPlansAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPaymentPlansRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPaymentPlanException =
                new ExcessiveCallPaymentPlanException(
                    httpResponseTooManyRequestsException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    excessiveCallPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetPaymentPlansAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanDependencyValidationException actualPaymentPlanDependencyValidationException =
                await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPaymentPlansRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerPaymentPlanException =
                new FailedServerPaymentPlanException(
                    httpResponseException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(
                    failedServerPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetPaymentPlansAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanDependencyException actualPaymentPlanDependencyException =
                await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPaymentPlansRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedPaymentPlanServiceException =
                new FailedPaymentPlanServiceException(serviceException);

            var expectedPaymentPlanServiceException =
                new PaymentPlanServiceException(failedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPaymentPlansAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllPaymentPlans> retrievePaymentPlanTask =
               this.paymentPlanService.GetPaymentPlansAsync();

            PaymentPlanServiceException actualPaymentPlanServiceException =
                await Assert.ThrowsAsync<PaymentPlanServiceException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanServiceException.Should().BeEquivalentTo(
                expectedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPaymentPlansAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}