



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalVirtualCards;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostVirtualCardWithdrawalRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
              CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,


            };

            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualCardWithdrawalException =
                new InvalidConfigurationVirtualCardsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    invalidConfigurationVirtualCardWithdrawalException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, randomVirtualCardWithdrawal);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostVirtualCardWithdrawalRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
            CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var someRandomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };

            var unauthorizedVirtualCardWithdrawalException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedVirtualCardWithdrawalException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, someRandomVirtualCardWithdrawal);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostVirtualCardWithdrawalRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
            CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualCardWithdrawalException =
                new NotFoundVirtualCardsException(
                    httpResponseNotFoundException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    notFoundVirtualCardWithdrawalException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, randomVirtualCardWithdrawal);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostVirtualCardWithdrawalRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
            CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualCardWithdrawalException =
                new InvalidVirtualCardsException(
                    httpResponseBadRequestException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    invalidVirtualCardWithdrawalException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, randomVirtualCardWithdrawal);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostVirtualCardWithdrawalRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
            CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualCardWithdrawalException =
                new ExcessiveCallVirtualCardsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    excessiveCallVirtualCardWithdrawalException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, randomVirtualCardWithdrawal);

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostVirtualCardWithdrawalRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
            CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualCardWithdrawalException =
                new FailedServerVirtualCardsException(
                    httpResponseException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    failedServerVirtualCardWithdrawalException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, randomVirtualCardWithdrawal);

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostVirtualCardWithdrawalRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomVirtualCardWithdrawalRequestProperties =
           CreateRandomVirtualCardWithdrawalRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomVirtualCardWithdrawalRequest = new VirtualCardWithdrawalRequest
            {
                Amount = createRandomVirtualCardWithdrawalRequestProperties.Amount,



            };

            var randomVirtualCardWithdrawal = new VirtualCardWithdrawal
            {
                Request = randomVirtualCardWithdrawalRequest
            };
            var serviceException = new Exception();

            var failedVirtualCardWithdrawalServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedVirtualCardWithdrawalServiceException =
                new VirtualCardsServiceException(failedVirtualCardWithdrawalServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<VirtualCardWithdrawal> retrieveVirtualCardWithdrawalTask =
               this.virtualCardsService.PostVirtualCardWithdrawalRequestAsync(randomVirtualCardId, randomVirtualCardWithdrawal);

            VirtualCardsServiceException actualVirtualCardWithdrawalServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveVirtualCardWithdrawalTask.AsTask);

            // then
            actualVirtualCardWithdrawalServiceException.Should().BeEquivalentTo(
                expectedVirtualCardWithdrawalServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostVirtualCardWithdrawalAsync(It.IsAny<string>(), It.IsAny<ExternalVirtualCardWithdrawalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}