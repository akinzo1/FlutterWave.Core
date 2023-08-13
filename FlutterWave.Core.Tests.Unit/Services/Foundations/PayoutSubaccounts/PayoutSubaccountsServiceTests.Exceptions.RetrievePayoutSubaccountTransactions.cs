



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrievePayoutSubaccountTransactionsRequestIfUrlNotFoundAsync()
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPayoutSubaccountsException =
                new InvalidConfigurationPayoutSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    invalidConfigurationPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrievePayoutSubaccountTransactionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();


            var unauthorizedPayoutSubaccountsException =
                new UnauthorizedPayoutSubaccountsException(unauthorizedException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrievePayoutSubaccountTransactionsRequestIfNotFoundOccurredAsync()
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPayoutSubaccountsException =
                new NotFoundPayoutSubaccountsException(
                    httpResponseNotFoundException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    notFoundPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrievePayoutSubaccountTransactionsRequestIfBadRequestOccurredAsync()
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPayoutSubaccountsException =
                new InvalidPayoutSubaccountsException(
                    httpResponseBadRequestException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    invalidPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrievePayoutSubaccountTransactionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPayoutSubaccountsException =
                new ExcessiveCallPayoutSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    excessiveCallPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsDependencyValidationException actualPayoutSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrievePayoutSubaccountTransactionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerPayoutSubaccountsException =
                new FailedServerPayoutSubaccountsException(
                    httpResponseException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    failedServerPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsDependencyException actualPayoutSubaccountsDependencyException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrievePayoutSubaccountTransactionsRequestIfServiceErrorOccurredAsync()
        {
            // given
            var accountReference = GetRandomString();
            var from = GetRandomString();
            var to = GetRandomString();
            var currency = GetRandomString();
            var serviceException = new Exception();

            var failedPayoutSubaccountsServiceException =
                new FailedPayoutSubaccountsServiceException(serviceException);

            var expectedPayoutSubaccountsServiceException =
                new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchPayoutSubaccountTransactions> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetPayoutSubaccountTransactionsRequestAsync(accountReference, from, to, currency);

            PayoutSubaccountsServiceException actualPayoutSubaccountsServiceException =
                await Assert.ThrowsAsync<PayoutSubaccountsServiceException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsServiceException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetPayoutSubaccountTransactionsAsync(accountReference, from, to, currency),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}