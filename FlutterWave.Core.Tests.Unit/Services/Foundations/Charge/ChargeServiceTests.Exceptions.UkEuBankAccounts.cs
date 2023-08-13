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
        public async Task ShouldThrowDependencyExceptionOnPostUkEuBankAccountsRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
               CreateRandomUkEuBankAccountsRequestProperties();


            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,

            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
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
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostUkEuBankAccountsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
             CreateRandomUkEuBankAccountsRequestProperties();




            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,




            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUkEuBankAccountsRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
              CreateRandomUkEuBankAccountsRequestProperties();




            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,




            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
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
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUkEuBankAccountsRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
          CreateRandomUkEuBankAccountsRequestProperties();


            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,




            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
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
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostUkEuBankAccountsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
          CreateRandomUkEuBankAccountsRequestProperties();


            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,




            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
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
                 broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostUkEuBankAccountsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
          CreateRandomUkEuBankAccountsRequestProperties();


            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,




            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
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
                 broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostUkEuBankAccountsRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomUkEuBankAccountsRequestProperties =
            CreateRandomUkEuBankAccountsRequestProperties();


            var randomUkEuBankAccountsRequest = new UkEuBankAccountsRequest
            {
                Amount = createRandomUkEuBankAccountsRequestProperties.Amount,
                IsTokenIo = createRandomUkEuBankAccountsRequestProperties.IsTokenIo,
                Currency = createRandomUkEuBankAccountsRequestProperties.Currency,
                FullName = createRandomUkEuBankAccountsRequestProperties.Fullname,
                Email = createRandomUkEuBankAccountsRequestProperties.Email,
                PhoneNumber = createRandomUkEuBankAccountsRequestProperties.PhoneNumber,
                RedirectUrl = createRandomUkEuBankAccountsRequestProperties.RedirectUrl,
                TxRef = createRandomUkEuBankAccountsRequestProperties.TxRef,




            };

            var randomUkEuBankAccounts = new UkEuBankAccounts
            {
                Request = randomUkEuBankAccountsRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UkEuBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeUkEuBankAccountsRequestAsync(randomUkEuBankAccounts);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeUkEuBankAccountsAsync(It.IsAny<ExternalUkEuBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}