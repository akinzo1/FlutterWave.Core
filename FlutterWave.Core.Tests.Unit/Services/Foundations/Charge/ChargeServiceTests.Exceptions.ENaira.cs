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
        public async Task ShouldThrowDependencyExceptionOnPostENairaRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomENairaRequestProperties =
              CreateRandomENairaRequestProperties();




            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,

            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
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
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostENairaRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomENairaRequestProperties =
             CreateRandomENairaRequestProperties();




            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,




            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostENairaRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomENairaRequestProperties =
              CreateRandomENairaRequestProperties();




            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,




            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
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
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostENairaRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomENairaRequestProperties =
          CreateRandomENairaRequestProperties();




            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,




            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
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
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostENairaRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomENairaRequestProperties =
          CreateRandomENairaRequestProperties();




            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,




            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
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
                 broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostENairaRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomENairaRequestProperties =
          CreateRandomENairaRequestProperties();




            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,




            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
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
                 broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostENairaRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomENairaRequestProperties =
            CreateRandomENairaRequestProperties();


            var randomENairaRequest = new ENairaRequest
            {
                Amount = createRandomENairaRequestProperties.Amount,
                FullName = createRandomENairaRequestProperties.Fullname,
                Currency = createRandomENairaRequestProperties.Currency,
                PhoneNumber = createRandomENairaRequestProperties.PhoneNumber,
                Email = createRandomENairaRequestProperties.Email,
                RedirectUrl = createRandomENairaRequestProperties.RedirectUrl,
                TxRef = createRandomENairaRequestProperties.TxRef,




            };

            var randomENaira = new ENaira
            {
                Request = randomENairaRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ENaira> retrieveChargeTask =
               this.chargeService.PostChargeENairaRequestAsync(randomENaira);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeENairaAsync(It.IsAny<ExternalENairaRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}