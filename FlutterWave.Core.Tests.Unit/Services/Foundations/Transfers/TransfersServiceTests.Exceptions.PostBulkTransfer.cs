



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransfers;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBulkCreateTransfersIfUrlNotFoundAsync()
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransfersException =
                new InvalidConfigurationTransfersException(
                    httpResponseUrlNotFoundException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    invalidConfigurationTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBulkCreateTransfersIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();


            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBulkCreateTransfersIfNotFoundOccurredAsync()
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransfersException =
                new NotFoundTransfersException(
                    httpResponseNotFoundException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    notFoundTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBulkCreateTransfersIfBadRequestOccurredAsync()
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransfersException =
                new InvalidTransfersException(
                    httpResponseBadRequestException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    invalidTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBulkCreateTransfersIfTooManyRequestsOccurredAsync()
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransfersException =
                new ExcessiveCallTransfersException(
                    httpResponseTooManyRequestsException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    excessiveCallTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBulkCreateTransfersIfHttpResponseErrorOccurredAsync()
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();


            var httpResponseException =
                new HttpResponseException();

            var failedServerTransfersException =
                new FailedServerTransfersException(
                    httpResponseException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    failedServerTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBulkCreateTransfersIfServiceErrorOccurredAsync()
        {
            // given
            BulkCreateTransfers inputRandomBulkCreateTransfers = CreateRandomBulkCreateTransferRequest();

            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BulkCreateTransfers> retrieveTransfersTask =
               this.transfersService.PostCreateBulkTransferAsync(inputRandomBulkCreateTransfers);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBulkTransferAsync(It.IsAny<ExternalCreateBulkTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}