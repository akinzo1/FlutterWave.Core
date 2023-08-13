using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBack;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.ChargeBacks
{
    public partial class ChargeBackServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnChargeBackRequestIfUrlNotFoundAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationChargeBackException =
                new InvalidConfigurationChargeBackException(
                    httpResponseUrlNotFoundException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(
                    invalidConfigurationChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetChargeBackAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackDependencyException
                actualChargeBackDependencyException =
                    await Assert.ThrowsAsync<ChargeBackDependencyException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnChargeBackRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string someTransactionReference = GetRandomString();

            var unauthorizedChargeBackException =
                new UnauthorizedChargeBackException(unauthorizedException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(unauthorizedChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetChargeBackAsync(someTransactionReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackDependencyException
                actualChargeBackDependencyException =
                    await Assert.ThrowsAsync<ChargeBackDependencyException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnChargeBackRequestIfNotFoundOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundChargeBackException =
                new NotFoundChargeBackException(
                    httpResponseNotFoundException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    notFoundChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetChargeBackAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackDependencyValidationException
                actualChargeBackDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnChargeBackRequestIfBadRequestOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidChargeBackException =
                new InvalidChargeBackException(
                    httpResponseBadRequestException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    invalidChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetChargeBackAsync(someTransactionReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackDependencyValidationException
                actualChargeBackDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnChargeBackRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallChargeBackException =
                new ExcessiveCallChargeBackException(
                    httpResponseTooManyRequestsException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    excessiveCallChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetChargeBackAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackDependencyValidationException actualChargeBackDependencyValidationException =
                await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnChargeBackRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();

            var httpResponseException =
                new HttpResponseException();

            var failedServerChargeBackException =
                new FailedServerChargeBackException(
                    httpResponseException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(
                    failedServerChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetChargeBackAsync(someTransactionReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackDependencyException actualChargeBackDependencyException =
                await Assert.ThrowsAsync<ChargeBackDependencyException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnChargeBackRequestIfServiceErrorOccurredAsync()
        {
            // given
            string someTransactionReference = GetRandomString();
            var serviceException = new Exception();

            var failedChargeBackServiceException =
                new FailedChargeBackServiceException(serviceException);

            var expectedChargeBackServiceException =
                new ChargeBackServiceException(failedChargeBackServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetChargeBackAsync(someTransactionReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ChargeBack> retrieveChargeBackTask =
               this.chargeBackService.GetChargeBackAsync(someTransactionReference);

            ChargeBackServiceException actualChargeBackServiceException =
                await Assert.ThrowsAsync<ChargeBackServiceException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackServiceException.Should().BeEquivalentTo(
                expectedChargeBackServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetChargeBackAsync(someTransactionReference),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}