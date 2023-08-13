



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveRetryTransfersIfUrlNotFoundAsync()
        {
            // given

            int inputTransactionId = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransfersException =
                new InvalidConfigurationTransfersException(
                    httpResponseUrlNotFoundException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    invalidConfigurationTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveRetryTransfersIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            int inputTransactionId = GetRandomNumber();

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetRetryTransfersAsync(inputTransactionId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveRetryTransfersIfNotFoundOccurredAsync()
        {
            // given

            int inputTransactionId = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransfersException =
                new NotFoundTransfersException(
                    httpResponseNotFoundException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    notFoundTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveRetryTransfersIfBadRequestOccurredAsync()
        {
            // given

            int inputTransactionId = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransfersException =
                new InvalidTransfersException(
                    httpResponseBadRequestException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    invalidTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveRetryTransfersIfTooManyRequestsOccurredAsync()
        {
            // given

            int inputTransactionId = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransfersException =
                new ExcessiveCallTransfersException(
                    httpResponseTooManyRequestsException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    excessiveCallTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetRetryTransfersAsync(inputTransactionId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveRetryTransfersIfHttpResponseErrorOccurredAsync()
        {
            // given

            int inputTransactionId = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransfersException =
                new FailedServerTransfersException(
                    httpResponseException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    failedServerTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetRetryTransfersAsync(inputTransactionId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveRetryTransfersIfServiceErrorOccurredAsync()
        {
            // given

            int inputTransactionId = GetRandomNumber();
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<RetryTransfers> retrieveTransfersTask =
               this.transfersService.GetRetryTransfersAsync(inputTransactionId);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRetryTransfersAsync(inputTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}