



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCardBinVerificationRequestIfUrlNotFoundAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMiscException =
                new InvalidConfigurationMiscException(
                    httpResponseUrlNotFoundException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    invalidConfigurationMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCardBinVerificationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someTransactionReference = GetRandomString();

            var unauthorizedMiscException =
                new UnauthorizedMiscException(unauthorizedException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(unauthorizedMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetCardBinVerificationAsync(someTransactionReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCardBinVerificationRequestIfNotFoundOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMiscException =
                new NotFoundMiscException(
                    httpResponseNotFoundException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    notFoundMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCardBinVerificationRequestIfBadRequestOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMiscException =
                new InvalidMiscellaneousException(
                    httpResponseBadRequestException);

            var expectedMiscllaneousependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    invalidMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscllaneousependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCardBinVerificationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMiscException =
                new ExcessiveCallMiscException(
                    httpResponseTooManyRequestsException);

            var expectedMiscllaneousependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    excessiveCallMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetCardBinVerificationAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousDependencyValidationException actualMiscllaneousependencyValidationException =
                await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscllaneousependencyValidationException.Should().BeEquivalentTo(
                expectedMiscllaneousependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCardBinVerificationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerMiscException =
                new FailedServerMiscException(
                    httpResponseException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    failedServerMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetCardBinVerificationAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousDependencyException actualMiscellaneousDependencyException =
                await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCardBinVerificationRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();
            var serviceException = new Exception();

            var failedMiscServiceException =
                new FailedMiscServiceException(serviceException);

            var expectedMiscServiceException =
                new MiscellaneousServiceException(failedMiscServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BinVerification> retrieveMiscTask =
               this.miscellaneousService.GetCardBinVerificationAsync(someTransactionReference);

            MiscellaneousServiceException actualMiscServiceException =
                await Assert.ThrowsAsync<MiscellaneousServiceException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscServiceException.Should().BeEquivalentTo(
                expectedMiscServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetCardBinVerificationAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}