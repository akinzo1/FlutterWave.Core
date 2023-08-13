



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
        public async Task ShouldThrowDependencyExceptionOnPostUpdatePayoutSubaccountRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
              CreateRandomUpdatePayoutSubaccountRequestProperties();


            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {
                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber



            };

            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationUpdatePayoutSubaccountException =
                new InvalidConfigurationPayoutSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    invalidConfigurationUpdatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, randomUpdatePayoutSubaccount);

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostUpdatePayoutSubaccountRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
            CreateRandomUpdatePayoutSubaccountRequestProperties();

            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {

                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber


            };

            var someRandomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };

            var unauthorizedUpdatePayoutSubaccountException =
                new UnauthorizedPayoutSubaccountsException(unauthorizedException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(unauthorizedUpdatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, someRandomUpdatePayoutSubaccount);

            PayoutSubaccountsDependencyException
                actualPayoutSubaccountsDependencyException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                        retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdatePayoutSubaccountRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
            CreateRandomUpdatePayoutSubaccountRequestProperties();

            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {

                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber


            };

            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundUpdatePayoutSubaccountException =
                new NotFoundPayoutSubaccountsException(
                    httpResponseNotFoundException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    notFoundUpdatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, randomUpdatePayoutSubaccount);

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdatePayoutSubaccountRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
            CreateRandomUpdatePayoutSubaccountRequestProperties();

            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {


                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber

            };

            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidUpdatePayoutSubaccountException =
                new InvalidPayoutSubaccountsException(
                    httpResponseBadRequestException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    invalidUpdatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, randomUpdatePayoutSubaccount);

            PayoutSubaccountsDependencyValidationException
                actualPayoutSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                        retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdatePayoutSubaccountRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
            CreateRandomUpdatePayoutSubaccountRequestProperties();

            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {


                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber

            };

            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallUpdatePayoutSubaccountException =
                new ExcessiveCallPayoutSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedPayoutSubaccountsDependencyValidationException =
                new PayoutSubaccountsDependencyValidationException(
                    excessiveCallUpdatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, randomUpdatePayoutSubaccount);

            PayoutSubaccountsDependencyValidationException actualPayoutSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyValidationException>(
                    retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostUpdatePayoutSubaccountRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
            CreateRandomUpdatePayoutSubaccountRequestProperties();

            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {


                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber

            };

            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerUpdatePayoutSubaccountException =
                new FailedServerPayoutSubaccountsException(
                    httpResponseException);

            var expectedPayoutSubaccountsDependencyException =
                new PayoutSubaccountsDependencyException(
                    failedServerUpdatePayoutSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, randomUpdatePayoutSubaccount);

            PayoutSubaccountsDependencyException actualPayoutSubaccountsDependencyException =
                await Assert.ThrowsAsync<PayoutSubaccountsDependencyException>(
                    retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualPayoutSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedPayoutSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostUpdatePayoutSubaccountRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomUpdatePayoutSubaccountRequestProperties =
           CreateRandomUpdatePayoutSubaccountRequestProperties();

            var accountReference = GetRandomString();

            var randomUpdatePayoutSubaccountRequest = new UpdatePayoutSubaccountRequest
            {

                Country = createRandomUpdatePayoutSubaccountRequestProperties.Country,
                AccountName = createRandomUpdatePayoutSubaccountRequestProperties.AccountName,
                Email = createRandomUpdatePayoutSubaccountRequestProperties.Email,
                MobileNumber = createRandomUpdatePayoutSubaccountRequestProperties.Mobilenumber


            };

            var randomUpdatePayoutSubaccount = new UpdatePayoutSubaccount
            {
                Request = randomUpdatePayoutSubaccountRequest
            };
            var serviceException = new Exception();

            var failedUpdatePayoutSubaccountServiceException =
                new FailedPayoutSubaccountsServiceException(serviceException);

            var expectedUpdatePayoutSubaccountServiceException =
                new PayoutSubaccountsServiceException(failedUpdatePayoutSubaccountServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdatePayoutSubaccount> retrieveUpdatePayoutSubaccountTask =
               this.payoutSubaccountService.PostUpdatePayoutSubaccountRequestAsync(accountReference, randomUpdatePayoutSubaccount);

            PayoutSubaccountsServiceException actualUpdatePayoutSubaccountServiceException =
                await Assert.ThrowsAsync<PayoutSubaccountsServiceException>(
                    retrieveUpdatePayoutSubaccountTask.AsTask);

            // then
            actualUpdatePayoutSubaccountServiceException.Should().BeEquivalentTo(
                expectedUpdatePayoutSubaccountServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdatePayoutSubaccountAsync(It.IsAny<string>(), It.IsAny<ExternalUpdatePayoutSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}