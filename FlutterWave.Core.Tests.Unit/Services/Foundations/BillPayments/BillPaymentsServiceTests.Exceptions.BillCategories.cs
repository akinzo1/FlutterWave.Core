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
        public async Task ShouldThrowDependencyExceptionOnBillCategoriesRequestIfUrlNotFoundAsync()
        {
            // given


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
                broker.GetBillCategoriesAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBillCategoriesRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBillCategoriesAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBillCategoriesRequestIfNotFoundOccurredAsync()
        {
            // given


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
                broker.GetBillCategoriesAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBillCategoriesRequestIfBadRequestOccurredAsync()
        {
            // given


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
                broker.GetBillCategoriesAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBillCategoriesRequestIfTooManyRequestsOccurredAsync()
        {
            // given


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
                 broker.GetBillCategoriesAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBillCategoriesRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


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
                 broker.GetBillCategoriesAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBillCategoriesRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBillCategoriesAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BillCategories> retrieveBillPaymentTask =
               this.billPaymentsService.GetBillCategoriesAsync();

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBillCategoriesAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}