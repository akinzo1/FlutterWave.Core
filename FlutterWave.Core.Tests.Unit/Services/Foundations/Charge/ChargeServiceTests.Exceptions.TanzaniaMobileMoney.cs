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
        public async Task ShouldThrowDependencyExceptionOnPostTanzaniaMobileMoneyRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
               CreateRandomTanzaniaMobileMoneyRequestProperties();


            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
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
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostTanzaniaMobileMoneyRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
             CreateRandomTanzaniaMobileMoneyRequestProperties();




            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostTanzaniaMobileMoneyRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
              CreateRandomTanzaniaMobileMoneyRequestProperties();




            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
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
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostTanzaniaMobileMoneyRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
          CreateRandomTanzaniaMobileMoneyRequestProperties();


            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
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
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostTanzaniaMobileMoneyRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
          CreateRandomTanzaniaMobileMoneyRequestProperties();


            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
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
                 broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostTanzaniaMobileMoneyRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
          CreateRandomTanzaniaMobileMoneyRequestProperties();


            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
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
                 broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostTanzaniaMobileMoneyRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomTanzaniaMobileMoneyRequestProperties =
            CreateRandomTanzaniaMobileMoneyRequestProperties();


            var randomTanzaniaMobileMoneyRequest = new TanzaniaMobileMoneyRequest
            {
                Amount = createRandomTanzaniaMobileMoneyRequestProperties.Amount,
                Currency = createRandomTanzaniaMobileMoneyRequestProperties.Currency,
                Email = createRandomTanzaniaMobileMoneyRequestProperties.Email,
                TxRef = createRandomTanzaniaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomTanzaniaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomTanzaniaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomTanzaniaMobileMoneyRequestProperties.Network,
                Meta = new TanzaniaMobileMoneyRequest.TanzaniaMobileMoneyMeta
                {
                    FlightID = createRandomTanzaniaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomTanzaniaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomTanzaniaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomTanzaniaMobileMoney = new TanzaniaMobileMoney
            {
                Request = randomTanzaniaMobileMoneyRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<TanzaniaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeTanzaniaMobileMoneyRequestAsync(randomTanzaniaMobileMoney);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeTanzaniaMobileMoneyAsync(It.IsAny<ExternalTanzaniaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}