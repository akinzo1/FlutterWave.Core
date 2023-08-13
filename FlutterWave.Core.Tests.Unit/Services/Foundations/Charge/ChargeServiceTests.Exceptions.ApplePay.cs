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
        public async Task ShouldThrowDependencyExceptionOnPostApplePayRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomApplePayRequestProperties =
             CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
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
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostApplePayRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomApplePayRequestProperties =
               CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostApplePayRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomApplePayRequestProperties =
  CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
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
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostApplePayRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomApplePayRequestProperties =
  CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
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
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostApplePayRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomApplePayRequestProperties =
  CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
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
                 broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostApplePayRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomApplePayRequestProperties =
  CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
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
                 broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostApplePayRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomApplePayRequestProperties =
              CreateRandomApplePayRequestProperties();



            var randomApplePayRequest = new ApplePayRequest
            {
                Amount = createRandomApplePayRequestProperties.Amount,
                Currency = createRandomApplePayRequestProperties.Currency,
                BillingAddress = createRandomApplePayRequestProperties.BillingAddress,
                Narration = createRandomApplePayRequestProperties.Narration,
                PhoneNumber = createRandomApplePayRequestProperties.PhoneNumber,
                FullName = createRandomApplePayRequestProperties.Fullname,
                BillingZip = createRandomApplePayRequestProperties.BillingZip,
                BillingCountry = createRandomApplePayRequestProperties.BillingCountry,
                BillingCity = createRandomApplePayRequestProperties.BillingCity,
                BillingState = createRandomApplePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomApplePayRequestProperties.DeviceFingerprint,
                Meta = new ApplePayRequest.ApplePayMeta
                {
                    Metaname = createRandomApplePayRequestProperties.Meta.Metaname,
                    Metavalue = createRandomApplePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomApplePayRequestProperties.ClientIp,
                Email = createRandomApplePayRequestProperties.Email,
                RedirectUrl = createRandomApplePayRequestProperties.RedirectUrl,
                TxRef = createRandomApplePayRequestProperties.TxRef,

            };

            var randomApplePay = new ApplePay
            {
                Request = randomApplePayRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ApplePay> retrieveChargeTask =
               this.chargeService.PostChargeApplePayRequestAsync(randomApplePay);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeApplePayAsync(It.IsAny<ExternalApplePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}