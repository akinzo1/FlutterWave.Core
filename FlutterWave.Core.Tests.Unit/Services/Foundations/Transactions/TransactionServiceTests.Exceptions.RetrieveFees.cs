



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveMultipleRefundsIfUrlNotFoundAsync()
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
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveMultipleRefundsIfUnauthorizedAsync(
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
                 broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveMultipleRefundsIfNotFoundOccurredAsync()
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
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveMultipleRefundsIfBadRequestOccurredAsync()
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
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveMultipleRefundsIfTooManyRequestsOccurredAsync()
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
                 broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveMultipleRefundsIfHttpResponseErrorOccurredAsync()
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
                 broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveMultipleRefundsIfServiceErrorOccurredAsync()
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
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MultipleRefundTransaction> retrieveTransactionsTask =
               this.transactionsService.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetMultipleRefundsAsync(inputRandomFromDate, inputRandomToDate),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}