using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDeleteSubaccountRequestIfUrlNotFoundAsync()
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
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnDeleteSubaccountRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomSubaccountId = GetRandomNumber();

            var unauthorizedCollectionSubaccountsException =
                new UnauthorizedCollectionSubaccountsException(unauthorizedException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeleteSubaccountRequestIfNotFoundOccurredAsync()
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
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeleteSubaccountRequestIfBadRequestOccurredAsync()
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
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeleteSubaccountRequestIfTooManyRequestsOccurredAsync()
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
                 broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyValidationException actualCollectionSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDeleteSubaccountRequestIfHttpResponseErrorOccurredAsync()
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
                 broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsDependencyException actualCollectionSubaccountsDependencyException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnDeleteSubaccountRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomSubaccountId = GetRandomNumber();
            var serviceException = new Exception();

            var failedCollectionSubaccountsServiceException =
                new FailedCollectionSubaccountsServiceException(serviceException);

            var expectedCollectionSubaccountsServiceException =
                new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DeleteSubaccount> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.DeleteCollectionSubaccountRequestAsync(randomSubaccountId);

            CollectionSubaccountsServiceException actualCollectionSubaccountsServiceException =
                await Assert.ThrowsAsync<CollectionSubaccountsServiceException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsServiceException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.DeleteCollectionSubaccountAsync(randomSubaccountId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}