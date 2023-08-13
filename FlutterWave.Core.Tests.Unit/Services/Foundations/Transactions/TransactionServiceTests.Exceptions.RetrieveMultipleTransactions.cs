



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveMultipleTransactionIfUrlNotFoundAsync()
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    invalidConfigurationTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveMultipleTransactionIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveMultipleTransactionIfNotFoundOccurredAsync()
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    notFoundTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveMultipleTransactionIfBadRequestOccurredAsync()
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    invalidTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveMultipleTransactionIfTooManyRequestsOccurredAsync()
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    excessiveCallTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveMultipleTransactionIfHttpResponseErrorOccurredAsync()
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    failedServerTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveMultipleTransactionIfServiceErrorOccurredAsync()
        {
            // given
            DateTime someRandomToDate = GetRandomDate();
            string inputRandomToDate = someRandomToDate.ToString();
            DateTime someRandomFromDate = GetRandomDate();
            string inputRandomFromDate = someRandomFromDate.ToString();

            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MultipleTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleTransactionAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleTransactionAsync(It.IsAny<string>(), It.IsAny<string>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}