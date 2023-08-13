



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostRefundRequestIfUrlNotFoundAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    invalidConfigurationTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostRefundRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            int someTransactionId = GetRandomNumber();

            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateRefundRequestAsync(someTransactionId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostRefundRequestIfNotFoundOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    notFoundTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostRefundRequestIfBadRequestOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    invalidTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostRefundRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    excessiveCallTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateRefundRequestAsync(someTransactionId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostRefundRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    failedServerTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateRefundRequestAsync(someTransactionId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostRefundRequestIfServiceErrorOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateRefund> retrieveTransactionsTask =
               this.transactionsService.PostCreateRefundRequestAsync(someTransactionId);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateRefundRequestAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}