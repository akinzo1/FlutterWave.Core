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
        public async Task ShouldThrowDependencyExceptionOnPostGooglePayRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
               CreateRandomGooglePayRequestProperties();


            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,

            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
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
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostGooglePayRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
             CreateRandomGooglePayRequestProperties();




            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,




            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostGooglePayRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
              CreateRandomGooglePayRequestProperties();




            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,




            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
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
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostGooglePayRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
          CreateRandomGooglePayRequestProperties();


            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,




            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
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
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostGooglePayRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
          CreateRandomGooglePayRequestProperties();


            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,




            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
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
                 broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostGooglePayRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
          CreateRandomGooglePayRequestProperties();


            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,




            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
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
                 broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostGooglePayRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomGooglePayRequestProperties =
            CreateRandomGooglePayRequestProperties();


            var randomGooglePayRequest = new GooglePayRequest
            {
                Amount = createRandomGooglePayRequestProperties.Amount,
                Currency = createRandomGooglePayRequestProperties.Currency,
                BillingAddress = createRandomGooglePayRequestProperties.BillingAddress,
                Narration = createRandomGooglePayRequestProperties.Narration,
                FullName = createRandomGooglePayRequestProperties.Fullname,
                BillingZip = createRandomGooglePayRequestProperties.BillingZip,
                BillingCountry = createRandomGooglePayRequestProperties.BillingCountry,
                BillingCity = createRandomGooglePayRequestProperties.BillingCity,
                BillingState = createRandomGooglePayRequestProperties.BillingState,
                DeviceFingerprint = createRandomGooglePayRequestProperties.DeviceFingerprint,

                Meta = new GooglePayRequest.GooglePayMeta
                {
                    MetaName = createRandomGooglePayRequestProperties.Meta.Metaname,
                    MetaValue = createRandomGooglePayRequestProperties.Meta.Metavalue
                },
                ClientIp = createRandomGooglePayRequestProperties.ClientIp,
                Email = createRandomGooglePayRequestProperties.Email,
                RedirectUrl = createRandomGooglePayRequestProperties.RedirectUrl,
                TxRef = createRandomGooglePayRequestProperties.TxRef,




            };

            var randomGooglePay = new GooglePay
            {
                Request = randomGooglePayRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<GooglePay> retrieveChargeTask =
               this.chargeService.PostChargeGooglePayRequestAsync(randomGooglePay);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeGooglePayAsync(It.IsAny<ExternalGooglePayRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}