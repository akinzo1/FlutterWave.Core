using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveSubaccountRequestIfUrlNotFoundAsync()
        {
            // given

            var randomSubaccountId = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCollectionSubaccountsException =
                new InvalidConfigurationCollectionSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    invalidConfigurationCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveSubaccountRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomSubaccountId = GetRandomNumber();

            var unauthorizedCollectionSubaccountsException =
                new UnauthorizedCollectionSubaccountsException(unauthorizedException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSubaccountAsync(randomSubaccountId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveSubaccountRequestIfNotFoundOccurredAsync()
        {
            // given
            var randomSubaccountId = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCollectionSubaccountsException =
                new NotFoundCollectionSubaccountsException(
                    httpResponseNotFoundException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    notFoundCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveSubaccountRequestIfBadRequestOccurredAsync()
        {
            // given
            var randomSubaccountId = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCollectionSubaccountsException =
                new InvalidCollectionSubaccountsException(
                    httpResponseBadRequestException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    invalidCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveSubaccountRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var randomSubaccountId = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCollectionSubaccountsException =
                new ExcessiveCallCollectionSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    excessiveCallCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSubaccountAsync(randomSubaccountId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyValidationException actualCollectionSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveSubaccountRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var randomSubaccountId = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerCollectionSubaccountsException =
                new FailedServerCollectionSubaccountsException(
                    httpResponseException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    failedServerCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSubaccountAsync(randomSubaccountId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyException actualCollectionSubaccountsDependencyException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveSubaccountRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomSubaccountId = GetRandomNumber();
            var serviceException = new Exception();

            var failedCollectionSubaccountsServiceException =
                new FailedCollectionSubaccountsServiceException(serviceException);

            var expectedCollectionSubaccountsServiceException =
                new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsServiceException actualCollectionSubaccountsServiceException =
                await Assert.ThrowsAsync<CollectionSubaccountsServiceException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsServiceException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}