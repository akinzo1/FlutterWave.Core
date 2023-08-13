



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMiscRequestIfUrlNotFoundAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMiscException =
                new InvalidConfigurationMiscException(
                    httpResponseUrlNotFoundException);

            var expectedMiscDependencyException =
                new MiscellaneousDependencyException(
                    invalidConfigurationMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousDependencyException
                actualMiscDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscDependencyException.Should().BeEquivalentTo(
                expectedMiscDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMiscRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someTransactionReference = GetRandomString();

            var unauthorizedMiscException =
                new UnauthorizedMiscException(unauthorizedException);

            var expectedMiscDependencyException =
                new MiscellaneousDependencyException(unauthorizedMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBalanceByCurrencyAsync(someTransactionReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousDependencyException
                actualMiscDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscDependencyException.Should().BeEquivalentTo(
                expectedMiscDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMiscRequestIfNotFoundOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMiscException =
                new NotFoundMiscException(
                    httpResponseNotFoundException);

            var expectedMiscDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    notFoundMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousDependencyValidationException
                actualMiscDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMiscRequestIfBadRequestOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMiscException =
                new InvalidMiscellaneousException(
                    httpResponseBadRequestException);

            var expectedMiscDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    invalidMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousDependencyValidationException
                actualMiscDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMiscRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMiscException =
                new ExcessiveCallMiscException(
                    httpResponseTooManyRequestsException);

            var expectedMiscDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    excessiveCallMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBalanceByCurrencyAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousDependencyValidationException actualMiscDependencyValidationException =
                await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMiscRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerMiscException =
                new FailedServerMiscException(
                    httpResponseException);

            var expectedMiscDependencyException =
                new MiscellaneousDependencyException(
                    failedServerMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBalanceByCurrencyAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousDependencyException actualMiscDependencyException =
                await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscDependencyException.Should().BeEquivalentTo(
                expectedMiscDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMiscRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();
            var serviceException = new Exception();

            var failedMiscServiceException =
                new FailedMiscServiceException(serviceException);

            var expectedMiscServiceException =
                new MiscellaneousServiceException(failedMiscServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BalanceByCurrency> retrieveMiscTask =
               this.miscellaneousService.GetBalanceByCurrencyAsync(someTransactionReference);

            MiscellaneousServiceException actualMiscServiceException =
                await Assert.ThrowsAsync<MiscellaneousServiceException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscServiceException.Should().BeEquivalentTo(
                expectedMiscServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceByCurrencyAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}