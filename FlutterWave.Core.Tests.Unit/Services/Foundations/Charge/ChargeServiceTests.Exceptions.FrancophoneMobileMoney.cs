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
        public async Task ShouldThrowDependencyExceptionOnPostFrancophoneMobileMoneyRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
             CreateRandomFrancophoneMobileMoneyRequestProperties();


            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber

            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
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
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostFrancophoneMobileMoneyRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
             CreateRandomFrancophoneMobileMoneyRequestProperties();




            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber




            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostFrancophoneMobileMoneyRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
              CreateRandomFrancophoneMobileMoneyRequestProperties();




            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber




            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
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
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostFrancophoneMobileMoneyRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
          CreateRandomFrancophoneMobileMoneyRequestProperties();


            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber




            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
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
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostFrancophoneMobileMoneyRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
          CreateRandomFrancophoneMobileMoneyRequestProperties();


            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber




            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
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
                 broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostFrancophoneMobileMoneyRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
          CreateRandomFrancophoneMobileMoneyRequestProperties();


            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber




            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
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
                 broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostFrancophoneMobileMoneyRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomFrancophoneMobileMoneyRequestProperties =
            CreateRandomFrancophoneMobileMoneyRequestProperties();


            var randomFrancophoneMobileMoneyRequest = new FrancophoneMobileMoneyRequest
            {
                Amount = createRandomFrancophoneMobileMoneyRequestProperties.Amount,
                Currency = createRandomFrancophoneMobileMoneyRequestProperties.Currency,
                Email = createRandomFrancophoneMobileMoneyRequestProperties.Email,
                TxRef = createRandomFrancophoneMobileMoneyRequestProperties.TxRef,
                Country = createRandomFrancophoneMobileMoneyRequestProperties.Country,
                FullName = createRandomFrancophoneMobileMoneyRequestProperties.Fullname,
                PhoneNumber = createRandomFrancophoneMobileMoneyRequestProperties.PhoneNumber




            };

            var randomFrancophoneMobileMoney = new FrancophoneMobileMoney
            {
                Request = randomFrancophoneMobileMoneyRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FrancophoneMobileMoney> retrieveChargeTask =
               this.chargeService.PostChargeFrancophoneMobileMoneyRequestAsync(randomFrancophoneMobileMoney);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFrancophoneMobileMoneyAsync(It.IsAny<ExternalFrancophoneMobileMoneyRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}