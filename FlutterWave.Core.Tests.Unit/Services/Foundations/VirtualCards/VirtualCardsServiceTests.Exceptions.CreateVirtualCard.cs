



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
        public async Task ShouldThrowDependencyExceptionOnPostCreateVirtualCardRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
              CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCreateVirtualCardException =
                new InvalidConfigurationVirtualCardsException(
                    httpResponseUrlNotFoundException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    invalidConfigurationCreateVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(randomCreateVirtualCard);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveCreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateVirtualCardRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
            CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var someRandomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };

            var unauthorizedCreateVirtualCardException =
                new UnauthorizedVirtualCardsException(unauthorizedException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(unauthorizedCreateVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(someRandomCreateVirtualCard);

            VirtualCardsDependencyException
                actualVirtualCardsDependencyException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                        retrieveCreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateVirtualCardRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
            CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCreateVirtualCardException =
                new NotFoundVirtualCardsException(
                    httpResponseNotFoundException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    notFoundCreateVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(randomCreateVirtualCard);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveCreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateVirtualCardRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
            CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCreateVirtualCardException =
                new InvalidVirtualCardsException(
                    httpResponseBadRequestException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    invalidCreateVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(randomCreateVirtualCard);

            VirtualCardsDependencyValidationException
                actualVirtualCardsDependencyValidationException =
                    await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                        retrieveCreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateVirtualCardRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
            CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCreateVirtualCardException =
                new ExcessiveCallVirtualCardsException(
                    httpResponseTooManyRequestsException);

            var expectedVirtualCardsDependencyValidationException =
                new VirtualCardsDependencyValidationException(
                    excessiveCallCreateVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(randomCreateVirtualCard);

            VirtualCardsDependencyValidationException actualVirtualCardsDependencyValidationException =
                await Assert.ThrowsAsync<VirtualCardsDependencyValidationException>(
                    retrieveCreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyValidationException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateVirtualCardRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
            CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCreateVirtualCardException =
                new FailedServerVirtualCardsException(
                    httpResponseException);

            var expectedVirtualCardsDependencyException =
                new VirtualCardsDependencyException(
                    failedServerCreateVirtualCardException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(randomCreateVirtualCard);

            VirtualCardsDependencyException actualVirtualCardsDependencyException =
                await Assert.ThrowsAsync<VirtualCardsDependencyException>(
                    retrieveCreateVirtualCardTask.AsTask);

            // then
            actualVirtualCardsDependencyException.Should().BeEquivalentTo(
                expectedVirtualCardsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCreateVirtualCardRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateVirtualCardRequestProperties =
           CreateRandomCreateVirtualCardRequestProperties();


            var randomCreateVirtualCardRequest = new CreateVirtualCardRequest
            {
                Amount = createRandomCreateVirtualCardRequestProperties.Amount,
                BillingAddress = createRandomCreateVirtualCardRequestProperties.BillingAddress,
                BillingCity = createRandomCreateVirtualCardRequestProperties.BillingCity,
                BillingCountry = createRandomCreateVirtualCardRequestProperties.BillingCountry,
                Email = createRandomCreateVirtualCardRequestProperties.Email,
                BillingName = createRandomCreateVirtualCardRequestProperties.BillingName,
                BillingPostalCode = createRandomCreateVirtualCardRequestProperties.BillingPostalCode,
                BillingState = createRandomCreateVirtualCardRequestProperties.BillingState,
                CallbackUrl = createRandomCreateVirtualCardRequestProperties.CallbackUrl,
                Currency = createRandomCreateVirtualCardRequestProperties.Currency,
                DateOfBirth = createRandomCreateVirtualCardRequestProperties.DateOfBirth,
                DebitCurrency = createRandomCreateVirtualCardRequestProperties.DebitCurrency,
                FirstName = createRandomCreateVirtualCardRequestProperties.FirstName,
                Gender = createRandomCreateVirtualCardRequestProperties.Gender,
                LastName = createRandomCreateVirtualCardRequestProperties.LastName,
                Phone = createRandomCreateVirtualCardRequestProperties.Phone,
                Title = createRandomCreateVirtualCardRequestProperties.Title,


            };

            var randomCreateVirtualCard = new CreateVirtualCard
            {
                Request = randomCreateVirtualCardRequest
            };
            var serviceException = new Exception();

            var failedCreateVirtualCardServiceException =
                new FailedVirtualCardsServiceException(serviceException);

            var expectedCreateVirtualCardServiceException =
                new VirtualCardsServiceException(failedCreateVirtualCardServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateVirtualCard> retrieveCreateVirtualCardTask =
               this.virtualCardsService.PostCreateVirtualCardRequestAsync(randomCreateVirtualCard);

            VirtualCardsServiceException actualCreateVirtualCardServiceException =
                await Assert.ThrowsAsync<VirtualCardsServiceException>(
                    retrieveCreateVirtualCardTask.AsTask);

            // then
            actualCreateVirtualCardServiceException.Should().BeEquivalentTo(
                expectedCreateVirtualCardServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateVirtualCardAsync(It.IsAny<ExternalCreateVirtualCardRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}