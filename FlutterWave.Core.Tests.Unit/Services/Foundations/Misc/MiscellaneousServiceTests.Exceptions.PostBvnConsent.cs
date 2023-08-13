



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.Miscellaneous.ExternalVerification;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Miscellaneous;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Miscellaneous
{
    public partial class MiscellaneousServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostBvnConsentIfUrlNotFoundAsync()
        {
            // given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMiscException =
                new InvalidConfigurationMiscException(
                    httpResponseUrlNotFoundException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    invalidConfigurationMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostBvnConsentIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var unauthorizedMiscException =
                new UnauthorizedMiscException(unauthorizedException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(unauthorizedMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousDependencyException
                actualMiscellaneousDependencyException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBvnConsentIfNotFoundOccurredAsync()
        {
            // given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMiscException =
                new NotFoundMiscException(
                    httpResponseNotFoundException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    notFoundMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBvnConsentIfBadRequestOccurredAsync()
        {
            //given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMiscException =
                new InvalidMiscellaneousException(
                    httpResponseBadRequestException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    invalidMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousDependencyValidationException
                actualMiscellaneousDependencyValidationException =
                    await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                        retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBvnConsentIfTooManyRequestsOccurredAsync()
        {
            // given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMiscException =
                new ExcessiveCallMiscException(
                    httpResponseTooManyRequestsException);

            var expectedMiscellaneousDependencyValidationException =
                new MiscellaneousDependencyValidationException(
                    excessiveCallMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousDependencyValidationException actualMiscellaneousDependencyValidationException =
                await Assert.ThrowsAsync<MiscellaneousDependencyValidationException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyValidationException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostBvnConsentIfHttpResponseErrorOccurredAsync()
        {
            // given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var httpResponseException =
                new HttpResponseException();

            var failedServerMiscException =
                new FailedServerMiscException(
                    httpResponseException);

            var expectedMiscellaneousDependencyException =
                new MiscellaneousDependencyException(
                    failedServerMiscException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousDependencyException actualMiscellaneousDependencyException =
                await Assert.ThrowsAsync<MiscellaneousDependencyException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousDependencyException.Should().BeEquivalentTo(
                expectedMiscellaneousDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostBvnConsentIfServiceErrorOccurredAsync()
        {
            // given
            string randomBvn = GetRandomString();
            string randomFirstName = GetRandomString();
            string inputBvn = randomBvn;
            string inputFirstName = randomFirstName;
            string randomLastName = GetRandomString();
            string randomRedirectUrl = GetRandomString();
            string inputLastName = randomLastName;
            string inputRedirectUrl = randomRedirectUrl;


            dynamic createRandomBvnConsentProperties =
                  CreateRandomBvnConsentProperties();


            var randomBvnConsentRequest = new BvnConsentRequest
            {
                Bvn = inputBvn,
                FirstName = inputFirstName,
                LastName = inputLastName,
                RedirectUrl = inputRedirectUrl,


            };

            var randomBvnConsent = new BvnConsent
            {
                Request = randomBvnConsentRequest,
            };
            var serviceException = new Exception();

            var failedMiscellaneousServiceException =
                new FailedMiscServiceException(serviceException);

            var expectedMiscellaneousServiceException =
                new MiscellaneousServiceException(failedMiscellaneousServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BvnConsent> retrieveMiscTask =
               this.miscellaneousService.PostBvnConsentAsync(randomBvnConsent);

            MiscellaneousServiceException actualMiscellaneousServiceException =
                await Assert.ThrowsAsync<MiscellaneousServiceException>(
                    retrieveMiscTask.AsTask);

            // then
            actualMiscellaneousServiceException.Should().BeEquivalentTo(
                expectedMiscellaneousServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBvnConsentAsync(It.IsAny<ExternalBvnConsentRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}