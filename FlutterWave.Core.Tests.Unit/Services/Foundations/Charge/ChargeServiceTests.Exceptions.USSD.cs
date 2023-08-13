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
        public async Task ShouldThrowDependencyExceptionOnPostUSSDRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomUSSDRequestProperties =
               CreateRandomUSSDRequestProperties();


            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,

            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
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
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostUSSDRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomUSSDRequestProperties =
             CreateRandomUSSDRequestProperties();




            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,




            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUSSDRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomUSSDRequestProperties =
              CreateRandomUSSDRequestProperties();




            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,




            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
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
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUSSDRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomUSSDRequestProperties =
          CreateRandomUSSDRequestProperties();


            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,




            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
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
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUSSDRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomUSSDRequestProperties =
          CreateRandomUSSDRequestProperties();


            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,




            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
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
                 broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUSSDRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomUSSDRequestProperties =
          CreateRandomUSSDRequestProperties();


            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,




            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
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
                 broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostUSSDRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomUSSDRequestProperties =
            CreateRandomUSSDRequestProperties();


            var randomUSSDRequest = new USSDRequest
            {
                Amount = createRandomUSSDRequestProperties.Amount,
                PhoneNumber = createRandomUSSDRequestProperties.PhoneNumber,
                Currency = createRandomUSSDRequestProperties.Currency,
                FullName = createRandomUSSDRequestProperties.Fullname,
                Email = createRandomUSSDRequestProperties.Email,
                AccountBank = createRandomUSSDRequestProperties.AccountBank,
                TxRef = createRandomUSSDRequestProperties.TxRef,




            };

            var randomUSSD = new USSD
            {
                Request = randomUSSDRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<USSD> retrieveChargeTask =
               this.chargeService.PostChargeUSSDRequestAsync(randomUSSD);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUSSDAsync(It.IsAny<ExternalUSSDRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}