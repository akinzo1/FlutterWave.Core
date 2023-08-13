using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBillStatusRequestIfUrlNotFoundAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationBillPaymentException =
                new InvalidConfigurationBillPaymentException(
                    message: "Invalid BillPayment configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(
                    message: "BillPayment dependency error occurred, contact support.",
                    invalidConfigurationBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBillStatusRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someTransactionReference = GetRandomString();

            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBillStatusPaymentAsync(someTransactionReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBillStatusRequestIfNotFoundOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundBillPaymentException =
                new NotFoundBillPaymentException(
                    message: "Not found BillPayment error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedBillPaymentDependencyValidationException =
                new BillPaymentDependencyValidationException(
                    message: "BillPayment dependency validation error occurred, contact support.",
                    notFoundBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBillStatusRequestIfBadRequestOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidBillPaymentException =
                new InvalidBillPaymentException(
                    message: "Invalid BillPayment error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedBillPaymentDependencyValidationException =
                new BillPaymentDependencyValidationException(
                    message: "BillPayment dependency validation error occurred, contact support.",
                    invalidBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBillStatusRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallBillPaymentException =
                new ExcessiveCallBillPaymentException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedBillPaymentDependencyValidationException =
                new BillPaymentDependencyValidationException(
                    message: "BillPayment dependency validation error occurred, contact support.",
                    excessiveCallBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBillStatusPaymentAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBillStatusRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerBillPaymentException =
                new FailedServerBillPaymentException(
                    message: "Failed BillPayment server error occurred, contact support.",
                    httpResponseException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(
                    message: "BillPayment dependency error occurred, contact support.",
                    failedServerBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBillStatusPaymentAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBillStatusRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BillPaymentsStatus> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillStatusPaymentAsync(someTransactionReference);

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillStatusPaymentAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}