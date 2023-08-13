



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransactionTimelineRequestIfUrlNotFoundAsync()
        {
            // given
            string someTransactionId = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    invalidConfigurationTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransactionTimelineRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someTransactionId = GetRandomString();

            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransactionTimelineAsync(someTransactionId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransactionTimelineRequestIfNotFoundOccurredAsync()
        {
            // given
            string someTransactionId = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    notFoundTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransactionTimelineRequestIfBadRequestOccurredAsync()
        {
            // given
            string someTransactionId = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    invalidTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveTransactionTimelineRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someTransactionId = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    excessiveCallTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransactionTimelineAsync(someTransactionId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveTransactionTimelineRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someTransactionId = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    failedServerTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetTransactionTimelineAsync(someTransactionId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveTransactionTimelineRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someTransactionId = GetRandomString();
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TransactionTimeline> retrieveTransactionsTask =
               this.transactionsService.GetTransactionTimelineAsync(someTransactionId);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetTransactionTimelineAsync(someTransactionId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}