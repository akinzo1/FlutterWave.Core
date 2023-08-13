



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
        public async Task ShouldThrowDependencyExceptionOnPostFundVirtualCardRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
              CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency

            };

            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationFundVirtualCardException =
                new InvalidConfigurationVirtualCardsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    invalidConfigurationFundVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, randomFundVirtualCard);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveFundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostFundVirtualCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
            CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var someRandomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };

            var unauthorizedFundVirtualCardException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedFundVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, someRandomFundVirtualCard);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveFundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostFundVirtualCardRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
            CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundFundVirtualCardException =
                new NotFoundVirtualCardsException(
                    httpResponseNotFoundException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    notFoundFundVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, randomFundVirtualCard);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveFundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostFundVirtualCardRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
            CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidFundVirtualCardException =
                new InvalidVirtualCardsException(
                    httpResponseBadRequestException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    invalidFundVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, randomFundVirtualCard);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveFundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostFundVirtualCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
            CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallFundVirtualCardException =
                new ExcessiveCallVirtualCardsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    excessiveCallFundVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, randomFundVirtualCard);

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveFundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostFundVirtualCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
            CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerFundVirtualCardException =
                new FailedServerVirtualCardsException(
                    httpResponseException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    failedServerFundVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, randomFundVirtualCard);

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveFundVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostFundVirtualCardRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomFundVirtualCardRequestProperties =
           CreateRandomFundVirtualCardRequestProperties();

            var randomVirtualCardId = GetRandomString();

            var randomFundVirtualCardRequest = new FundVirtualCardRequest
            {
                Amount = createRandomFundVirtualCardRequestProperties.Amount,
                DebitCurrency = createRandomFundVirtualCardRequestProperties.DebitCurrency


            };

            var randomFundVirtualCard = new FundVirtualCard
            {
                Request = randomFundVirtualCardRequest
            };
            var serviceException = new Exception();

            var failedFundVirtualCardServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedFundVirtualCardServiceException =
                new VirtualCardsServiceException(failedFundVirtualCardServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FundVirtualCard> retrieveFundVirtualCardTask =
               this.virtualCardsService.PostFundVirtualCardRequestAsync(randomVirtualCardId, randomFundVirtualCard);

            VirtualCardsServiceException actualFundVirtualCardServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveFundVirtualCardTask.AsTask);

            // then
            actualFundVirtualCardServiceException.Should().BeEquivalentTo(
                expectedFundVirtualCardServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostFundVirtualCardAsync(It.IsAny<string>(), It.IsAny<ExternalFundVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}