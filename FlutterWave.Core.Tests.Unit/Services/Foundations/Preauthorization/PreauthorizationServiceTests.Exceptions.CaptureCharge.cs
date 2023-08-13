



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Preauthorization
{
    public partial class PreauthorizationServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCaptureChargeRequestIfUrlNotFoundAsync()
        {
            // given
            var randomFlwRef = GetRandomString();

            dynamic createRandomCaptureChargeRequestProperties =
           CreateRandomCaptureChargeRequestProperties();


            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPreauthorizationException =
                new InvalidConfigurationPreauthorizationException(
                    httpResponseUrlNotFoundException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    invalidConfigurationPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCaptureChargeAvailableBalanceRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomFlwRef = GetRandomString();

            dynamic createRandomCaptureChargeRequestProperties =
           CreateRandomCaptureChargeRequestProperties();




            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };

            var unauthorizedPreauthorizationException =
                new UnauthorizedPreauthorizationException(unauthorizedException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(unauthorizedPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCaptureChargeAvailableBalanceRequestIfNotFoundOccurredAsync()
        {
            // given
            var randomFlwRef = GetRandomString();
            dynamic createRandomCaptureChargeRequestProperties =
                 CreateRandomCaptureChargeRequestProperties();


            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPreauthorizationException =
                new NotFoundPreauthorizationException(
                    httpResponseNotFoundException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    notFoundPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCaptureChargeAvailableBalanceRequestIfBadRequestOccurredAsync()
        {
            // given
            var randomFlwRef = GetRandomString();
            dynamic createRandomCaptureChargeRequestProperties =
                CreateRandomCaptureChargeRequestProperties();


            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPreauthorizationException =
                new InvalidPreauthorizationException(
                    httpResponseBadRequestException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    invalidPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCaptureChargeAvailableBalanceRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var randomFlwRef = GetRandomString();

            dynamic createRandomCaptureChargeRequestProperties =
               CreateRandomCaptureChargeRequestProperties();


            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPreauthorizationException =
                new ExcessiveCallPreauthorizationException(
                    httpResponseTooManyRequestsException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    excessiveCallPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationDependencyValidationException actualPreauthorizationDependencyValidationException =
                await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCaptureChargeAvailableBalanceRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var randomFlwRef = GetRandomString();
            dynamic createRandomCaptureChargeRequestProperties =
                CreateRandomCaptureChargeRequestProperties();


            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerPreauthorizationException =
                new FailedServerPreauthorizationException(
                    httpResponseException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    failedServerPreauthorizationException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationDependencyException actualPreauthorizationDependencyException =
                await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCaptureChargeAvailableBalanceRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomFlwRef = GetRandomString();
            dynamic createRandomCaptureChargeRequestProperties =
                    CreateRandomCaptureChargeRequestProperties();


            var randomCaptureCharge = new CaptureCharge
            {
                Request = new CaptureChargeRequest
                {
                    Amount = createRandomCaptureChargeRequestProperties.Amount
                }

            };
            var serviceException = new Exception();

            var failedPreauthorizationServiceException =
                new FailedPreauthorizationServiceException(serviceException);

            var expectedPreauthorizationServiceException =
                new PreauthorizationServiceException(failedPreauthorizationServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CaptureCharge> retrievePreauthorizationTask =
               this.preauthorizationService.PostCaptureChargeRequestAsync(randomFlwRef, randomCaptureCharge);

            PreauthorizationServiceException actualPreauthorizationServiceException =
                await Assert.ThrowsAsync<PreauthorizationServiceException>(
                    retrievePreauthorizationTask.AsTask);

            // then
            actualPreauthorizationServiceException.Should().BeEquivalentTo(
                expectedPreauthorizationServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCaptureChargeAsync(randomFlwRef, It.IsAny<ExternalCaptureChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}