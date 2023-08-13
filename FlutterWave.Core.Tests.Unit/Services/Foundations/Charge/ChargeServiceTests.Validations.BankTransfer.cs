using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Charge;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Charge
{
    public partial class ChargeServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnBankTransferIfChargeIsNullAsync()
        {
            // given
            BankTransfer? nullCharge = null;
            var nullChargeException = new NullChargeException();

            var exceptedChargeValidationException =
                new ChargeValidationException(nullChargeException);

            // when
            ValueTask<BankTransfer> PaymentsTask =
                this.chargeService.PostChargeBankTransferRequestAsync(nullCharge);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    PaymentsTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(exceptedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(
                    It.IsAny<ExternalBankTransferRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBankTransferIfRequestIsNullAsync()
        {
            // given
            var invalidPayments = new BankTransfer();
            invalidPayments.Request = null;

            var invalidPaymentsException =
                new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(BankTransferRequest),
                values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(
                    invalidPaymentsException);

            // when
            ValueTask<BankTransfer> BankTransferTask =
                this.chargeService.PostChargeBankTransferRequestAsync(invalidPayments);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    BankTransferTask.AsTask);

            // then
            actualChargeValidationException.Should()
                .BeEquivalentTo(expectedChargeValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostChargeBankTransferAsync(
                    It.IsAny<ExternalBankTransferRequest>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(0, null, null, null)]
        [InlineData(0, "", "", "")]
        [InlineData(0, "  ", "  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostBankTransferIfPaymentsIsInvalidAsync(
            int invalidAmount, string invalidEmail, string invalidPhoneNumber,
            string invalidTxRef)
        {
            // given
            var BankTransfer = new BankTransfer
            {
                Request = new BankTransferRequest
                {
                    Amount = invalidAmount,
                    Email = invalidEmail,
                    PhoneNumber = invalidPhoneNumber,
                    TxRef = invalidTxRef,


                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(BankTransferRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(BankTransferRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(BankTransferRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(BankTransferRequest.Amount),
             values: "Value is required");


            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<BankTransfer> BankTransferTask =
                this.chargeService.PostChargeBankTransferRequestAsync(BankTransfer);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(BankTransferTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBankTransferIfPostPaymentsIsEmptyAsync()
        {
            // given
            var BankTransfer = new BankTransfer
            {
                Request = new BankTransferRequest
                {

                    TxRef = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,

                }
            };

            var invalidPaymentsException = new InvalidChargeException();

            invalidPaymentsException.AddData(
                key: nameof(BankTransferRequest.PhoneNumber),
                values: "Value is required");

            invalidPaymentsException.AddData(
                key: nameof(BankTransferRequest.Email),
                values: "Value is required");

            invalidPaymentsException.AddData(
               key: nameof(BankTransferRequest.TxRef),
               values: "Value is required");

            invalidPaymentsException.AddData(
             key: nameof(BankTransferRequest.Amount),
             values: "Value is required");

            var expectedChargeValidationException =
                new ChargeValidationException(invalidPaymentsException);

            // when
            ValueTask<BankTransfer> BankTransferTask =
                this.chargeService.PostChargeBankTransferRequestAsync(BankTransfer);

            ChargeValidationException actualChargeValidationException =
                await Assert.ThrowsAsync<ChargeValidationException>(
                    BankTransferTask.AsTask);

            // then
            actualChargeValidationException.Should().BeEquivalentTo(
                expectedChargeValidationException);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}