using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveSubaccountsRequestIfUrlNotFoundAsync()
        {
            // given



            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCollectionSubaccountsException =
                new InvalidConfigurationCollectionSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    invalidConfigurationCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveSubaccountsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedCollectionSubaccountsException =
                new UnauthorizedCollectionSubaccountsException(unauthorizedException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(unauthorizedCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSubaccountsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveSubaccountsRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCollectionSubaccountsException =
                new NotFoundCollectionSubaccountsException(
                    httpResponseNotFoundException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    notFoundCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveSubaccountsRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCollectionSubaccountsException =
                new InvalidCollectionSubaccountsException(
                    httpResponseBadRequestException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    invalidCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveSubaccountsRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCollectionSubaccountsException =
                new ExcessiveCallCollectionSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    excessiveCallCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSubaccountsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsDependencyValidationException actualCollectionSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveSubaccountsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerCollectionSubaccountsException =
                new FailedServerCollectionSubaccountsException(
                    httpResponseException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    failedServerCollectionSubaccountsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetSubaccountsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsDependencyException actualCollectionSubaccountsDependencyException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveSubaccountsRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedCollectionSubaccountsServiceException =
                new FailedCollectionSubaccountsServiceException(serviceException);

            var expectedCollectionSubaccountsServiceException =
                new CollectionSubaccountsServiceException(failedCollectionSubaccountsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetSubaccountsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchSubaccounts> retrieveCollectionSubaccountsTask =
               this.collectionSubaccountsService.GetSubaccountsRequestAsync();

            CollectionSubaccountsServiceException actualCollectionSubaccountsServiceException =
                await Assert.ThrowsAsync<CollectionSubaccountsServiceException>(
                    retrieveCollectionSubaccountsTask.AsTask);

            // then
            actualCollectionSubaccountsServiceException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetSubaccountsAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}