



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveFeesIfUrlNotFoundAsync()
        {
            // given

            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    invalidConfigurationTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveFeesIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();

            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveFeesIfNotFoundOccurredAsync()
        {
            // given
            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    notFoundTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveFeesIfBadRequestOccurredAsync()
        {
            // given
            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    invalidTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveFeesIfTooManyRequestsOccurredAsync()
        {
            // given
            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    excessiveCallTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveFeesIfHttpResponseErrorOccurredAsync()
        {
            // given
            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    failedServerTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveFeesIfServiceErrorOccurredAsync()
        {
            // given
            int inputRandomAmount = GetRandomNumber();
            string inputRandomCurrency = GetRandomString();

            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TransactionFees> retrieveTransactionsTask =
               this.transactionsService.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionFeesAsync(inputRandomAmount, inputRandomCurrency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}