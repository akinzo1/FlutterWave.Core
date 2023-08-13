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
        public async Task ShouldThrowDependencyExceptionOnAllChargeBackRequestIfUrlNotFoundAsync()
        {
            // given


            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationChargeBackException =
                new InvalidConfigurationChargeBackException(
                    httpResponseUrlNotFoundException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(
                    invalidConfigurationChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllChargeBacksAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackDependencyException
                actualChargeBackDependencyException =
                    await Assert.ThrowsAsync<ChargeBackDependencyException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllChargeBackRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given


            var unauthorizedChargeBackException =
                new UnauthorizedChargeBackException(unauthorizedException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(unauthorizedChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllChargeBacksAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackDependencyException
                actualChargeBackDependencyException =
                    await Assert.ThrowsAsync<ChargeBackDependencyException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllChargeBackRequestIfNotFoundOccurredAsync()
        {
            // given


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundChargeBackException =
                new NotFoundChargeBackException(
                    httpResponseNotFoundException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    notFoundChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllChargeBacksAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackDependencyValidationException
                actualChargeBackDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllChargeBackRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidChargeBackException =
                new InvalidChargeBackException(
                    httpResponseBadRequestException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    invalidChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllChargeBacksAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackDependencyValidationException
                actualChargeBackDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                        retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllChargeBackRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallChargeBackException =
                new ExcessiveCallChargeBackException(
                    httpResponseTooManyRequestsException);

            var expectedChargeBackDependencyValidationException =
                new ChargeBackDependencyValidationException(
                    excessiveCallChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllChargeBacksAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackDependencyValidationException actualChargeBackDependencyValidationException =
                await Assert.ThrowsAsync<ChargeBackDependencyValidationException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeBackDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllChargeBackRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerChargeBackException =
                new FailedServerChargeBackException(
                    httpResponseException);

            var expectedChargeBackDependencyException =
                new ChargeBackDependencyException(
                    failedServerChargeBackException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.GetAllChargeBacksAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackDependencyException actualChargeBackDependencyException =
                await Assert.ThrowsAsync<ChargeBackDependencyException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackDependencyException.Should().BeEquivalentTo(
                expectedChargeBackDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllChargeBackRequestIfServiceErrorOccurredAsync()
        {
            // given

            var serviceException = new Exception();

            var failedChargeBackServiceException =
                new FailedChargeBackServiceException(serviceException);

            var expectedChargeBackServiceException =
                new ChargeBackServiceException(failedChargeBackServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.GetAllChargeBacksAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllChargeBacks> retrieveChargeBackTask =
               this.chargeBackService.GetAllChargeBacksAsync();

            ChargeBackServiceException actualChargeBackServiceException =
                await Assert.ThrowsAsync<ChargeBackServiceException>(
                    retrieveChargeBackTask.AsTask);

            // then
            actualChargeBackServiceException.Should().BeEquivalentTo(
                expectedChargeBackServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.GetAllChargeBacksAsync(),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}