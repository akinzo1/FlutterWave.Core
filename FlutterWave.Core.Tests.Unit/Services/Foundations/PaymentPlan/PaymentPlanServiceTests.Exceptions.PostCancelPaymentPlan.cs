﻿



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCancelPaymentPlanRequestIfUrlNotFoundAsync()
        {
            // given
            string somePaymentPlanId = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPaymentPlanException =
                new InvalidConfigurationPaymentPlanException(
                    httpResponseUrlNotFoundException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(
                    invalidConfigurationPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCancelPaymentPlanRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string somePaymentPlanId = GetRandomString();

            var unauthorizedPaymentPlanException =
                new UnauthorizedPaymentPlanException(unauthorizedException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(unauthorizedPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCancelPaymentPlanRequestIfNotFoundOccurredAsync()
        {
            // given
            string somePaymentPlanId = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPaymentPlanException =
                new NotFoundPaymentPlanException(
                    httpResponseNotFoundException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    notFoundPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCancelPaymentPlanRequestIfBadRequestOccurredAsync()
        {
            // given
            string somePaymentPlanId = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPaymentPlanException =
                new InvalidPaymentPlanException(
                    httpResponseBadRequestException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    invalidPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCancelPaymentPlanRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string somePaymentPlanId = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPaymentPlanException =
                new ExcessiveCallPaymentPlanException(
                    httpResponseTooManyRequestsException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    excessiveCallPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanDependencyValidationException actualPaymentPlanDependencyValidationException =
                await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCancelPaymentPlanRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string somePaymentPlanId = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerPaymentPlanException =
                new FailedServerPaymentPlanException(
                    httpResponseException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(
                    failedServerPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanDependencyException actualPaymentPlanDependencyException =
                await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCancelPaymentPlanRequestIfServiceErrorOccurredAsync()
        {
            // given
            string somePaymentPlanId = GetRandomString();
            var serviceException = new Exception();

            var failedPaymentPlanServiceException =
                new FailedPaymentPlanServiceException(serviceException);

            var expectedPaymentPlanServiceException =
                new PaymentPlanServiceException(failedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<PaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCancelPaymentPlanAsync(somePaymentPlanId);

            PaymentPlanServiceException actualPaymentPlanServiceException =
                await Assert.ThrowsAsync<PaymentPlanServiceException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanServiceException.Should().BeEquivalentTo(
                expectedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCancelPaymentPlanAsync(somePaymentPlanId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}