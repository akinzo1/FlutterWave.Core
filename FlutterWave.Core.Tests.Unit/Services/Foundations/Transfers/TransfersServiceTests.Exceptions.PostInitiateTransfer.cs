



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
        public async Task ShouldThrowDependencyExceptionOnInitiateTransfersIfUrlNotFoundAsync()
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransfersException =
                new InvalidConfigurationTransfersException(
                    httpResponseUrlNotFoundException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    invalidConfigurationTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnInitiateTransfersIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();


            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnInitiateTransfersIfNotFoundOccurredAsync()
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransfersException =
                new NotFoundTransfersException(
                    httpResponseNotFoundException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    notFoundTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnInitiateTransfersIfBadRequestOccurredAsync()
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransfersException =
                new InvalidTransfersException(
                    httpResponseBadRequestException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    invalidTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnInitiateTransfersIfTooManyRequestsOccurredAsync()
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransfersException =
                new ExcessiveCallTransfersException(
                    httpResponseTooManyRequestsException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    excessiveCallTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnInitiateTransfersIfHttpResponseErrorOccurredAsync()
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();


            var httpResponseException =
                new HttpResponseException();

            var failedServerTransfersException =
                new FailedServerTransfersException(
                    httpResponseException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    failedServerTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnInitiateTransfersIfServiceErrorOccurredAsync()
        {
            // given
            InitiateTransfers inputRandomInitiateTransfers = CreateRandomInitiateTransferRequest();

            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<InitiateTransfers> retrieveTransfersTask =
               this.transfersService.PostInitiateTransferAsync(inputRandomInitiateTransfers);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostInitiateTransferAsync(It.IsAny<ExternalInitiateTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}