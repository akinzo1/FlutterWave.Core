



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPayoutSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.PayoutSubaccount
{
    public partial class PayoutSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreatePayoutSubaccountRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
              CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber


            };

            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCreatePayoutSubaccountException =
                new InvalidConfigurationPayoutSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    invalidConfigurationCreatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(randomCreatePayoutSubaccount);

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreatePayoutSubaccountRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
            CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var someRandomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };

            var unauthorizedCreatePayoutSubaccountException =
                new UnauthorizedPayoutSubaccountsException(unauthorizedException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(unauthorizedCreatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(someRandomCreatePayoutSubaccount);

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreatePayoutSubaccountRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
            CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCreatePayoutSubaccountException =
                new NotFoundPayoutSubaccountsException(
                    httpResponseNotFoundException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    notFoundCreatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(randomCreatePayoutSubaccount);

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreatePayoutSubaccountRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
            CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCreatePayoutSubaccountException =
                new InvalidPayoutSubaccountsException(
                    httpResponseBadRequestException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    invalidCreatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(randomCreatePayoutSubaccount);

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreatePayoutSubaccountRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
            CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCreatePayoutSubaccountException =
                new ExcessiveCallPayoutSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    excessiveCallCreatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(randomCreatePayoutSubaccount);

            PayoutSubaccountsDependencyValidationException actualPayoutSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                    retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreatePayoutSubaccountRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
            CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCreatePayoutSubaccountException =
                new FailedServerPayoutSubaccountsException(
                    httpResponseException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    failedServerCreatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(randomCreatePayoutSubaccount);

            PayoutSubaccountsDependencyException actualPayoutSubaccountsDependencyException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                    retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCreatePayoutSubaccountRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreatePayoutSubaccountRequestProperties =
           CreateRandomCreatePayoutSubaccountRequestProperties();


            var randomCreatePayoutSubaccountRequest = new CreatePayoutSubaccountRequest
            {
                AccountName = createRandomCreatePayoutSubaccountRequestProperties.AccountName,
                Country = createRandomCreatePayoutSubaccountRequestProperties.Country,
                Email = createRandomCreatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomCreatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomCreatePayoutSubaccount = new CreatePayoutSubaccount
            {
                Request = randomCreatePayoutSubaccountRequest
            };
            var serviceException = new Exception();

            var failedCreatePayoutSubaccountServiceException =
                new FailedPayoutSubaccountsServiceException(serviceException);

            var expectedCreatePayoutSubaccountServiceException =
                new PayoutSubaccountsServiceException(failedCreatePayoutSubaccountServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreatePayoutSubaccount> retrieveCreatePayoutSubaccountTask =
               this.payoutSubaccountService.PostCreatePayoutSubaccountRequestAsync(randomCreatePayoutSubaccount);

            PayoutSubaccountsServiceException actualCreatePayoutSubaccountServiceException =
                await Assert.ThrowsAsync<PayoutSubaccountsServiceException>(
                    retrieveCreatePayoutSubaccountTask.AsTask);

            // then
            actualCreatePayoutSubaccountServiceException.Should().BeEquivalentTo(
                expectedCreatePayoutSubaccountServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreatePayoutSubaccountAsync(It.IsAny<ExternalCreatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}