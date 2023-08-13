



using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.TokenizedCharge
{
    public partial class TokenizedChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBulkTokenizedStatusRequestIfUrlNotFoundAsync()
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
                broker.GetBulkTokenizedStatusAsync(randomBulkId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBulkTokenizedStatusRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var randomBulkId = GetRandomNumber();

            var unauthorizedTokenizedChargeException =
                new UnauthorizedTokenizedChargeException(unauthorizedException);

            var expectedTokenizedChargeDependencyException =
                new TokenizedChargeDependencyException(unauthorizedTokenizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetBulkTokenizedStatusAsync(randomBulkId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeDependencyException
                actualTokenizedChargeDependencyException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBulkTokenizedStatusRequestIfNotFoundOccurredAsync()
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
                broker.GetBulkTokenizedStatusAsync(randomBulkId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBulkTokenizedStatusRequestIfBadRequestOccurredAsync()
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
                broker.GetBulkTokenizedStatusAsync(randomBulkId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeDependencyValidationException
                actualTokenizedChargeDependencyValidationException =
                    await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                        retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRetrieveBulkTokenizedStatusRequestIfTooManyRequestsOccurredAsync()
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
                 broker.GetBulkTokenizedStatusAsync(randomBulkId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeDependencyValidationException actualTokenizedChargeDependencyValidationException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyValidationException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRetrieveBulkTokenizedStatusRequestIfHttpResponseErrorOccurredAsync()
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
                 broker.GetBulkTokenizedStatusAsync(randomBulkId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeDependencyException actualTokenizedChargeDependencyException =
                await Assert.ThrowsAsync<TokenizedChargeDependencyException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeDependencyException.Should().BeEquivalentTo(
                expectedTokenizedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveBulkTokenizedStatusRequestIfServiceErrorOccurredAsync()
        {
            // given
            var randomBulkId = GetRandomNumber();
            var serviceException = new Exception();

            var failedTokenizedChargeServiceException =
                new FailedTokenizedChargeServiceException(serviceException);

            var expectedTokenizedChargeServiceException =
                new TokenizedChargeServiceException(failedTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BulkTokenizedStatus> retrieveTokenizedChargeTask =
               this.tokenizedChargeService.GetBulkTokenizedStatusRequestAsync(randomBulkId);

            TokenizedChargeServiceException actualTokenizedChargeServiceException =
                await Assert.ThrowsAsync<TokenizedChargeServiceException>(
                    retrieveTokenizedChargeTask.AsTask);

            // then
            actualTokenizedChargeServiceException.Should().BeEquivalentTo(
                expectedTokenizedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetBulkTokenizedStatusAsync(randomBulkId),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}