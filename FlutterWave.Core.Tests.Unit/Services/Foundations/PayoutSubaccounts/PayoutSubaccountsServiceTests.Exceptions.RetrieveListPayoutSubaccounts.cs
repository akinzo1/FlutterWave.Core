



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveListPayoutSubaccountsRequestIfUrlNotFoundAsync()
        {
            // given



            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationPayoutSubaccountsException =
                new InvalidConfigurationPayoutSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    invalidConfigurationPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetListPayoutSubaccountsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveListPayoutSubaccountsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedPayoutSubaccountsException =
                new UnauthorizedPayoutSubaccountsException(unauthorizedException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(unauthorizedPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetListPayoutSubaccountsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveListPayoutSubaccountsRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundPayoutSubaccountsException =
                new NotFoundPayoutSubaccountsException(
                    httpResponseNotFoundException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    notFoundPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetListPayoutSubaccountsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveListPayoutSubaccountsRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidPayoutSubaccountsException =
                new InvalidPayoutSubaccountsException(
                    httpResponseBadRequestException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    invalidPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetListPayoutSubaccountsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveListPayoutSubaccountsRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallPayoutSubaccountsException =
                new ExcessiveCallPayoutSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    excessiveCallPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetListPayoutSubaccountsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsDependencyValidationException actualPayoutSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveListPayoutSubaccountsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerPayoutSubaccountsException =
                new FailedServerPayoutSubaccountsException(
                    httpResponseException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    failedServerPayoutSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetListPayoutSubaccountsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsDependencyException actualPayoutSubaccountsDependencyException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveListPayoutSubaccountsRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedPayoutSubaccountsServiceException =
                new FailedPayoutSubaccountsServiceException(serviceException);

            var expectedPayoutSubaccountsServiceException =
                new PayoutSubaccountsServiceException(failedPayoutSubaccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetListPayoutSubaccountsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ListPayoutSubaccounts> retrievePayoutSubaccountsTask =
               this.payoutSubaccountService.GetListPayoutSubaccountsRequestAsync();

            PayoutSubaccountsServiceException actualPayoutSubaccountsServiceException =
                await Assert.ThrowsAsync<PayoutSubaccountsServiceException>(
                    retrievePayoutSubaccountsTask.AsTask);

            // then
            actualPayoutSubaccountsServiceException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetListPayoutSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}