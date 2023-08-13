



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transfers;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransferRatesIfUrlNotFoundAsync()
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
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
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransferRatesIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
            int inputAmount = GetRandomNumber();



            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransferRatesIfNotFoundOccurredAsync()
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
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
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransferRatesIfBadRequestOccurredAsync()
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
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
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransferRatesIfTooManyRequestsOccurredAsync()
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
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
                 broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransferRatesIfHttpResponseErrorOccurredAsync()
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
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
                 broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveTransferRatesIfServiceErrorOccurredAsync()
        {
            // given
            string inputDestinationCurrency = GetRandomString();
            string inputSourceCurrency = GetRandomString();
            int inputAmount = GetRandomNumber();


            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TransferRates> retrieveTransfersTask =
               this.transfersService.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveTransfersTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransferRatesAsync(inputDestinationCurrency, inputAmount, inputSourceCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}