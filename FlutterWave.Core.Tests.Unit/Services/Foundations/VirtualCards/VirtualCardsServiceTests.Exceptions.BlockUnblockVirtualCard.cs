



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBlockUnblockVirtualCardRequestIfUrlNotFoundAsync()
        {
            // given

            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualCardsException =
                new InvalidConfigurationVirtualCardsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    invalidConfigurationVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBlockUnblockVirtualCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();

            var unauthorizedVirtualCardsException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBlockUnblockVirtualCardRequestIfNotFoundOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualCardsException =
                new NotFoundVirtualCardsException(
                    httpResponseNotFoundException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    notFoundVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBlockUnblockVirtualCardRequestIfBadRequestOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualCardsException =
                new InvalidVirtualCardsException(
                    httpResponseBadRequestException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    invalidVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBlockUnblockVirtualCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualCardsException =
                new ExcessiveCallVirtualCardsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    excessiveCallVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBlockUnblockVirtualCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualCardsException =
                new FailedServerVirtualCardsException(
                    httpResponseException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    failedServerVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBlockUnblockVirtualCardRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var randomStatusAction = GetRandomString();
            var serviceException = new Exception();

            var failedVirtualCardsServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedVirtualCardsServiceException =
                new VirtualCardsServiceException(failedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BlockUnblockVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostBlockUnblockVirtualCardRequestAsync(randomVirtualCardId, randomStatusAction);

            VirtualCardsServiceException actualVirtualCardsServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsServiceException.Should().BeEquivalentTo(
                expectedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostBlockUnblockVirtualCardAsync(randomVirtualCardId, randomStatusAction),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}