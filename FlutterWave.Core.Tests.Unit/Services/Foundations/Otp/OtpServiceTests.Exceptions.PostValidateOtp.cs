



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalOtp;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Otp
{
    public partial class OtpServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostValidateOtpIfUrlNotFoundAsync()
        {
            // given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();



            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {

                Otp = inputOtpReference

            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationOtpException =
                new InvalidConfigurationOtpException(
                    httpResponseUrlNotFoundException);

            var expectedOtpDependencyException =
                new OtpDependencyException(
                    invalidConfigurationOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpDependencyException
                actualOtpDependencyException =
                    await Assert.ThrowsAsync<OtpDependencyException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyException.Should().BeEquivalentTo(
                expectedOtpDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostValidateOtpIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp


            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            var unauthorizedOtpException =
                new UnauthorizedOtpException(unauthorizedException);

            var expectedOtpDependencyException =
                new OtpDependencyException(unauthorizedOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpDependencyException
                actualOtpDependencyException =
                    await Assert.ThrowsAsync<OtpDependencyException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyException.Should().BeEquivalentTo(
                expectedOtpDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostValidateOtpIfNotFoundOccurredAsync()
        {
            // given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp


            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };
            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundOtpException =
                new NotFoundOtpException(
                    httpResponseNotFoundException);

            var expectedOtpDependencyValidationException =
                new OtpDependencyValidationException(
                    notFoundOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpDependencyValidationException
                actualOtpDependencyValidationException =
                    await Assert.ThrowsAsync<OtpDependencyValidationException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyValidationException.Should().BeEquivalentTo(
                expectedOtpDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostValidateOtpIfBadRequestOccurredAsync()
        {
            //given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp


            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidOtpException =
                new InvalidOtpException(
                    httpResponseBadRequestException);

            var expectedOtpDependencyValidationException =
                new OtpDependencyValidationException(
                    invalidOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpDependencyValidationException
                actualOtpDependencyValidationException =
                    await Assert.ThrowsAsync<OtpDependencyValidationException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyValidationException.Should().BeEquivalentTo(
                expectedOtpDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostValidateOtpIfTooManyRequestsOccurredAsync()
        {
            // given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp


            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallOtpException =
                new ExcessiveCallOtpException(
                    httpResponseTooManyRequestsException);

            var expectedOtpDependencyValidationException =
                new OtpDependencyValidationException(
                    excessiveCallOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpDependencyValidationException actualOtpDependencyValidationException =
                await Assert.ThrowsAsync<OtpDependencyValidationException>(
                    retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyValidationException.Should().BeEquivalentTo(
                expectedOtpDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostValidateOtpIfHttpResponseErrorOccurredAsync()
        {
            // given

            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp


            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerOtpException =
                new FailedServerOtpException(
                    httpResponseException);

            var expectedOtpDependencyException =
                new OtpDependencyException(
                    failedServerOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpDependencyException actualOtpDependencyException =
                await Assert.ThrowsAsync<OtpDependencyException>(
                    retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyException.Should().BeEquivalentTo(
                expectedOtpDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostValidateOtpIfServiceErrorOccurredAsync()
        {
            // given
            string inputOtpReference = GetRandomString();
            string inputOtp = GetRandomString();


            dynamic createRandomOtpProperties =
                   CreateRandomValidateOtpProperties();


            var randomValidateOtpRequest = new ValidateOtpRequest
            {
                Otp = inputOtp


            };

            var randomValidateOtp = new ValidateOtp
            {
                Request = randomValidateOtpRequest,
            };

            var serviceException = new Exception();

            var failedOtpServiceException =
                new FailedOtpServiceException(serviceException);

            var expectedOtpServiceException =
                new OtpServiceException(failedOtpServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ValidateOtp> retrieveOtpTask =
               this.otpService.PostValidateOtpAsync(inputOtpReference, randomValidateOtp);

            OtpServiceException actualOtpServiceException =
                await Assert.ThrowsAsync<OtpServiceException>(
                    retrieveOtpTask.AsTask);

            // then
            actualOtpServiceException.Should().BeEquivalentTo(
                expectedOtpServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateOtpAsync(inputOtpReference, It.IsAny<ExternalValidateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}