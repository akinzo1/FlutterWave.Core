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
        public async Task ShouldThrowDependencyExceptionOnPostPayPalRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomPayPalRequestProperties =
               CreateRandomPayPalRequestProperties();


            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,

            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
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
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostPayPalRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomPayPalRequestProperties =
             CreateRandomPayPalRequestProperties();




            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,




            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPayPalRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomPayPalRequestProperties =
              CreateRandomPayPalRequestProperties();




            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,




            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
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
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPayPalRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomPayPalRequestProperties =
          CreateRandomPayPalRequestProperties();


            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,




            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
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
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostPayPalRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomPayPalRequestProperties =
          CreateRandomPayPalRequestProperties();


            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,




            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
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
                 broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostPayPalRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomPayPalRequestProperties =
          CreateRandomPayPalRequestProperties();


            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,




            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
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
                 broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostPayPalRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomPayPalRequestProperties =
            CreateRandomPayPalRequestProperties();


            var randomPayPalRequest = new PayPalRequest
            {
                Amount = createRandomPayPalRequestProperties.Amount,
                Currency = createRandomPayPalRequestProperties.Currency,
                Email = createRandomPayPalRequestProperties.Email,
                BillingAddress = createRandomPayPalRequestProperties.BillingAddress,
                BillingCity = createRandomPayPalRequestProperties.BillingCity,
                BillingCountry = createRandomPayPalRequestProperties.BillingCountry,
                BillingState = createRandomPayPalRequestProperties.BillingState,
                BillingZip = createRandomPayPalRequestProperties.BillingZip,
                ClientIp = createRandomPayPalRequestProperties.ClientIp,
                Country = createRandomPayPalRequestProperties.Country,
                DeviceFingerprint = createRandomPayPalRequestProperties.DeviceFingerprint,
                FullName = createRandomPayPalRequestProperties.Fullname,
                PhoneNumber = createRandomPayPalRequestProperties.PhoneNumber,
                ShippingAddress = createRandomPayPalRequestProperties.ShippingAddress,
                ShippingCity = createRandomPayPalRequestProperties.ShippingCity,
                ShippingCountry = createRandomPayPalRequestProperties.ShippingCountry,
                ShippingName = createRandomPayPalRequestProperties.ShippingName,
                ShippingState = createRandomPayPalRequestProperties.ShippingState,
                ShippingZip = createRandomPayPalRequestProperties.ShippingZip,
                RedirectUrl = createRandomPayPalRequestProperties.RedirectUrl,
                TxRef = createRandomPayPalRequestProperties.TxRef,




            };

            var randomPayPal = new PayPal
            {
                Request = randomPayPalRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<PayPal> retrieveChargeTask =
               this.chargeService.PostChargePayPalRequestAsync(randomPayPal);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargePayPalAsync(It.IsAny<ExternalPayPalRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}