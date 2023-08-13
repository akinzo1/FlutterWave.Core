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
        public async Task ShouldThrowDependencyExceptionOnPostCreateCollectionSubaccountRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
              CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue


            };

            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCreateCollectionSubaccountException =
                new InvalidConfigurationCollectionSubaccountsException(
                    httpResponseUrlNotFoundException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    invalidConfigurationCreateCollectionSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(randomCreateCollectionSubaccount);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateCollectionSubaccountRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
            CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue



            };

            var someRandomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };

            var unauthorizedCreateCollectionSubaccountException =
                new UnauthorizedCollectionSubaccountsException(unauthorizedException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(unauthorizedCreateCollectionSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(someRandomCreateCollectionSubaccount);

            CollectionSubaccountsDependencyException
                actualCollectionSubaccountsDependencyException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                        retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateCollectionSubaccountRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
            CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue



            };

            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCreateCollectionSubaccountException =
                new NotFoundCollectionSubaccountsException(
                    httpResponseNotFoundException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    notFoundCreateCollectionSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(randomCreateCollectionSubaccount);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateCollectionSubaccountRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
            CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue



            };

            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCreateCollectionSubaccountException =
                new InvalidCollectionSubaccountsException(
                    httpResponseBadRequestException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    invalidCreateCollectionSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(randomCreateCollectionSubaccount);

            CollectionSubaccountsDependencyValidationException
                actualCollectionSubaccountsDependencyValidationException =
                    await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                        retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateCollectionSubaccountRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
            CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue



            };

            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCreateCollectionSubaccountException =
                new ExcessiveCallCollectionSubaccountsException(
                    httpResponseTooManyRequestsException);

            var expectedCollectionSubaccountsDependencyValidationException =
                new CollectionSubaccountsDependencyValidationException(
                    excessiveCallCreateCollectionSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(randomCreateCollectionSubaccount);

            CollectionSubaccountsDependencyValidationException actualCollectionSubaccountsDependencyValidationException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyValidationException>(
                    retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyValidationException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateCollectionSubaccountRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
            CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue



            };

            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCreateCollectionSubaccountException =
                new FailedServerCollectionSubaccountsException(
                    httpResponseException);

            var expectedCollectionSubaccountsDependencyException =
                new CollectionSubaccountsDependencyException(
                    failedServerCreateCollectionSubaccountException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(randomCreateCollectionSubaccount);

            CollectionSubaccountsDependencyException actualCollectionSubaccountsDependencyException =
                await Assert.ThrowsAsync<CollectionSubaccountsDependencyException>(
                    retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCollectionSubaccountsDependencyException.Should().BeEquivalentTo(
                expectedCollectionSubaccountsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCreateCollectionSubaccountRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateCollectionSubaccountRequestProperties =
           CreateRandomCreateCollectionSubaccountRequestProperties();


            var randomCreateCollectionSubaccountRequest = new CreateCollectionSubaccountRequest
            {
                AccountBank = createRandomCreateCollectionSubaccountRequestProperties.AccountBank,
                AccountNumber = createRandomCreateCollectionSubaccountRequestProperties.AccountNumber,
                BusinessContact = createRandomCreateCollectionSubaccountRequestProperties.BusinessContact,
                BusinessContactMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessContactMobile,
                BusinessEmail = createRandomCreateCollectionSubaccountRequestProperties.BusinessEmail,
                BusinessMobile = createRandomCreateCollectionSubaccountRequestProperties.BusinessMobile,
                BusinessName = createRandomCreateCollectionSubaccountRequestProperties.BusinessName,
                Country = createRandomCreateCollectionSubaccountRequestProperties.Country,
                Meta = ((List<dynamic>)createRandomCreateCollectionSubaccountRequestProperties.Meta).Select(data =>
                {
                    return new CreateCollectionSubaccountRequest.Metum
                    {
                        MetaName = data.MetaName,
                        MetaValue = data.MetaValue
                    };

                }).ToList(),
                SplitType = createRandomCreateCollectionSubaccountRequestProperties.SplitType,
                SplitValue = createRandomCreateCollectionSubaccountRequestProperties.SplitValue



            };

            var randomCreateCollectionSubaccount = new CreateCollectionSubaccount
            {
                Request = randomCreateCollectionSubaccountRequest
            };
            var serviceException = new Exception();

            var failedCreateCollectionSubaccountServiceException =
                new FailedCollectionSubaccountsServiceException(serviceException);

            var expectedCreateCollectionSubaccountServiceException =
                new CollectionSubaccountsServiceException(failedCreateCollectionSubaccountServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateCollectionSubaccount> retrieveCreateCollectionSubaccountTask =
               this.collectionSubaccountsService.PostCreateCollectionSubaccountRequestAsync(randomCreateCollectionSubaccount);

            CollectionSubaccountsServiceException actualCreateCollectionSubaccountServiceException =
                await Assert.ThrowsAsync<CollectionSubaccountsServiceException>(
                    retrieveCreateCollectionSubaccountTask.AsTask);

            // then
            actualCreateCollectionSubaccountServiceException.Should().BeEquivalentTo(
                expectedCreateCollectionSubaccountServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateCollectionSubaccountAsync(It.IsAny<ExternalCreateCollectionSubaccountRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}