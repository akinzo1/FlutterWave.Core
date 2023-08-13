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
        public async Task ShouldThrowDependencyExceptionOnPostGhanaMobileMoneyRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
             CreateRandomGhanaMobileMoneyRequestProperties();




            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
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
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostGhanaMobileMoneyRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
             CreateRandomGhanaMobileMoneyRequestProperties();




            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostGhanaMobileMoneyRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
              CreateRandomGhanaMobileMoneyRequestProperties();




            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
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
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostGhanaMobileMoneyRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
          CreateRandomGhanaMobileMoneyRequestProperties();


            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
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
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostGhanaMobileMoneyRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
          CreateRandomGhanaMobileMoneyRequestProperties();


            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
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
                 broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostGhanaMobileMoneyRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
          CreateRandomGhanaMobileMoneyRequestProperties();


            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
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
                 broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostGhanaMobileMoneyRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomGhanaMobileMoneyRequestProperties =
            CreateRandomGhanaMobileMoneyRequestProperties();


            var randomGhanaMobileMoneyRequest = new GhanaMobileMoneyRequest
            {
                Amount = createRandomGhanaMobileMoneyRequestProperties.Amount,
                Currency = createRandomGhanaMobileMoneyRequestProperties.Currency,
                Email = createRandomGhanaMobileMoneyRequestProperties.Email,
                TxRef = createRandomGhanaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomGhanaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomGhanaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomGhanaMobileMoneyRequestProperties.Network,
                Voucher = createRandomGhanaMobileMoneyRequestProperties.Voucher,
                Meta = new GhanaMobileMoneyRequest.GhanaMobileMoneyMeta
                {
                    FlightID = createRandomGhanaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomGhanaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomGhanaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomGhanaMobileMoney = new GhanaMobileMoney
            {
                Request = randomGhanaMobileMoneyRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<GhanaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeGhanaMobileMoneyRequestAsync(randomGhanaMobileMoney);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGhanaMobileMoneyAsync(It.IsAny<ExternalGhanaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}