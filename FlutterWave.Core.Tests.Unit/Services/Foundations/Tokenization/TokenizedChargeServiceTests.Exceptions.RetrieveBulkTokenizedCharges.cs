



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBulkTokenizedChargeRequestIfUrlNotFoundAsync()
        {
            // given

            var randomBulkId = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTokenizedChargeException =
                new InvalidConfigurationTokenizedChargeException(
                    httpResponseUrlNotFoundException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    invalidConfigurationTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBulkTokenizedChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomBulkId = GetRandomNumber();

            var unauthorizedTokenizedChargeException =
                new UnauthorizedTokenizedChargeException(unauthorizedException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBulkTokenizedChargesAsync(randomBulkId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBulkTokenizedChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            var randomBulkId = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTokenizedChargeException =
                new NotFoundTokenizedChargeException(
                    httpResponseNotFoundException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    notFoundTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBulkTokenizedChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            var randomBulkId = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTokenizedChargeException =
                new InvalidTokenizedChargeException(
                    httpResponseBadRequestException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    invalidTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBulkTokenizedChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var randomBulkId = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTokenizedChargeException =
                new ExcessiveCallTokenizedChargeException(
                    httpResponseTooManyRequestsException);

            var expectedTokenizedChargeDependencyValidationException =
                new TokenizedChargeDependencyValidationException(
                    excessiveCallTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBulkTokenizedChargesAsync(randomBulkId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeDependencyValidationException actualTokenizedChargeDependencyValidationException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBulkTokenizedChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var randomBulkId = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTokenizedChargeException =
                new FailedServerTokenizedChargeException(
                    httpResponseException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(
                    failedServerTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBulkTokenizedChargesAsync(randomBulkId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeDependencyException actualTokenizedChargeDependencyException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveBulkTokenizedChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomBulkId = GetRandomNumber();
            var serviceException = new Exception();

            var failedTokenizedChargeServiceException =
                new FailedTokenizedChargeServiceException(serviceException);

            var expectedTokenizedChargeServiceException =
                new TokenizedChargeServiceException(failedTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FetchBulkTokenizedCharge> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedChargesRequestAsync(randomBulkId);

            TokenizedChargeServiceException actualTokenizedChargeServiceException =
                await Assert.ThrowsAsync<TokenizedChargeServiceException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeServiceException.Should().BeEquivalentTo(
                expectedTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedChargesAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}