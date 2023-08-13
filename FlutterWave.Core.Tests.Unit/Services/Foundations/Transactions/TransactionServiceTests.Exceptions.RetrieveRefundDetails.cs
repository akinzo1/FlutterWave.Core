



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveRefundDetailsIfUrlNotFoundAsync()
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;



            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    invalidConfigurationTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveRefundDetailsIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;

            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetRefundDetailsAsync(inputRandomTransactionId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveRefundDetailsIfNotFoundOccurredAsync()
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    notFoundTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveRefundDetailsIfBadRequestOccurredAsync()
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    invalidTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveRefundDetailsIfTooManyRequestsOccurredAsync()
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    excessiveCallTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetRefundDetailsAsync(inputRandomTransactionId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveRefundDetailsIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    failedServerTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetRefundDetailsAsync(inputRandomTransactionId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveRefundDetailsIfServiceErrorOccurredAsync()
        {
            // given
            string someRandomTransactionId = GetRandomString();
            string inputRandomTransactionId = someRandomTransactionId;

            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<RefundDetails> retrieveTransactionsTask =
               this.transactionsService.GetRefundDetailsAsync(inputRandomTransactionId);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetRefundDetailsAsync(inputRandomTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}