



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.PaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUpdatePaymentPlanIfUrlNotFoundAsync()
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPaymentPlanException =
                new InvalidConfigurationPaymentPlanException(
                    httpResponseUrlNotFoundException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(
                    invalidConfigurationPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostUpdatePaymentPlanIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            var unauthorizedPaymentPlanException =
                new UnauthorizedPaymentPlanException(unauthorizedException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(unauthorizedPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUpdatePaymentPlanIfNotFoundOccurredAsync()
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };
            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPaymentPlanException =
                new NotFoundPaymentPlanException(
                    httpResponseNotFoundException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    notFoundPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUpdatePaymentPlanIfBadRequestOccurredAsync()
        {
            //given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPaymentPlanException =
                new InvalidPaymentPlanException(
                    httpResponseBadRequestException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    invalidPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUpdatePaymentPlanIfTooManyRequestsOccurredAsync()
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPaymentPlanException =
                new ExcessiveCallPaymentPlanException(
                    httpResponseTooManyRequestsException);

            var expectedPaymentPlanDependencyValidationException =
                new PaymentPlanDependencyValidationException(
                    excessiveCallPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanDependencyValidationException actualPaymentPlanDependencyValidationException =
                await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUpdatePaymentPlanIfHttpResponseErrorOccurredAsync()
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerPaymentPlanException =
                new FailedServerPaymentPlanException(
                    httpResponseException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(
                    failedServerPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanDependencyException actualPaymentPlanDependencyException =
                await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostUpdatePaymentPlanIfServiceErrorOccurredAsync()
        {
            // given
            string inputName = GetRandomString();
            string inputStatus = GetRandomString();
            string inputPaymentPlanId = GetRandomString();



            var randomUpdatePaymentPlanRequest = new UpdatePaymentPlanRequest
            {
                Name = inputName,
                Status = inputStatus,
            };

            var randomUpdatePaymentPlan = new UpdatePaymentPlan
            {
                Request = randomUpdatePaymentPlanRequest,
            };

            var serviceException = new Exception();

            var failedPaymentPlanServiceException =
                new FailedPaymentPlanServiceException(serviceException);

            var expectedPaymentPlanServiceException =
                new PaymentPlanServiceException(failedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.UpdatePaymentPlanAsync(inputPaymentPlanId, randomUpdatePaymentPlan);

            PaymentPlanServiceException actualPaymentPlanServiceException =
                await Assert.ThrowsAsync<PaymentPlanServiceException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanServiceException.Should().BeEquivalentTo(
                expectedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.UpdatePaymentPlanAsync(inputPaymentPlanId, It.IsAny<ExternalUpdatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}