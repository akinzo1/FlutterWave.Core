using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCollectionSubaccounts;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.CollectionSubaccount
{
    public partial class CollectionSubaccountsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUpdateSubaccountRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
              CreateRandomUpdateSubaccountRequestProperties();


            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {
                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,



            };

            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationUpdateSubaccountException =
                new InvalidConfigurationCollectionSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    invalidConfigurationUpdateSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, randomUpdateSubaccount);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveUpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostUpdateSubaccountRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
            CreateRandomUpdateSubaccountRequestProperties();

            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {

                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,


            };

            var someRandomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };

            var unauthorizedUpdateSubaccountException =
                new UnauthorizedCollectionSubaccountsException(unauthorizedException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(unauthorizedUpdateSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, someRandomUpdateSubaccount);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveUpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdateSubaccountRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
            CreateRandomUpdateSubaccountRequestProperties();

            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {

                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,


            };

            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundUpdateSubaccountException =
                new NotFoundCollectionSubaccountsException(
                    httpResponseNotFoundException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    notFoundUpdateSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, randomUpdateSubaccount);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveUpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdateSubaccountRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
            CreateRandomUpdateSubaccountRequestProperties();

            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {

                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,


            };

            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidUpdateSubaccountException =
                new InvalidCollectionSubaccountsException(
                    httpResponseBadRequestException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    invalidUpdateSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, randomUpdateSubaccount);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveUpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdateSubaccountRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
            CreateRandomUpdateSubaccountRequestProperties();

            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {

                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,


            };

            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallUpdateSubaccountException =
                new ExcessiveCallCollectionSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    excessiveCallUpdateSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, randomUpdateSubaccount);

            CollectionSubaccountsDependencyValidationException actualCollectionSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                    retrieveUpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostUpdateSubaccountRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
            CreateRandomUpdateSubaccountRequestProperties();

            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {

                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,


            };

            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerUpdateSubaccountException =
                new FailedServerCollectionSubaccountsException(
                    httpResponseException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    failedServerUpdateSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, randomUpdateSubaccount);

            CollectionSubaccountsDependencyException actualCollectionSubaccountsDependencyException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                    retrieveUpdateSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostUpdateSubaccountRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomUpdateSubaccountRequestProperties =
           CreateRandomUpdateSubaccountRequestProperties();

            var subaccountId = GetRandomNumber();

            var randomUpdateSubaccountRequest = new UpdateSubaccountRequest
            {

                SplitValue = createRandomUpdateSubaccountRequestProperties.SplitValue,
                SplitType = createRandomUpdateSubaccountRequestProperties.SplitType,
                AccountBank = createRandomUpdateSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomUpdateSubaccountRequestProperties.AccountNumber,
                BusinessEmail = createRandomUpdateSubaccountRequestProperties.BusinessEmail,
                BusinessName = createRandomUpdateSubaccountRequestProperties.BusinessName,


            };

            var randomUpdateSubaccount = new UpdateSubaccount
            {
                Request = randomUpdateSubaccountRequest
            };
            var serviceException = new Exception();

            var failedUpdateSubaccountServiceException =
                new FailedCollectionSubaccountsServiceException(serviceException);

            var expectedUpdateSubaccountServiceException =
                new CollectionSubaccountsServiceException(failedUpdateSubaccountServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateSubaccount> retrieveUpdateSubaccountTask =
               this.collectionSubaccountsService.PostUpdateCollectionSubaccountRequestAsync(subaccountId, randomUpdateSubaccount);

            CollectionSubaccountsServiceException actualUpdateSubaccountServiceException =
                await Assert.ThrowsAsync<CollectionSubaccountsServiceException>(
                    retrieveUpdateSubaccountTask.AsTask);

            // then
            actualUpdateSubaccountServiceException.Should().BeEquivalentTo(
                expectedUpdateSubaccountServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCollectionSubaccountAsync(It.IsAny<int>(), It.IsAny<ExternalUpdateSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}