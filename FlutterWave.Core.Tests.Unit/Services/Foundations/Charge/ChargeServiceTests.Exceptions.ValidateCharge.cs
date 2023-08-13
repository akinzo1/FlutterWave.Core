using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostValidateChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
               CreateRandomValidateChargeRequestProperties();


            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,

            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationChargeException =
                new InvalidConfigurationChargeException(
                    httpResponseUrlNotFoundException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(
                    invalidConfigurationChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostValidateChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
             CreateRandomValidateChargeRequestProperties();




            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,




            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostValidateChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
              CreateRandomValidateChargeRequestProperties();




            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,




            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundChargeException =
                new NotFoundChargeException(
                    httpResponseNotFoundException);

            var expectedChargeDependencyValidationException =
                new ChargeDependencyValidationException(
                    notFoundChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostValidateChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
          CreateRandomValidateChargeRequestProperties();


            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,




            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidChargeException =
                new InvalidChargeException(
                    httpResponseBadRequestException);

            var expectedChargeDependencyValidationException =
                new ChargeDependencyValidationException(
                    invalidChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostValidateChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
          CreateRandomValidateChargeRequestProperties();


            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,




            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallChargeException =
                new ExcessiveCallChargeException(
                    httpResponseTooManyRequestsException);

            var expectedChargeDependencyValidationException =
                new ChargeDependencyValidationException(
                    excessiveCallChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostValidateChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
          CreateRandomValidateChargeRequestProperties();


            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,




            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerChargeException =
                new FailedServerChargeException(
                    httpResponseException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(
                    failedServerChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostValidateChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomValidateChargeRequestProperties =
            CreateRandomValidateChargeRequestProperties();


            var randomValidateChargeRequest = new ValidateChargeRequest
            {
                FlwRef = createRandomValidateChargeRequestProperties.FlwRef,
                Otp = createRandomValidateChargeRequestProperties.Otp,
                Type = createRandomValidateChargeRequestProperties.Type,




            };

            var randomValidateCharge = new ValidateCharge
            {
                Request = randomValidateChargeRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ValidateCharge> retrieveChargeTask =
               this.chargeService.PostValidateChargeRequestAsync(randomValidateCharge);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostValidateChargeAsync(It.IsAny<ExternalValidateChargeRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}