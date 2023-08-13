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
        public async Task ShouldThrowDependencyExceptionOnPostPostChargeRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
              CreateRandomACHPaymentsRequestProperties();


            var randomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = randomACHPaymentsRequest
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
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPostChargeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
             CreateRandomACHPaymentsRequestProperties();


            var someRandomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostChargeRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
             CreateRandomACHPaymentsRequestProperties();


            var someRandomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
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
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostChargeRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
             CreateRandomACHPaymentsRequestProperties();


            var someRandomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
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
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPostChargeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
             CreateRandomACHPaymentsRequestProperties();


            var someRandomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
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
                 broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPostChargeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
             CreateRandomACHPaymentsRequestProperties();


            var someRandomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
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
                 broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPostChargeRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomACHPaymentsRequestProperties =
           CreateRandomACHPaymentsRequestProperties();


            var someRandomACHPaymentsRequest = new ACHPaymentsRequest
            {
                Amount = createRandomACHPaymentsRequestProperties.Amount,
                Meta = new ACHPaymentsRequest.ACHPaymentsMeta
                {
                    FlightID = createRandomACHPaymentsRequestProperties.Meta.FlightID,
                },
                ClientIp = createRandomACHPaymentsRequestProperties.ClientIp,
                Country = createRandomACHPaymentsRequestProperties.Country,
                Currency = createRandomACHPaymentsRequestProperties.Currency,
                DeviceFingerprint = createRandomACHPaymentsRequestProperties.DeviceFingerprint,
                Email = createRandomACHPaymentsRequestProperties.Email,
                FullName = createRandomACHPaymentsRequestProperties.Fullname,
                PhoneNumber = createRandomACHPaymentsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomACHPaymentsRequestProperties.RedirectUrl,
                TxRef = createRandomACHPaymentsRequestProperties.TxRef,

            };

            var randomACHPayments = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
            };

            var randomACHPayment = new ACHPayments
            {
                Request = someRandomACHPaymentsRequest
            };
            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ACHPayments> retrieveChargeTask =
               this.chargeService.PostChargeACHPaymentsRequestAsync(randomACHPayments);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeACHPaymentsAsync(It.IsAny<ExternalACHPaymentsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}