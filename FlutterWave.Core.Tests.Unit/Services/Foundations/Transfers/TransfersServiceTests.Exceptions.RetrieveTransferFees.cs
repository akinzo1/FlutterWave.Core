



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransferFeesIfUrlNotFoundAsync()
        {
            // given

            int inputAmount = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransfersException =
                new InvalidConfigurationTransfersException(
                    httpResponseUrlNotFoundException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    invalidConfigurationTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllTransferFeesAsync(inputAmount))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransferFeesIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            int inputAmount = GetRandomNumber();

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllTransferFeesAsync(inputAmount))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransferFeesIfNotFoundOccurredAsync()
        {
            // given

            int inputAmount = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransfersException =
                new NotFoundTransfersException(
                    httpResponseNotFoundException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    notFoundTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllTransferFeesAsync(inputAmount))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransferFeesIfBadRequestOccurredAsync()
        {
            // given

            int inputAmount = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransfersException =
                new InvalidTransfersException(
                    httpResponseBadRequestException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    invalidTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllTransferFeesAsync(inputAmount))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransferFeesIfTooManyRequestsOccurredAsync()
        {
            // given

            int inputAmount = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransfersException =
                new ExcessiveCallTransfersException(
                    httpResponseTooManyRequestsException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    excessiveCallTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllTransferFeesAsync(inputAmount))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransferFeesIfHttpResponseErrorOccurredAsync()
        {
            // given

            int inputAmount = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransfersException =
                new FailedServerTransfersException(
                    httpResponseException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    failedServerTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllTransferFeesAsync(inputAmount))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveTransferFeesIfServiceErrorOccurredAsync()
        {
            // given

            int inputAmount = GetRandomNumber();
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllTransferFeesAsync(inputAmount))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TransferFees> retrieveTransfersTask =
               this.transfersService.GetAllTransferFeesAsync(inputAmount);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllTransferFeesAsync(inputAmount),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}