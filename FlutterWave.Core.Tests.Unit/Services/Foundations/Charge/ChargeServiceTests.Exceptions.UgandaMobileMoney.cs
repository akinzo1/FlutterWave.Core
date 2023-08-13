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
        public async Task ShouldThrowDependencyExceptionOnPostUgandaMobileMoneyRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
               CreateRandomUgandaMobileMoneyRequestProperties();


            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
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
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostUgandaMobileMoneyRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
             CreateRandomUgandaMobileMoneyRequestProperties();




            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUgandaMobileMoneyRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
              CreateRandomUgandaMobileMoneyRequestProperties();




            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
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
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUgandaMobileMoneyRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
          CreateRandomUgandaMobileMoneyRequestProperties();


            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
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
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUgandaMobileMoneyRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
          CreateRandomUgandaMobileMoneyRequestProperties();


            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
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
                 broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUgandaMobileMoneyRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
          CreateRandomUgandaMobileMoneyRequestProperties();


            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
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
                 broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostUgandaMobileMoneyRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomUgandaMobileMoneyRequestProperties =
            CreateRandomUgandaMobileMoneyRequestProperties();


            var randomUgandaMobileMoneyRequest = new UgandaMobileMoneyRequest
            {
                Amount = createRandomUgandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomUgandaMobileMoneyRequestProperties.Currency,
                Email = createRandomUgandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomUgandaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomUgandaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomUgandaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomUgandaMobileMoneyRequestProperties.Network,
                Voucher = createRandomUgandaMobileMoneyRequestProperties.Voucher,
                Meta = new UgandaMobileMoneyRequest.UgandaMobileMoneyMeta
                {
                    FlightID = createRandomUgandaMobileMoneyRequestProperties.Meta.FlightID,

                },
                FullName = createRandomUgandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomUgandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomUgandaMobileMoney = new UgandaMobileMoney
            {
                Request = randomUgandaMobileMoneyRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UgandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeUgandaMobileMoneyRequestAsync(randomUgandaMobileMoney);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUgandaMobileMoneyAsync(It.IsAny<ExternalUgandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}