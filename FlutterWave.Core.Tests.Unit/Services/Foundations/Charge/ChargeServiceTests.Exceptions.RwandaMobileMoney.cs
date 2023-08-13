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
        public async Task ShouldThrowDependencyExceptionOnPostRwandaMobileMoneyRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
               CreateRandomRwandaMobileMoneyRequestProperties();


            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber

            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
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
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostRwandaMobileMoneyRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
             CreateRandomRwandaMobileMoneyRequestProperties();




            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber


            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostRwandaMobileMoneyRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
              CreateRandomRwandaMobileMoneyRequestProperties();




            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
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
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostRwandaMobileMoneyRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
          CreateRandomRwandaMobileMoneyRequestProperties();


            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
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
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostRwandaMobileMoneyRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
          CreateRandomRwandaMobileMoneyRequestProperties();


            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
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
                 broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostRwandaMobileMoneyRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
          CreateRandomRwandaMobileMoneyRequestProperties();


            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
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
                 broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostRwandaMobileMoneyRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomRwandaMobileMoneyRequestProperties =
            CreateRandomRwandaMobileMoneyRequestProperties();


            var randomRwandaMobileMoneyRequest = new RwandaMobileMoneyRequest
            {
                Amount = createRandomRwandaMobileMoneyRequestProperties.Amount,
                Currency = createRandomRwandaMobileMoneyRequestProperties.Currency,
                Email = createRandomRwandaMobileMoneyRequestProperties.Email,
                TxRef = createRandomRwandaMobileMoneyRequestProperties.TxRef,
                OrderId = createRandomRwandaMobileMoneyRequestProperties.OrderId,
                FullName = createRandomRwandaMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomRwandaMobileMoneyRequestProperties.PhoneNumber




            };

            var randomRwandaMobileMoney = new RwandaMobileMoney
            {
                Request = randomRwandaMobileMoneyRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<RwandaMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeRwandaMobileMoneyRequestAsync(randomRwandaMobileMoney);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeRwandaMobileMoneyAsync(It.IsAny<ExternalRwandaMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}