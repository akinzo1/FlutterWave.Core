



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBalanceByCurrenciesRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMiscException =
                new InvalidConfigurationMiscException(
                    httpResponseUrlNotFoundException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    invalidConfigurationMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceCurrenciesAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBalanceByCurrenciesRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedMiscException =
                new UnauthorizedMiscException(unauthorizedException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(unauthorizedMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBalanceCurrenciesAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceByCurrenciesRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMiscException =
                new NotFoundMiscException(
                    httpResponseNotFoundException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    notFoundMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceCurrenciesAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceByCurrenciesRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMiscException =
                new InvalidMiscellaneousException(
                    httpResponseBadRequestException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    invalidMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceCurrenciesAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBalanceByCurrenciesRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMiscException =
                new ExcessiveCallMiscException(
                    httpResponseTooManyRequestsException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    excessiveCallMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBalanceCurrenciesAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousDependencyValidationException actualMiscellaneousDependencyValidationException =
                await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBalanceByCurrenciesRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerMiscException =
                new FailedServerMiscException(
                    httpResponseException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    failedServerMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBalanceCurrenciesAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousDependencyException actualMiscellaneousDependencyException =
                await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBalanceByCurrenciesRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedMiscServiceException =
                new FailedMiscServiceException(serviceException);

            var expectedMiscServiceException =
                new MiscellaneousServiceException(failedMiscServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBalanceCurrenciesAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BalanceByCurrencies> retrieveMiscTask =
               this.miscellaneousService.GetBalanceCurrenciesAsync();

            MiscellaneousServiceException actualMiscServiceException =
                await Assert.ThrowsAsync<MiscellaneousServiceException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscServiceException.Should().BeEquivalentTo(
                expectedMiscServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBalanceCurrenciesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}