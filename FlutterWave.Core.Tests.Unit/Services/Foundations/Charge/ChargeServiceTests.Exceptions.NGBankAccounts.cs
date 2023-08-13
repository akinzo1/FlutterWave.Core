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
        public async Task ShouldThrowDependencyExceptionOnPostNGBankAccountsRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
               CreateRandomNGBankAccountsRequestProperties();


            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,

            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
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
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostNGBankAccountsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
             CreateRandomNGBankAccountsRequestProperties();




            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,




            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostNGBankAccountsRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
              CreateRandomNGBankAccountsRequestProperties();




            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,




            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
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
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostNGBankAccountsRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
          CreateRandomNGBankAccountsRequestProperties();


            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,




            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
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
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostNGBankAccountsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
          CreateRandomNGBankAccountsRequestProperties();


            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,




            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
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
                 broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostNGBankAccountsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
          CreateRandomNGBankAccountsRequestProperties();


            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,




            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
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
                 broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostNGBankAccountsRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomNGBankAccountsRequestProperties =
            CreateRandomNGBankAccountsRequestProperties();


            var randomNGBankAccountsRequest = new NGBankAccountsRequest
            {
                Amount = createRandomNGBankAccountsRequestProperties.Amount,
                AccountBank = createRandomNGBankAccountsRequestProperties.AccountBank,
                AccountNumber = createRandomNGBankAccountsRequestProperties.AccountNumber,
                Currency = createRandomNGBankAccountsRequestProperties.Currency,
                Email = createRandomNGBankAccountsRequestProperties.Email,
                FullName = createRandomNGBankAccountsRequestProperties.Fullname,
                PhoneNumber = createRandomNGBankAccountsRequestProperties.PhoneNumber,
                TxRef = createRandomNGBankAccountsRequestProperties.TxRef,




            };

            var randomNGBankAccounts = new NGBankAccounts
            {
                Request = randomNGBankAccountsRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<NGBankAccounts> retrieveChargeTask =
               this.chargeService.PostChargeNGBankAccountRequestAsync(randomNGBankAccounts);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeNGBankAccountAsync(It.IsAny<ExternalNGBankAccountsRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}