using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalBillPayments;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayment;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.BillPayment
{
    public partial class BillPaymentsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostBillPaymentsRequestIfUrlNotFoundAsync()
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };

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
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostBillPaymentsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };

            var unauthorizedBillPaymentException =
                new UnauthorizedBillPaymentException(unauthorizedException);

            var expectedBillPaymentDependencyException =
                new BillPaymentDependencyException(unauthorizedBillPaymentException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentDependencyException
                actualBillPaymentDependencyException =
                    await Assert.ThrowsAsync<BillPaymentDependencyException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostBillPaymentsRequestIfNotFoundOccurredAsync()
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };

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
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostBillPaymentsRequestIfBadRequestOccurredAsync()
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };

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
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentDependencyValidationException
                actualBillPaymentDependencyValidationException =
                    await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                        retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostBillPaymentsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };

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
                 broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentDependencyValidationException actualBillPaymentDependencyValidationException =
                await Assert.ThrowsAsync<BillPaymentDependencyValidationException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyValidationException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostBillPaymentsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };

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
                 broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentDependencyException actualBillPaymentDependencyException =
                await Assert.ThrowsAsync<BillPaymentDependencyException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentDependencyException.Should().BeEquivalentTo(
                expectedBillPaymentDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostBillPaymentsRequestIfServiceErrorOccurredAsync()
        {
            // given
            string randomAmount = GetRandomString();
            string randomBillerName = GetRandomString();
            string randomCountry = GetRandomString();
            string randomCustomer = GetRandomString();
            string randomRecurrence = GetRandomString();
            string randomReference = GetRandomString();
            string randomType = GetRandomString();
            string inputAmount = randomAmount;
            string inputBillerName = randomBillerName;
            string inputCountry = randomCountry;
            string inputCustomer = randomCustomer;
            string inputRecurrence = randomRecurrence;
            string inputReference = randomReference;
            string inputType = randomType;



            var someRandomCreateBillPaymentRequest = new CreateBillPaymentRequest
            {
                Amount = inputAmount,
                BillerName = inputBillerName,
                Country = inputCountry,
                Customer = inputCustomer,
                Recurrence = inputRecurrence,
                Reference = inputReference,
                Type = inputType,

            };

            var randomPostCreateBillPayments = new PostBillPayments
            {
                Request = someRandomCreateBillPaymentRequest
            };
            var serviceException = new Exception();

            var failedBillPaymentServiceException =
                new FailedBillPaymentServiceException(serviceException);

            var expectedBillPaymentServiceException =
                new BillPaymentServiceException(failedBillPaymentServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<PostBillPayments> retrieveBillPaymentTask =
               this.billPaymentsService.PostCreateBillPaymentAsync(randomPostCreateBillPayments);

            BillPaymentServiceException actualBillPaymentServiceException =
                await Assert.ThrowsAsync<BillPaymentServiceException>(
                    retrieveBillPaymentTask.AsTask);

            // then
            actualBillPaymentServiceException.Should().BeEquivalentTo(
                expectedBillPaymentServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateBillPaymentAsync(It.IsAny<ExternalCreateBillPaymentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}