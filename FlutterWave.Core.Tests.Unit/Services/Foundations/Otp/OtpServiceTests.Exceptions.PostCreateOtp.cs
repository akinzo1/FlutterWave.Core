



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
        public async Task ShouldThrowDependencyExceptionOnPostCreateOtpIfUrlNotFoundAsync()
        {
            // given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
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
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpDependencyException
                actualOtpDependencyException =
                    await Assert.ThrowsAsync<OtpDependencyException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyException.Should().BeEquivalentTo(
                expectedOtpDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostCreateOtpIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
            };

            var unauthorizedOtpException =
                new UnauthorizedOtpException(unauthorizedException);

            var expectedOtpDependencyException =
                new OtpDependencyException(unauthorizedOtpException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpDependencyException
                actualOtpDependencyException =
                    await Assert.ThrowsAsync<OtpDependencyException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyException.Should().BeEquivalentTo(
                expectedOtpDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateOtpIfNotFoundOccurredAsync()
        {
            // given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
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
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpDependencyValidationException
                actualOtpDependencyValidationException =
                    await Assert.ThrowsAsync<OtpDependencyValidationException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyValidationException.Should().BeEquivalentTo(
                expectedOtpDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateOtpIfBadRequestOccurredAsync()
        {
            //given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
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
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpDependencyValidationException
                actualOtpDependencyValidationException =
                    await Assert.ThrowsAsync<OtpDependencyValidationException>(
                        retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyValidationException.Should().BeEquivalentTo(
                expectedOtpDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostCreateOtpIfTooManyRequestsOccurredAsync()
        {
            // given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
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
                 broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpDependencyValidationException actualOtpDependencyValidationException =
                await Assert.ThrowsAsync<OtpDependencyValidationException>(
                    retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyValidationException.Should().BeEquivalentTo(
                expectedOtpDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateOtpIfHttpResponseErrorOccurredAsync()
        {
            // given

            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
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
                 broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpDependencyException actualOtpDependencyException =
                await Assert.ThrowsAsync<OtpDependencyException>(
                    retrieveOtpTask.AsTask);

            // then
            actualOtpDependencyException.Should().BeEquivalentTo(
                expectedOtpDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostCreateOtpIfServiceErrorOccurredAsync()
        {
            // given
            string inputEmail = GetRandomString();
            string inputName = GetRandomString();
            string inputPhone = GetRandomString();
            int inputExpiry = GetRandomNumber();
            int inputLength = GetRandomNumber();
            List<string> inputMedium = CreateRandomStringList();
            bool inputSend = GetRandomBoolean();
            string inputSender = GetRandomString();


            var randomCreateOtpRequest = new CreateOtpRequest
            {
                Customer = new CreateOtpRequest.CustomerModel
                {
                    Email = inputEmail,
                    Name = inputName,
                    Phone = inputPhone,
                },
                Expiry = inputExpiry,
                Length = inputLength,
                Medium = inputMedium,
                Send = inputSend,
                Sender = inputSender


            };

            var randomCreateOtp = new CreateOtp
            {
                Request = randomCreateOtpRequest,
            };

            var serviceException = new Exception();

            var failedOtpServiceException =
                new FailedOtpServiceException(serviceException);

            var expectedOtpServiceException =
                new OtpServiceException(failedOtpServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateOtp> retrieveOtpTask =
               this.otpService.PostCreateOtpAsync(randomCreateOtp);

            OtpServiceException actualOtpServiceException =
                await Assert.ThrowsAsync<OtpServiceException>(
                    retrieveOtpTask.AsTask);

            // then
            actualOtpServiceException.Should().BeEquivalentTo(
                expectedOtpServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateOtpAsync(It.IsAny<ExternalCreateOtpRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}