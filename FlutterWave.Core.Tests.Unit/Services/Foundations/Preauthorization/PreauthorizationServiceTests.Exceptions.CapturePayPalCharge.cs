



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
        public async Task ShouldThrowDependencyExceptionOnPostCapturePayPalChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
              CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCapturePayPalChargeException =
                new InvalidConfigurationPreauthorizationException(
                    httpResponseUrlNotFoundException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    invalidConfigurationCapturePayPalChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(randomCapturePayPalCharge);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCapturePayPalChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
            CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var someRandomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };

            var unauthorizedCapturePayPalChargeException =
                new UnauthorizedPreauthorizationException(unauthorizedException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(unauthorizedCapturePayPalChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(someRandomCapturePayPalCharge);

            PreauthorizationDependencyException
                actualPreauthorizationDependencyException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                        retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCapturePayPalChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
            CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCapturePayPalChargeException =
                new NotFoundPreauthorizationException(
                    httpResponseNotFoundException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    notFoundCapturePayPalChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(randomCapturePayPalCharge);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCapturePayPalChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
            CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCapturePayPalChargeException =
                new InvalidPreauthorizationException(
                    httpResponseBadRequestException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    invalidCapturePayPalChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(randomCapturePayPalCharge);

            PreauthorizationDependencyValidationException
                actualPreauthorizationDependencyValidationException =
                    await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                        retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCapturePayPalChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
            CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCapturePayPalChargeException =
                new ExcessiveCallPreauthorizationException(
                    httpResponseTooManyRequestsException);

            var expectedPreauthorizationDependencyValidationException =
                new PreauthorizationDependencyValidationException(
                    excessiveCallCapturePayPalChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(randomCapturePayPalCharge);

            PreauthorizationDependencyValidationException actualPreauthorizationDependencyValidationException =
                await Assert.ThrowsAsync<PreauthorizationDependencyValidationException>(
                    retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyValidationException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCapturePayPalChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
            CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCapturePayPalChargeException =
                new FailedServerPreauthorizationException(
                    httpResponseException);

            var expectedPreauthorizationDependencyException =
                new PreauthorizationDependencyException(
                    failedServerCapturePayPalChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(randomCapturePayPalCharge);

            PreauthorizationDependencyException actualPreauthorizationDependencyException =
                await Assert.ThrowsAsync<PreauthorizationDependencyException>(
                    retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualPreauthorizationDependencyException.Should().BeEquivalentTo(
                expectedPreauthorizationDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCapturePayPalChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCapturePayPalChargeRequestProperties =
           CreateRandomCapturePayPalChargeRequestProperties();


            var randomCapturePayPalChargeRequest = new CapturePayPalChargeRequest
            {
                FlwRef = createRandomCapturePayPalChargeRequestProperties.FlwRef,

            };

            var randomCapturePayPalCharge = new CapturePayPalCharge
            {
                Request = randomCapturePayPalChargeRequest
            };
            var serviceException = new Exception();

            var failedCapturePayPalChargeServiceException =
                new FailedPreauthorizationServiceException(serviceException);

            var expectedCapturePayPalChargeServiceException =
                new PreauthorizationServiceException(failedCapturePayPalChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CapturePayPalCharge> retrieveCapturePayPalChargeTask =
               this.preauthorizationService.PostCapturePayPalChargeRequestAsync(randomCapturePayPalCharge);

            PreauthorizationServiceException actualCapturePayPalChargeServiceException =
                await Assert.ThrowsAsync<PreauthorizationServiceException>(
                    retrieveCapturePayPalChargeTask.AsTask);

            // then
            actualCapturePayPalChargeServiceException.Should().BeEquivalentTo(
                expectedCapturePayPalChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCapturePayPalChargeAsync(It.IsAny<ExternalCapturePayPalChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}