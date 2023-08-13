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
        public async Task ShouldThrowDependencyExceptionOnPostMpesaRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomMpesaRequestProperties =
               CreateRandomMpesaRequestProperties();


            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,

            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
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
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostMpesaRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomMpesaRequestProperties =
             CreateRandomMpesaRequestProperties();




            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,




            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostMpesaRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomMpesaRequestProperties =
              CreateRandomMpesaRequestProperties();




            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,




            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
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
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostMpesaRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomMpesaRequestProperties =
          CreateRandomMpesaRequestProperties();


            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,




            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
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
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostMpesaRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomMpesaRequestProperties =
          CreateRandomMpesaRequestProperties();


            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,




            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
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
                 broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostMpesaRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomMpesaRequestProperties =
          CreateRandomMpesaRequestProperties();


            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,




            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
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
                 broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostMpesaRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomMpesaRequestProperties =
            CreateRandomMpesaRequestProperties();


            var randomMpesaRequest = new MpesaRequest
            {
                Amount = createRandomMpesaRequestProperties.Amount,
                Currency = createRandomMpesaRequestProperties.Currency,
                FullName = createRandomMpesaRequestProperties.Fullname,
                Email = createRandomMpesaRequestProperties.Email,
                PhoneNumber = createRandomMpesaRequestProperties.PhoneNumber,
                TxRef = createRandomMpesaRequestProperties.TxRef,




            };

            var randomMpesa = new Mpesa
            {
                Request = randomMpesaRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Mpesa> retrieveChargeTask =
               this.chargeService.PostChargeMpesaRequestAsync(randomMpesa);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeMpesaAsync(It.IsAny<ExternalMpesaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}