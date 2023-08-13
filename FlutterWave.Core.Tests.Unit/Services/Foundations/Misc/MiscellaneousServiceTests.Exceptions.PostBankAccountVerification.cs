



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostBankAccountVerificationIfUrlNotFoundAsync()
        {
            // given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMiscException =
                new InvalidConfigurationMiscException(
                    httpResponseUrlNotFoundException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    invalidConfigurationMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostBankAccountVerificationIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };

            var unauthorizedMiscException =
                new UnauthorizedMiscException(unauthorizedException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(unauthorizedMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBankAccountVerificationIfNotFoundOccurredAsync()
        {
            // given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMiscException =
                new NotFoundMiscException(
                    httpResponseNotFoundException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    notFoundMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBankAccountVerificationIfBadRequestOccurredAsync()
        {
            //given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMiscException =
                new InvalidMiscellaneousException(
                    httpResponseBadRequestException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    invalidMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBankAccountVerificationIfTooManyRequestsOccurredAsync()
        {
            // given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMiscException =
                new ExcessiveCallMiscException(
                    httpResponseTooManyRequestsException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    excessiveCallMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousDependencyValidationException actualMiscellaneousDependencyValidationException =
                await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostBankAccountVerificationIfHttpResponseErrorOccurredAsync()
        {
            // given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerMiscException =
                new FailedServerMiscException(
                    httpResponseException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    failedServerMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousDependencyException actualMiscellaneousDependencyException =
                await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostBankAccountVerificationIfServiceErrorOccurredAsync()
        {
            // given
            string randomAccountNumber = GetRandomString();
            string randomAccountBank = GetRandomString();
            string inputAccountNumber = randomAccountNumber;
            string inputAccountBank = randomAccountBank;

            var someRandomBankAccountVerificationRequest = new BankAccountVerificationRequest
            {
                AccountBank = inputAccountBank,
                AccountNumber = inputAccountNumber,

            };

            var someRandomInput = new BankAccountVerification
            {
                Request = someRandomBankAccountVerificationRequest
            };
            var serviceException = new Exception();

            var failedMiscellaneousServiceException =
                new FailedMiscServiceException(serviceException);

            var expectedMiscellaneousServiceException =
                new MiscellaneousServiceException(failedMiscellaneousServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BankAccountVerification> retrieveMiscTask =
               this.miscellaneousService.PostBankAccountVerificationAsync(someRandomInput);

            MiscellaneousServiceException actualMiscellaneousServiceException =
                await Assert.ThrowsAsync<MiscellaneousServiceException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousServiceException.Should().BeEquivalentTo(
                expectedMiscellaneousServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBankAccountVerificationAsync(It.IsAny<ExternalBankAccountVerificationRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}