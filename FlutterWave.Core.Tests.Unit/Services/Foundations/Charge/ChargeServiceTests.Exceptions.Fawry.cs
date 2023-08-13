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
        public async Task ShouldThrowDependencyExceptionOnPostFawryRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomFawryRequestProperties =
               CreateRandomFawryRequestProperties();


            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,

            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
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
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostFawryRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomFawryRequestProperties =
             CreateRandomFawryRequestProperties();




            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,




            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostFawryRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomFawryRequestProperties =
              CreateRandomFawryRequestProperties();




            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,




            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
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
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostFawryRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomFawryRequestProperties =
          CreateRandomFawryRequestProperties();


            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,




            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
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
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostFawryRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomFawryRequestProperties =
          CreateRandomFawryRequestProperties();


            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,




            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
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
                 broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostFawryRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomFawryRequestProperties =
          CreateRandomFawryRequestProperties();


            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,




            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
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
                 broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostFawryRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomFawryRequestProperties =
            CreateRandomFawryRequestProperties();


            var randomFawryRequest = new FawryRequest
            {
                Amount = createRandomFawryRequestProperties.Amount,
                Meta = new FawryRequest.FawryMeta
                {
                    Name = createRandomFawryRequestProperties.Meta.Name,
                    Tools = createRandomFawryRequestProperties.Meta.Tools
                },

                Currency = createRandomFawryRequestProperties.Currency,
                Email = createRandomFawryRequestProperties.Email,
                PhoneNumber = createRandomFawryRequestProperties.PhoneNumber,
                RedirectUrl = createRandomFawryRequestProperties.RedirectUrl,
                TxRef = createRandomFawryRequestProperties.TxRef,




            };

            var randomFawry = new Fawry
            {
                Request = randomFawryRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Fawry> retrieveChargeTask =
               this.chargeService.PostChargeFawryRequestAsync(randomFawry);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeFawryAsync(It.IsAny<ExternalFawryRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}