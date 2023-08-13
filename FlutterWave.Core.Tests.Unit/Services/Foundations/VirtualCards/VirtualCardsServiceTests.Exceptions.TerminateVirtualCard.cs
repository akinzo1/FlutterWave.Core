



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnTerminateVirtualCardRequestIfUrlNotFoundAsync()
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
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnTerminateVirtualCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomVirtualCardId = GetRandomString();

            var unauthorizedVirtualCardsException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnTerminateVirtualCardRequestIfNotFoundOccurredAsync()
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
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnTerminateVirtualCardRequestIfBadRequestOccurredAsync()
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
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnTerminateVirtualCardRequestIfTooManyRequestsOccurredAsync()
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
                 broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnTerminateVirtualCardRequestIfHttpResponseErrorOccurredAsync()
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
                 broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnTerminateVirtualCardRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomVirtualCardId = GetRandomString();
            var serviceException = new Exception();

            var failedVirtualCardsServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedVirtualCardsServiceException =
                new VirtualCardsServiceException(failedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TerminateVirtualCard> retrieveVirtualCardsTask =
               this.virtualCardsService.PostTerminateVirtualCardRequestAsync(randomVirtualCardId);

            VirtualCardsServiceException actualVirtualCardsServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsServiceException.Should().BeEquivalentTo(
                expectedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostTerminateVirtualCardAsync(randomVirtualCardId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}