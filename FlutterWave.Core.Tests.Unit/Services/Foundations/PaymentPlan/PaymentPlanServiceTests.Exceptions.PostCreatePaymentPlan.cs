



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPaymentPlan;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PaymentPlans
{
    public partial class PaymentPlanServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreatePaymentPlanIfUrlNotFoundAsync()
        {
            // given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName



            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
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
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreatePaymentPlanIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
            };

            var unauthorizedPaymentPlanException =
                new UnauthorizedPaymentPlanException(unauthorizedException);

            var expectedPaymentPlanDependencyException =
                new PaymentPlanDependencyException(unauthorizedPaymentPlanException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanDependencyException
                actualPaymentPlanDependencyException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreatePaymentPlanIfNotFoundOccurredAsync()
        {
            // given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
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
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreatePaymentPlanIfBadRequestOccurredAsync()
        {
            //given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
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
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanDependencyValidationException
                actualPaymentPlanDependencyValidationException =
                    await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                        retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreatePaymentPlanIfTooManyRequestsOccurredAsync()
        {
            // given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
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
                 broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanDependencyValidationException actualPaymentPlanDependencyValidationException =
                await Assert.ThrowsAsync<PaymentPlanDependencyValidationException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyValidationException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreatePaymentPlanIfHttpResponseErrorOccurredAsync()
        {
            // given

            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
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
                 broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanDependencyException actualPaymentPlanDependencyException =
                await Assert.ThrowsAsync<PaymentPlanDependencyException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanDependencyException.Should().BeEquivalentTo(
                expectedPaymentPlanDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreatePaymentPlanIfServiceErrorOccurredAsync()
        {
            // given
            int inputAmount = GetRandomNumber();
            string inputName = GetRandomString();
            string inputInterval = GetRandomString();
            int inputDuration = GetRandomNumber();


            var randomCreatePaymentPlanRequest = new CreatePaymentPlanRequest
            {
                Amount = inputAmount,
                Duration = inputDuration,
                Interval = inputInterval,
                Name = inputName


            };

            var randomCreatePaymentPlan = new CreatePaymentPlan
            {
                Request = randomCreatePaymentPlanRequest,
            };

            var serviceException = new Exception();

            var failedPaymentPlanServiceException =
                new FailedPaymentPlanServiceException(serviceException);

            var expectedPaymentPlanServiceException =
                new PaymentPlanServiceException(failedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreatePaymentPlan> retrievePaymentPlanTask =
               this.paymentPlanService.PostCreatePaymentPlanAsync(randomCreatePaymentPlan);

            PaymentPlanServiceException actualPaymentPlanServiceException =
                await Assert.ThrowsAsync<PaymentPlanServiceException>(
                    retrievePaymentPlanTask.AsTask);

            // then
            actualPaymentPlanServiceException.Should().BeEquivalentTo(
                expectedPaymentPlanServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePaymentPlanAsync(It.IsAny<ExternalCreatePaymentPlanRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}