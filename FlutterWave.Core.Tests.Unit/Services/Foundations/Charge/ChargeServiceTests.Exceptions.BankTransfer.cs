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
        public async Task ShouldThrowDependencyExceptionOnPostBankTransferRequestIfUrlNotFoundAsync()
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
              CreateRandomBankTransferRequestProperties();


            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
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
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostBankTransferRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
               CreateRandomBankTransferRequestProperties();



            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
            };

            var unauthorizedChargeException =
                new UnauthorizedChargeException(unauthorizedException);

            var expectedChargeDependencyException =
                new ChargeDependencyException(unauthorizedChargeException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeDependencyException
                actualChargeDependencyException =
                    await Assert.ThrowsAsync<ChargeDependencyException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBankTransferRequestIfNotFoundOccurredAsync()
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
CreateRandomBankTransferRequestProperties();


            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
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
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBankTransferRequestIfBadRequestOccurredAsync()
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
CreateRandomBankTransferRequestProperties();


            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
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
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeDependencyValidationException
                actualChargeDependencyValidationException =
                    await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                        retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostBankTransferRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
CreateRandomBankTransferRequestProperties();


            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
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
                 broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeDependencyValidationException actualChargeDependencyValidationException =
                await Assert.ThrowsAsync<ChargeDependencyValidationException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyValidationException.Should().BeEquivalentTo(
                expectedChargeDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostBankTransferRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
CreateRandomBankTransferRequestProperties();


            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
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
                 broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeDependencyException actualChargeDependencyException =
                await Assert.ThrowsAsync<ChargeDependencyException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeDependencyException.Should().BeEquivalentTo(
                expectedChargeDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostBankTransferRequestIfServiceErrorOccurredAsync()
        {
            // given
            dynamic createRandomBankTransferRequestProperties =
              CreateRandomBankTransferRequestProperties();



            var randomBankTransferRequest = new BankTransferRequest
            {
                TxRef = createRandomBankTransferRequestProperties.TxRef,
                Currency = createRandomBankTransferRequestProperties.Currency,
                ClientIp = createRandomBankTransferRequestProperties.ClientIp,
                Amount = createRandomBankTransferRequestProperties.Amount,
                DeviceFingerprint = createRandomBankTransferRequestProperties.DeviceFingerprint,
                Email = createRandomBankTransferRequestProperties.Email,
                Narration = createRandomBankTransferRequestProperties.Narration,
                IsPermanent = createRandomBankTransferRequestProperties.IsPermanent,
                PhoneNumber = createRandomBankTransferRequestProperties.PhoneNumber,

            };

            var randomBankTransfer = new BankTransfer
            {
                Request = randomBankTransferRequest
            };

            var serviceException = new Exception();

            var failedChargeServiceException =
                new FailedChargeServiceException(serviceException);

            var expectedChargeServiceException =
                new ChargeServiceException(failedChargeServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BankTransfer> retrieveChargeTask =
               this.chargeService.PostChargeBankTransferRequestAsync(randomBankTransfer);

            ChargeServiceException actualChargeServiceException =
                await Assert.ThrowsAsync<ChargeServiceException>(
                    retrieveChargeTask.AsTask);

            // then
            actualChargeServiceException.Should().BeEquivalentTo(
                expectedChargeServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(It.IsAny<ExternalBankTransferRequest>()),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}