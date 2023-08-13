



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualCards;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.VirtualCards
{
    public partial class VirtualCardsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchVirtualCardsRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationVirtualCardsException =
                new InvalidConfigurationVirtualCardsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    invalidConfigurationVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFetchVirtualCardsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedVirtualCardsException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetVirtualCardsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchVirtualCardsRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundVirtualCardsException =
                new NotFoundVirtualCardsException(
                    httpResponseNotFoundException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    notFoundVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchVirtualCardsRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidVirtualCardsException =
                new InvalidVirtualCardsException(
                    httpResponseBadRequestException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    invalidVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFetchVirtualCardsRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallVirtualCardsException =
                new ExcessiveCallVirtualCardsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    excessiveCallVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetVirtualCardsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFetchVirtualCardsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerVirtualCardsException =
                new FailedServerVirtualCardsException(
                    httpResponseException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    failedServerVirtualCardsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetVirtualCardsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFetchVirtualCardsRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedVirtualCardsServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedVirtualCardsServiceException =
                new VirtualCardsServiceException(failedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetVirtualCardsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchVirtualCards> retrieveVirtualCardsTask =
               this.virtualCardsService.GetVirtualCardsRequestAsync();

            VirtualCardsServiceException actualVirtualCardsServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveVirtualCardsTask.AsTask);

            // then
            actualVirtualCardsServiceException.Should().BeEquivalentTo(
                expectedVirtualCardsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetVirtualCardsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}