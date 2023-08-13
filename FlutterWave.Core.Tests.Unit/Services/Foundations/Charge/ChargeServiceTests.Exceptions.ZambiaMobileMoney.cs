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
        public async Task ShouldThrowDependencyExceptionOnPostZambiaMobileMoneyRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
               CreateRandomZambiaMobileMoneyRequestProperties();


            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
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
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostZambiaMobileMoneyRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
             CreateRandomZambiaMobileMoneyRequestProperties();




            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostZambiaMobileMoneyRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
              CreateRandomZambiaMobileMoneyRequestProperties();




            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
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
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostZambiaMobileMoneyRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
          CreateRandomZambiaMobileMoneyRequestProperties();


            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
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
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostZambiaMobileMoneyRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
          CreateRandomZambiaMobileMoneyRequestProperties();


            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
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
                 broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostZambiaMobileMoneyRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
          CreateRandomZambiaMobileMoneyRequestProperties();


            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
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
                 broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostZambiaMobileMoneyRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomZambiaMobileMoneyRequestProperties =
            CreateRandomZambiaMobileMoneyRequestProperties();


            var randomZambiaMobileMoneyRequest = new ZambiaMobileMoneyRequest
            {
                Amount = createRandomZambiaMobileMoneyRequestProperties.Amount,
                Currency = createRandomZambiaMobileMoneyRequestProperties.Currency,
                Email = createRandomZambiaMobileMoneyRequestProperties.Email,
                TxRef = createRandomZambiaMobileMoneyRequestProperties.TxRef,
                ClientIp = createRandomZambiaMobileMoneyRequestProperties.ClientIp,
                DeviceFingerprint = createRandomZambiaMobileMoneyRequestProperties.DeviceFingerprint,
                Network = createRandomZambiaMobileMoneyRequestProperties.Network,
                OrderId = createRandomZambiaMobileMoneyRequestProperties.OrderId,
                Meta = new ZambiaMobileMoneyRequest.ZambiaMobileMoneyMeta
                {
                    FlightID = createRandomZambiaMobileMoneyRequestProperties.Meta.FlightID
                },
                FullName = createRandomZambiaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomZambiaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomZambiaMobileMoney = new ZambiaMobileMoney
            {
                Request = randomZambiaMobileMoneyRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ZambiaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeZambiaMobileMoneyRequestAsync(randomZambiaMobileMoney);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeZambiaMobileMoneyAsync(It.IsAny<ExternalZambiaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}