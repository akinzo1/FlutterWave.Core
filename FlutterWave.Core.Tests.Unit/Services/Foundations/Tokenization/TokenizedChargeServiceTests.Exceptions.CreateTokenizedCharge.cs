



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTokenizedCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostCreateTokenizedChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
              CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationCreateTokenizedChargeException =
                new InvalidConfigurationTokenizedChargeException(
                    httpResponseUrlNotFoundException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    invalidConfigurationCreateTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(randomCreateTokenizedCharge);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateTokenizedChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
            CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var someRandomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };

            var unauthorizedCreateTokenizedChargeException =
                new UnauthorizedTokenizedChargeException(unauthorizedException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(unauthorizedCreateTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(someRandomCreateTokenizedCharge);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateTokenizedChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
            CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundCreateTokenizedChargeException =
                new NotFoundTokenizedChargeException(
                    httpResponseNotFoundException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    notFoundCreateTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(randomCreateTokenizedCharge);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateTokenizedChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
            CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidCreateTokenizedChargeException =
                new InvalidTokenizedChargeException(
                    httpResponseBadRequestException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    invalidCreateTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(randomCreateTokenizedCharge);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostCreateTokenizedChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
            CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallCreateTokenizedChargeException =
                new ExcessiveCallTokenizedChargeException(
                    httpResponseTooManyRequestsException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    excessiveCallCreateTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(randomCreateTokenizedCharge);

            TokenizedChargeDependencyValidationException actualTokenizedChargeDependencyValidationException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                    retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostCreateTokenizedChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
            CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerCreateTokenizedChargeException =
                new FailedServerTokenizedChargeException(
                    httpResponseException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    failedServerCreateTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(randomCreateTokenizedCharge);

            TokenizedChargeDependencyException actualTokenizedChargeDependencyException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                    retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostCreateTokenizedChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomCreateTokenizedChargeRequestProperties =
           CreateRandomCreateTokenizedChargeRequestProperties();


            var randomCreateTokenizedChargeRequest = new CreateTokenizedChargeRequest
            {
                Amount = createRandomCreateTokenizedChargeRequestProperties.Amount,
                Country = createRandomCreateTokenizedChargeRequestProperties.Country,
                Currency = createRandomCreateTokenizedChargeRequestProperties.Currency,
                Email = createRandomCreateTokenizedChargeRequestProperties.Email,
                FirstName = createRandomCreateTokenizedChargeRequestProperties.FirstName,
                Ip = createRandomCreateTokenizedChargeRequestProperties.Ip,
                LastName = createRandomCreateTokenizedChargeRequestProperties.LastName,
                Narration = createRandomCreateTokenizedChargeRequestProperties.Narration,
                Token = createRandomCreateTokenizedChargeRequestProperties.Token,
                TxRef = createRandomCreateTokenizedChargeRequestProperties.TxRef


            };

            var randomCreateTokenizedCharge = new CreateTokenizedCharge
            {
                Request = randomCreateTokenizedChargeRequest
            };
            var serviceException = new Exception();

            var failedCreateTokenizedChargeServiceException =
                new FailedTokenizedChargeServiceException(serviceException);

            var expectedCreateTokenizedChargeServiceException =
                new TokenizedChargeServiceException(failedCreateTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateTokenizedCharge> retrieveCreateTokenizedChargeTask =
               this.tokenizedChargeService.PostCreateTokenizedChargeRequestAsync(randomCreateTokenizedCharge);

            TokenizedChargeServiceException actualCreateTokenizedChargeServiceException =
                await Assert.ThrowsAsync<TokenizedChargeServiceException>(
                    retrieveCreateTokenizedChargeTask.AsTask);

            // then
            actualCreateTokenizedChargeServiceException.Should().BeEquivalentTo(
                expectedCreateTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostCreateTokenizedChargeAsync(It.IsAny<ExternalCreateTokenizedChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}