



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchVirtualCardRequestIfUrlNotFoundAsync()
        {
            // given

            var randomVirtualCardId = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualCardsException =
                new InvalidConfigurationVirtualCardsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    invalidConfigurationVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFetchVirtualCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomVirtualCardId = GetRandomString();

            var unauthorizedVirtualCardsException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetVirtualCardAsync(randomVirtualCardId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchVirtualCardRequestIfNotFoundOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualCardsException =
                new NotFoundVirtualCardsException(
                    httpResponseNotFoundException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    notFoundVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchVirtualCardRequestIfBadRequestOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualCardsException =
                new InvalidVirtualCardsException(
                    httpResponseBadRequestException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    invalidVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchVirtualCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualCardsException =
                new ExcessiveCallVirtualCardsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    excessiveCallVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetVirtualCardAsync(randomVirtualCardId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchVirtualCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualCardsException =
                new FailedServerVirtualCardsException(
                    httpResponseException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    failedServerVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetVirtualCardAsync(randomVirtualCardId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFetchVirtualCardRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var serviceException = new Exception();

            var failedVirtualCardsServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedVirtualCardsServiceException =
                new VirtualCardsServiceException(failedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsServiceException actualVirtualCardsServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsServiceException.Should().BeEquivalentTo(
                expectedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}