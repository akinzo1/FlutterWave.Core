



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
        public async Task ShouldThrowDependencyExceptionOnPostUpdateCardTokenRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
              CreateRandomUpdateCardTokenRequestProperties();


            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationUpdateCardTokenException =
                new InvalidConfigurationTokenizedChargeException(
                    httpResponseUrlNotFoundException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    invalidConfigurationUpdateCardTokenException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, randomUpdateCardToken);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveUpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostUpdateCardTokenRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
            CreateRandomUpdateCardTokenRequestProperties();

            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var someRandomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };

            var unauthorizedUpdateCardTokenException =
                new UnauthorizedTokenizedChargeException(unauthorizedException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(unauthorizedUpdateCardTokenException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, someRandomUpdateCardToken);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveUpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdateCardTokenRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
            CreateRandomUpdateCardTokenRequestProperties();

            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundUpdateCardTokenException =
                new NotFoundTokenizedChargeException(
                    httpResponseNotFoundException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    notFoundUpdateCardTokenException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, randomUpdateCardToken);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveUpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdateCardTokenRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
            CreateRandomUpdateCardTokenRequestProperties();

            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidUpdateCardTokenException =
                new InvalidTokenizedChargeException(
                    httpResponseBadRequestException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    invalidUpdateCardTokenException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, randomUpdateCardToken);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveUpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostUpdateCardTokenRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
            CreateRandomUpdateCardTokenRequestProperties();

            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallUpdateCardTokenException =
                new ExcessiveCallTokenizedChargeException(
                    httpResponseTooManyRequestsException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    excessiveCallUpdateCardTokenException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, randomUpdateCardToken);

            TokenizedChargeDependencyValidationException actualTokenizedChargeDependencyValidationException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                    retrieveUpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostUpdateCardTokenRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
            CreateRandomUpdateCardTokenRequestProperties();

            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerUpdateCardTokenException =
                new FailedServerTokenizedChargeException(
                    httpResponseException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    failedServerUpdateCardTokenException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, randomUpdateCardToken);

            TokenizedChargeDependencyException actualTokenizedChargeDependencyException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                    retrieveUpdateCardTokenTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostUpdateCardTokenRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomUpdateCardTokenRequestProperties =
           CreateRandomUpdateCardTokenRequestProperties();

            var token = GetRandomString();

            var randomUpdateCardTokenRequest = new UpdateCardTokenRequest
            {
                Email = createRandomUpdateCardTokenRequestProperties.Email,
                FullName = createRandomUpdateCardTokenRequestProperties.FullName,
                PhoneNumber = createRandomUpdateCardTokenRequestProperties.PhoneNumber


            };

            var randomUpdateCardToken = new UpdateCardToken
            {
                Request = randomUpdateCardTokenRequest
            };
            var serviceException = new Exception();

            var failedUpdateCardTokenServiceException =
                new FailedTokenizedChargeServiceException(serviceException);

            var expectedUpdateCardTokenServiceException =
                new TokenizedChargeServiceException(failedUpdateCardTokenServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateCardToken> retrieveUpdateCardTokenTask =
               this.tokenizedChargeService.PostUpdateCardTokenRequestAsync(token, randomUpdateCardToken);

            TokenizedChargeServiceException actualUpdateCardTokenServiceException =
                await Assert.ThrowsAsync<TokenizedChargeServiceException>(
                    retrieveUpdateCardTokenTask.AsTask);

            // then
            actualUpdateCardTokenServiceException.Should().BeEquivalentTo(
                expectedUpdateCardTokenServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostUpdateCardTokenAsync(It.IsAny<string>(), It.IsAny<ExternalUpdateCardTokenRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}